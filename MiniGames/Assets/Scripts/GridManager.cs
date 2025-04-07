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
        [HideInInspector] public Block[,] AllBlocks = new Block[9, 9];
        [HideInInspector] public Dictionary<int, int> changingColumns = new Dictionary<int, int>();//key is column index value is changing block count
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
        
        public void AddNewChangingColumn(int columnIndex)
        {
            if (changingColumns.ContainsKey(columnIndex))
            {
                int tmp = changingColumns[columnIndex];
                changingColumns[columnIndex] = tmp + 1;
            }
            else
            {
                changingColumns.Add(columnIndex, 1);
            }
        }
        public void DecreaseChangingColumn(int columnIndex)
        {
            if (changingColumns.ContainsKey(columnIndex))
            {
                int tmp = changingColumns[columnIndex];
                changingColumns[columnIndex] = tmp - 1;
                if (changingColumns[columnIndex] == 0)
                {
                    changingColumns.Remove(columnIndex);
                }
            }
      
        }
    }
}