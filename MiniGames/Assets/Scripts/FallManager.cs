using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Game
{
    public class FallManager : MonoBehaviour
    {
       


        public void Fall()
        {Block[,] allBlocks;
            var gridManager = GameManager.Instance.gridManager;
            var spawnManager = GameManager.Instance.spawnManager;
            allBlocks = gridManager.AllBlocks;
            int width = allBlocks.GetLength(0);
            int  height = allBlocks.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (allBlocks[x, y] == null)
                    {
                        // Yeni blok üret
                        var newBlockGO = spawnManager.SpawnBlock(BlockTypes.Cube);

                        // Başlangıç pozisyonunu gridin dışından veriyoruz (yukarıdan düşüyormuş gibi)
                        Vector3 spawnPos = new Vector3(x, height + 1);
                        newBlockGO.transform.position = spawnPos;

                        BlockCube cube = newBlockGO.GetComponent<BlockCube>();

                        cube.gridIndex = new Vector2Int(x, y);
                        cube.target =new Vector3(x, y, 0);
                        cube.MoveToTarget(0.5f);
                        cube.UpdateSortingOrder();

                        allBlocks[x, y] = cube;
                    }
                }
            }
        }
    }
}