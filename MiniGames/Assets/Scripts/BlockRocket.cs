using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Match3Game
{
    public class BlockRocket : Block,IInteractable
    {
       // public Vector2Int  gridIndex;
        [SerializeField] private RocketDirection rocketDirection;
        [SerializeField] private Transform LeftOrUpObj, RightOrDownObj;
        [SerializeField] private Vector3 LeftOrUpObjTargetPos, RightOrDownObjTargetPos;
        [SerializeField] private GameObject LeftOrUpObjParticle, RightOrDownObjParticle;
        private void Clicked()
        {
           
            Destroy(this.gameObject,2f);
            if (rocketDirection==RocketDirection.Vertical)
            {
                var verticalBlocks = GameManager.Instance.neighbourManager.FindVerticallBlocks(gridIndex);
                foreach (var cube in verticalBlocks)
                {
                    // cube.canClick = false;
                    //  EffectsController.Instance.SpawnCubeCrackEffect(neigh.transform.position, curBlock.cubeType);
                   // cube.transform.DOKill();
                    GameManager.Instance.gridManager.AllBlocks[cube.x, cube.y] = null;
                   
                    GameManager.Instance.fillManager.Fill();
                   // Debug.Log("Connected cube: " + cube.gridIndex + " with color: " + cube.cubeType);
                }
            }
               
               
            }

        public override void Interact()
        {
            Clicked();
        }
    }
    }
