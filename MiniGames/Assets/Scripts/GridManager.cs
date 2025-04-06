using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnBlock;
    [SerializeField] private int width = 9;
    [SerializeField] private int height = 9;
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
            var spawnedCube=    Instantiate(spawnBlock, spawnPosition, Quaternion.identity).transform;
            spawnedCube.GetComponent<BlockCube>().gridIndex = new Vector2(x, y);
            spawnedCube.GetComponent<BlockCube>().UpdateSortingOrder();
            }
        }
    }
}
