using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
namespace Match3Game
{
    public class BlockCube : MonoBehaviour, IInteractable
    {
        public Vector2Int  gridIndex;
        public Transform target;
        public bool canClick = true;
        public CubeTypes cubeType;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void MoveToTarget(float arriveTime)
        {
            DOTween.Kill(transform);
            transform.DOKill();
            transform.DOMove(target.position, arriveTime).SetEase(Ease.OutBounce).OnComplete(() => { });
        }

        public void UpdateSortingOrder()
        {

            var mySpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
            mySpriteRenderer.sortingOrder = (int)gridIndex.y + 1;
        }

        public void SetSortingOrder(int index)
        {
            var mySpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();

            mySpriteRenderer.sortingOrder = index;
        }

        private void Clicked()
        {
            List<BlockCube> connectedCubes = GameManager.Instance.neighbourManager.FindConnectedCubes(gridIndex, cubeType);
            if (connectedCubes.Count >= 2)
            {
                
                bool isRocketSpawned = false;
                bool canSpawnRocket = connectedCubes.Count >= 5;
                //bool canSpawnRocket = false;
                if (canSpawnRocket)
                {
                   // rocketSpawningEvent?.Invoke();

                }
            }

            foreach (var cube in connectedCubes)
            {
               // cube.canClick = false;
              //  EffectsController.Instance.SpawnCubeCrackEffect(neigh.transform.position, curBlock.cubeType);
              cube.transform.DOKill();
              Destroy(cube.gameObject);

                Debug.Log("Connected cube: " + cube.gridIndex + " with color: " + cube.cubeType);
            }
        }
        public void Interact()
        {
            if (canClick)
            {
                Debug.Log("clicked");
                Clicked();
            }
        }
    }
}