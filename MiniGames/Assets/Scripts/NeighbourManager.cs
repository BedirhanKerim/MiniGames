using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Game
{
    public class NeighbourManager : MonoBehaviour
    {
        private GridManager gridManager;
        private HashSet<Vector2> visited = new HashSet<Vector2>();
        

        public List<BlockCube> FindConnectedCubes(Vector2Int  startingIndex, CubeTypes targetType)
        {
            visited.Clear();
            List<BlockCube> connectedCubes = new List<BlockCube>();
            DFS(startingIndex, targetType, connectedCubes);
            return connectedCubes;
        }

        private void DFS(Vector2Int currentIndex, CubeTypes targetType, List<BlockCube> connectedCubes)
        {
            if (visited.Contains(currentIndex)) return;

            // Grid sınırları kontrolü
            int width = GameManager.Instance.gridManager.AllBlocks.GetLength(0);
            int height = GameManager.Instance.gridManager.AllBlocks.GetLength(1);

            if (currentIndex.x < 0 || currentIndex.x >= width || currentIndex.y < 0 || currentIndex.y >= height)
                return;

            visited.Add(currentIndex);

            BlockCube currentCube = GameManager.Instance.gridManager.AllBlocks[currentIndex.x, currentIndex.y];
            if (currentCube != null && currentCube.cubeType == targetType)
            {
                connectedCubes.Add(currentCube);
GameManager.Instance.gridManager.AddChangingColumn(currentCube.gridIndex.x);
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
    }
}