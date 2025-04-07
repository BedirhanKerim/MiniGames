using System.Collections;
using System.Collections.Generic;
using Match3Game;
using UnityEngine;

public class FillManager : MonoBehaviour
{
    public void Fill()
    {
        var allBlocks = GameManager.Instance.gridManager.AllBlocks;
        int width = allBlocks.GetLength(0); // x
        int height = allBlocks.GetLength(1); // y

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Eğer hücre boşsa, yukarıdan blok çek
                if (allBlocks[x, y] == null)
                {
                    for (int upperY = y + 1; upperY < height; upperY++)
                    {
                        if (allBlocks[x, upperY] != null)
                        {
                            // Yukarıdaki bloğu aşağıya kaydır
                            allBlocks[x, y] = allBlocks[x, upperY];
                            allBlocks[x, upperY] = null;

                            allBlocks[x, y].target = new Vector3(x, y, 0);
                            allBlocks[x, y].gridIndex = new Vector2Int(x, y);
                            allBlocks[x, y].MoveToTarget(0.5f);
                            allBlocks[x, y].UpdateSortingOrder();
                            break;
                        }
                    }
                }
            }
        }
        GameManager.Instance.fallManager.Fall();
        
    }


    }
