using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Match3Game
{
    public class BlockCube : Block, IInteractable
    {
        public bool canClick = true;
        [SerializeField] private SpriteRenderer childSpriteRenderer;

        public void MoveToTarget(float arriveTime)
        {
            transform.DOKill();
            transform.DOMove(target, arriveTime)
                .SetEase(Ease.OutBounce, 1.5f)
                .OnComplete(() => Invoke(nameof(UpdateSortingOrder), 1f));
        }

        public override void UpdateSortingOrder()
        {
            childSpriteRenderer.sortingOrder = gridIndex.y + 1;
        }

        public override void Interact()
        {
            if (canClick)
                Clicked();
        }

        private void Clicked()
        {
            var connectedCubes = GameEventManager.Instance.FindConnectedCubes(gridIndex, cubeType);
            if (connectedCubes.Count < 2) return;

            bool canSpawnRocket = connectedCubes.Count >= 5;
            var allBlocks = GameEventManager.Instance.RequestAllBlocks();

            foreach (var cube in connectedCubes)
            {
                cube.transform.DOKill();
                allBlocks[cube.gridIndex.x, cube.gridIndex.y] = null;
                cube.DestroyFunc();
            }

            if (canSpawnRocket)
                GameEventManager.Instance.FillOnlyOneBlock(BlockTypes.Rocket, gridIndex);

            GameEventManager.Instance.Fill();
        }

        public override void DestroyFunc(float time = 0)
        {
            GameEventManager.Instance.SpawnCubeCrackParticle(cubeType, transform.position);
            GameEventManager.Instance.ScoreChanged(10);
            Destroy(gameObject, time);
        }
    }
}