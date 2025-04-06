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
        [HideInInspector] public CubeTypes[,] cubeTypes = new CubeTypes[9, 9];
        [HideInInspector] public BlockCube[,] AllBlocks = new BlockCube[9, 9];
        [HideInInspector] public List<int> changingColumns = new();
        [SerializeField] private float spacing = 1f;

        // Start is called before the first frame update
        void Start()
        {
            GenerateGrid();
        }

        void GenerateGrid()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 spawnPosition = new Vector2(x * spacing, y * spacing);
                    //var spawnedCube = Instantiate(spawnBlock, spawnPosition, Quaternion.identity).transform;
                    var spawnedCube = GameManager.Instance.spawnManager.SpawnBlock(BlockTypes.Cube);
                    spawnedCube.position = spawnPosition;
                    spawnedCube.GetComponent<BlockCube>().gridIndex = new Vector2Int (x, y);
                    spawnedCube.GetComponent<BlockCube>().UpdateSortingOrder();
                    cubeTypes[x, y] = spawnedCube.GetComponent<BlockCube>().cubeType;
                    AllBlocks[x, y] = spawnedCube.GetComponent<BlockCube>();
                }
            }
        }
        
        public void AddChangingColumn(int columnIndex)
        {
            changingColumns.Add(columnIndex);
        }
        public void ClearChangingColumnList(int columnIndex)
        {

            changingColumns.Clear();
        }
    }
}