using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Match3Game
{
    public class BlockRocket : Block, IInteractable
    {
        [SerializeField] private RocketDirection rocketDirection;
        [SerializeField] private Transform LeftOrUpObj, RightOrDownObj;
        [SerializeField] private GameObject LeftOrUpObjParticle, RightOrDownObjParticle;
        private bool bCilcked = false;

        private void Clicked()
        {
            if (bCilcked) return;
            bCilcked = true;

            var allBlocks = GameEventManager.Instance.RequestAllBlocks();

            List<Vector2Int> foundBlocks = rocketDirection == RocketDirection.Vertical
                ? GameEventManager.Instance.FindVerticalBlocks(gridIndex)
                : GameEventManager.Instance.FindHorizontalBlocks(gridIndex);

            foreach (var pos in foundBlocks)
            {
                if (allBlocks[pos.x, pos.y] == null) continue;

                float distance = rocketDirection == RocketDirection.Vertical
                    ? Mathf.Abs(gridIndex.y - pos.y) / 20f
                    : Mathf.Abs(gridIndex.x - pos.x) / 20f;

                allBlocks[pos.x, pos.y].DestroyFunc(distance);
                allBlocks[pos.x, pos.y] = null;
            }

            allBlocks[gridIndex.x, gridIndex.y] = null;
            PlayRocketMove();
        }

        public void PlayRocketMove()
        {
            Vector3 leftObjTargetPos, rightObjTargetPos;

            if (rocketDirection == RocketDirection.Vertical)
            {
                leftObjTargetPos = new Vector3(gridIndex.x, gridIndex.y + 12, 0);
                rightObjTargetPos = new Vector3(gridIndex.x, gridIndex.y - 12, 0);
            }
            else
            {
                leftObjTargetPos = new Vector3(gridIndex.x - 12, gridIndex.y, 0);
                rightObjTargetPos = new Vector3(gridIndex.x + 12, gridIndex.y, 0);
            }

            LeftOrUpObj.transform.DOMove(leftObjTargetPos, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                GameEventManager.Instance.Fill();
                Destroy(gameObject);
            });

            RightOrDownObj.transform.DOMove(rightObjTargetPos, 0.5f).SetEase(Ease.Linear);

            LeftOrUpObjParticle.SetActive(true);
            RightOrDownObjParticle.SetActive(true);
        }


        public override void Interact()
        {
            Clicked();
        }

        public override void DestroyFunc(float time = 0)
        {
            Clicked();
        }
    }
}