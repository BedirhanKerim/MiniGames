using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Match3Game
{
    public class BlockCube : Block, IInteractable
    {
      //  public Vector2Int  gridIndex;
     //   public Vector3 target;
        public bool canClick = true;
       // public CubeTypes cubeType;
     [SerializeField]  private SpriteRenderer childSpriteRenderer;
        // Start is called before the first frame update
        void Start()
        {

        }

        public void MoveToTarget(float arriveTime)
        {
            DOTween.Kill(transform);
            transform.DOKill();
            transform.DOMove(target, arriveTime).SetEase(Ease.OutBounce).OnComplete(() => { Invoke(nameof(UpdateSortingOrder),1f);});
        }

        public override void UpdateSortingOrder()
        {

            childSpriteRenderer.sortingOrder = (int)gridIndex.y + 1;
            //childSpriteRenderer.sortingOrder = (int)target.y + 1;

            Debug.Log("sorting");
        }

        public  void SetSortingOrder(int index)
        {

            childSpriteRenderer.sortingOrder = index;
        }

        private void Clicked()
        {
            List<Block> connectedCubes = GameManager.Instance.neighbourManager.FindConnectedCubes(gridIndex, cubeType);
            if (connectedCubes.Count >= 2)
            {
                
                bool isRocketSpawned = false;
                bool canSpawnRocket = connectedCubes.Count >= 5;
                //bool canSpawnRocket = false;
                if (canSpawnRocket)
                {
             //    var rocketBlock=   GameManager.Instance.spawnManager.SpawnRocket();

               //  rocketBlock.GetComponent<BlockRocket>().gridIndex = gridIndex;
                // GameManager.Instance.gridManager.AllBlocks[gridIndex.x,gridIndex.y]=
                }
                
                foreach (var cube in connectedCubes)
                {
                    // cube.canClick = false;
                    //  EffectsController.Instance.SpawnCubeCrackEffect(neigh.transform.position, curBlock.cubeType);
                    cube.transform.DOKill();
                    GameManager.Instance.gridManager.AllBlocks[cube.gridIndex.x, cube.gridIndex.y] = null;
                    Destroy(cube.gameObject);
                    GameManager.Instance.fillManager.Fill();
                    Debug.Log("Connected cube: " + cube.gridIndex + " with color: " + cube.cubeType);
                }
            }

        }
        public override void Interact()
        {
            if (canClick)
            {
                Debug.Log("clicked");
                Clicked();
            }
        }
    }
}