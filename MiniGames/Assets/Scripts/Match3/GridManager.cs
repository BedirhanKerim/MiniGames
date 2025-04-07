using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Game
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GameObject spawnBlock;
        [SerializeField] private int width = 9;
        [SerializeField] private int height = 9;
       // [HideInInspector] public CubeTypes[,] cubeTypes = new CubeTypes[9, 9];
        [HideInInspector] public Block[,] AllBlocks = new Block[9, 9];
        [SerializeField] private float spacing = 1f;

        // Start is called before the first frame update
        void Start()
        {
                GenerateGrid();
        }

        private void OnEnable()
        {
            GameEventManager.Instance.OnRequestAllBlocks += GetAllBlocksMatrix;
        }

        private void OnDisable()
        {
            GameEventManager.Instance.OnRequestAllBlocks -= GetAllBlocksMatrix;
        }

        private void GenerateGrid()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 spawnPosition = new Vector2(x * spacing, y * spacing);

                    var spawnedCube = GameEventManager.Instance.SpawnRandomBlockCube();

                    spawnedCube.position = spawnPosition;
                    var blockCube = spawnedCube.GetComponent<BlockCube>();
                    blockCube.gridIndex = new Vector2Int(x, y);
                    blockCube.UpdateSortingOrder();

                    AllBlocks[x, y] = blockCube;
                }
            }
        }

       private Block[,] GetAllBlocksMatrix()
       {
           return AllBlocks;
       }

    }
}