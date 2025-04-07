using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Game
{
    public class NeighbourManager : MonoBehaviour
    {
        private GridManager gridManager;
        private HashSet<Vector2> visited = new HashSet<Vector2>();
        

        public List<Block> FindConnectedCubes(Vector2Int  startingIndex, CubeTypes targetType)
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
            var startBlock = allBlocks[gridIndex.x, gridIndex.y];
            if (startBlock == null) return horizontalBlocks;

            var cubeType = startBlock.cubeType;

            // Sağa doğru sırayla
            for (int x = gridIndex.x + 1; x < allBlocks.GetLength(0); x++)
            {
                var block = allBlocks[x, gridIndex.y];
                if (block != null && block.cubeType == cubeType)
                    horizontalBlocks.Add(block.gridIndex);
                else break;
            }

            // Sola doğru sırayla
            for (int x = gridIndex.x - 1; x >= 0; x--)
            {
                var block = allBlocks[x, gridIndex.y];
                if (block != null && block.cubeType == cubeType)
                    horizontalBlocks.Add(block.gridIndex);
                else break;
            }

            return horizontalBlocks;
        }
        public List<Vector2Int> FindVerticallBlocks(Vector2Int gridIndex)
        {
            List<Vector2Int> verticalBlocks = new List<Vector2Int>();

            var allBlocks = GameManager.Instance.gridManager.AllBlocks;
            var startBlock = allBlocks[gridIndex.x, gridIndex.y];
            if (startBlock == null) return verticalBlocks;

            var cubeType = startBlock.cubeType;

            // Yukarı sırayla
            for (int y = gridIndex.y + 1; y < allBlocks.GetLength(1); y++)
            {
                var block = allBlocks[gridIndex.x, y];
                if (block != null && block.cubeType == cubeType)
                    verticalBlocks.Add(block.gridIndex);
                else break;
            }

            // Aşağı sırayla
            for (int y = gridIndex.y - 1; y >= 0; y--)
            {
                var block = allBlocks[gridIndex.x, y];
                if (block != null && block.cubeType == cubeType)
                    verticalBlocks.Add(block.gridIndex);
                else break;
            }

            return verticalBlocks;
        }
    }
    

}