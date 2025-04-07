using System.Collections;
using System.Collections.Generic;
using Match3Game;
using UnityEngine;

public class FillManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameEventManager.Instance.OnFill += Fill;
        GameEventManager.Instance.OnFillOnlyOneBlock += FillOnlyOneBlock;

    }

    private void OnDisable()
    {
        GameEventManager.Instance.OnFill -= Fill;
        GameEventManager.Instance.OnFillOnlyOneBlock -= FillOnlyOneBlock;
        
    }
    private void Fill()
    {
        var allBlocks = GameEventManager.Instance.RequestAllBlocks();
        int width = allBlocks.GetLength(0); // x
        int height = allBlocks.GetLength(1); // y

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Eğer hücre boşsa, yukarıdan blok çek
                if (allBlocks[x, y] == null)
                {
                    // Boş hücreyi doldurmak için yukarıdaki blokları kontrol et
                    for (int upperY = y + 1; upperY < height; upperY++)
                    {
                        if (allBlocks[x, upperY] != null)
                        {
                            // Yukarıdaki bloğu aşağıya kaydır
                            allBlocks[x, y] = allBlocks[x, upperY];
                            allBlocks[x, upperY] = null;

                            // Yeni pozisyon ve indeks ayarla, hareket et
                            var block = allBlocks[x, y];
                            block.target = new Vector3(x, y, 0);
                            block.gridIndex = new Vector2Int(x, y);
                            block.MoveToTarget(0.5f);
                            block.UpdateSortingOrder();
                            break;
                        }
                    }
                }
            }
        }

        GameEventManager.Instance.Fall();
    }

    private void FillOnlyOneBlock(BlockTypes blockType, Vector2Int gridIndex)
    {
        var allBlocks = GameEventManager.Instance.RequestAllBlocks();

        var rocketBlock = GameEventManager.Instance.SpawnBlockRocket();
        var blockRocket = rocketBlock.GetComponent<BlockRocket>();
    
        blockRocket.gridIndex = gridIndex;
        blockRocket.target = new Vector3(gridIndex.x, gridIndex.y, 0);
        rocketBlock.transform.position = new Vector3(gridIndex.x, gridIndex.y, 0);

        allBlocks[gridIndex.x, gridIndex.y] = rocketBlock.GetComponent<Block>();
    }
    }
