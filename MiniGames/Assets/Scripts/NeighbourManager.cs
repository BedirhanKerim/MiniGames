using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Game
{
    public class NeighbourManager : MonoBehaviour
    {
        private GridManager gridManager;
        private HashSet<Vector2> visited = new HashSet<Vector2>();


        public List<Block> FindConnectedCubes(Vector2Int startingIndex, CubeTypes targetType)
        {
            visited.Clear();
            List<Block> connectedCubes = new List<Block>();
            DFS(startingIndex, targetType, connectedCubes);
            return connectedCubes;
        }

        private void DFS(Vector2Int currentIndex, CubeTypes targetType, List<Block> connectedCubes)
        {
            if (visited.Contains(currentIndex)) return;

            // Grid sınırları kontrolü
            int width = GameManager.Instance.gridManager.AllBlocks.GetLength(0);
            int height = GameManager.Instance.gridManager.AllBlocks.GetLength(1);

            if (currentIndex.x < 0 || currentIndex.x >= width || currentIndex.y < 0 || currentIndex.y >= height)
                return;

            visited.Add(currentIndex);

            Block currentCube = GameManager.Instance.gridManager.AllBlocks[currentIndex.x, currentIndex.y];
            if (currentCube != null && currentCube.cubeType == targetType)
            {
                connectedCubes.Add(currentCube);
                GameManager.Instance.gridManager.AddNewChangingColumn(currentCube.gridIndex.x);
                Vector2Int[] neighborOffsets = new Vector2Int[]
                {
                    new Vector2Int(-1, 0),
                    new Vector2Int(1, 0),
                    new Vector2Int(0, -1),
                    new Vector2Int(0, 1)
                };

                foreach (var offset in neighborOffsets)
                {
                    Vector2Int neighborIndex = currentIndex + offset;
                    DFS(neighborIndex, targetType, connectedCubes);
                }
            }
        }



        public List<Vector2Int> FindHorizontalBlocks(Vector2Int gridIndex)
        {
            List<Vector2Int> horizontalBlocks = new List<Vector2Int>();
            var allBlocks = GameManager.Instance.gridManager.AllBlocks;

            int width = allBlocks.GetLength(0);

            for (int x = 0; x < width; x++)
            {
                if (x == gridIndex.x) continue;

                var block = allBlocks[x, gridIndex.y];
                if (block != null)
                    horizontalBlocks.Add(new Vector2Int(x, gridIndex.y));
            }

            return horizontalBlocks;
        }

        public List<Vector2Int> FindVerticalBlocks(Vector2Int gridIndex)
        {
            List<Vector2Int> verticalBlocks = new List<Vector2Int>();
            var allBlocks = GameManager.Instance.gridManager.AllBlocks;

            int height = allBlocks.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                if (y == gridIndex.y) continue;

                var block = allBlocks[gridIndex.x, y];
                if (block != null)
                    verticalBlocks.Add(new Vector2Int(gridIndex.x, y));
            }

            return verticalBlocks;
        }

    }
}