using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Game
{
    public class FallManager : MonoBehaviour
    {
        private void OnEnable()
        {
            GameEventManager.Instance.OnFall += Fall;
        }

        private void OnDisable()
        {
            GameEventManager.Instance.OnFall -= Fall;
        }

        private void Fall()
        {
            Block[,] allBlocks = GameEventManager.Instance.RequestAllBlocks();
            int width = allBlocks.GetLength(0);
            int height = allBlocks.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (allBlocks[x, y] == null)
                    {
                        // Yeni blok oluşturuluyor
                        var newBlockGO = GameEventManager.Instance.SpawnRandomBlockCube();
                        BlockCube cube = newBlockGO.GetComponent<BlockCube>();
                        cube.gridIndex = new Vector2Int(x, y);
                        cube.target = new Vector3(x, y, 0);
                        newBlockGO.transform.position = new Vector3(x, y + 9, 0);

                        // Bloku hedefe hareket ettir
                        cube.MoveToTarget(0.75f);
                        cube.UpdateSortingOrder();

                        // Yeni blok grid'e ekleniyor
                        allBlocks[x, y] = cube;
                    }
                }
            }
        }
    }
}