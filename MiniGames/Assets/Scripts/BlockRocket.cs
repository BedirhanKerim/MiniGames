using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Match3Game
{
    public class BlockRocket : Block, IInteractable
    {
        // public Vector2Int  gridIndex;
        [SerializeField] private RocketDirection rocketDirection;
        [SerializeField] private Transform LeftOrUpObj, RightOrDownObj;
        [SerializeField] private GameObject LeftOrUpObjParticle, RightOrDownObjParticle;

        private void Clicked()
        {
            //Destroy(this.gameObject, 2f);
            if (rocketDirection == RocketDirection.Vertical)
            {
                var FoundBlocks = GameManager.Instance.neighbourManager.FindVerticalBlocks(gridIndex);

                foreach (var cube in FoundBlocks)
                {
                    // cube.canClick = false;
                    //  EffectsController.Instance.SpawnCubeCrackEffect(neigh.transform.position, curBlock.cubeType);
                    // cube.transform.DOKill();
                    var distance = Mathf.Abs(gridIndex.y - cube.y) / 20f;
                    GameManager.Instance.gridManager.AllBlocks[cube.x, cube.y].transform.GetComponent<BlockCube>().DestroyFunc(distance);

                    GameManager.Instance.gridManager.AllBlocks[cube.x, cube.y] = null;

                    //GameManager.Instance.fillManager.Fill();
                    Debug.Log("Connected cube: " + cube + " with color: " + cube);
                }
            }
            else
            {
                var FoundBlocks = GameManager.Instance.neighbourManager.FindHorizontalBlocks(gridIndex);
                foreach (var cube in FoundBlocks)
                {
                    // cube.canClick = false;
                    //  EffectsController.Instance.SpawnCubeCrackEffect(neigh.transform.position, curBlock.cubeType);
                    // cube.transform.DOKill();
                    var distance = Mathf.Abs(gridIndex.x - cube.x) / 20f;
                   // Destroy(GameManager.Instance.gridManager.AllBlocks[cube.x, cube.y].gameObject, distance);
                    GameManager.Instance.gridManager.AllBlocks[cube.x, cube.y].transform.GetComponent<BlockCube>().DestroyFunc(distance);
                    GameManager.Instance.gridManager.AllBlocks[cube.x, cube.y] = null;

                    //GameManager.Instance.fillManager.Fill();
                    Debug.Log("Connected cube: " + cube + " with color: " + cube);
                }
            }

            PlayRocketMove();


            GameManager.Instance.gridManager.AllBlocks[gridIndex.x, gridIndex.y] = null;
            //  Destroy(this.gameObject);
            // GameManager.Instance.fillManager.Fill();
        }

        public void PlayRocketMove()
        {
            if (rocketDirection == RocketDirection.Vertical)
            {
                Vector3 UpObjTargetPos, DownObjTargetPos;
                UpObjTargetPos = new Vector3(gridIndex.x, gridIndex.y + 12, 0);
                DownObjTargetPos = new Vector3(gridIndex.x, gridIndex.y - 12, 0);
                LeftOrUpObj.transform.DOMove(UpObjTargetPos, .5f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    GameManager.Instance.fillManager.Fill();
                    Destroy(gameObject);
                    
                });
                RightOrDownObj.transform.DOMove(DownObjTargetPos, .5f).SetEase(Ease.Linear);
            }
            else
            {
                Vector3 LeftObjTargetPos, RightObjTargetPos;
                LeftObjTargetPos = new Vector3(gridIndex.x - 12, gridIndex.y, 0);
                RightObjTargetPos = new Vector3(gridIndex.x + 12, gridIndex.y, 0);
                LeftOrUpObj.transform.DOMove(LeftObjTargetPos, .5f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    GameManager.Instance.fillManager.Fill();
                    Destroy(gameObject);
                });
                RightOrDownObj.transform.DOMove(RightObjTargetPos, .5f).SetEase(Ease.Linear);
            }

            LeftOrUpObjParticle.SetActive(true);
            RightOrDownObjParticle.SetActive(true);
        }

        public override void Interact()
        {
            Clicked();
        }
    }
}