using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Game
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject RedCube, BlueCube, GreenCube,YellowCube,PurpleCube,HorizontalRocket,VerticalRocket;

        public Transform SpawnBlock(BlockTypes blockType, CubeTypes cubeType = CubeTypes.Empty)
        {
            // Eğer cubeType verilmemişse (Empty ise) random seç
            if (cubeType == CubeTypes.Empty)
            {
                // CubeTypes enum'undaki geçerli renk sayısını al
                int cubeTypeCount = System.Enum.GetValues(typeof(CubeTypes)).Length-2;
                cubeType = (CubeTypes)Random.Range(0, cubeTypeCount);
            }

            Transform spawnedBlock = null;
            if (blockType == BlockTypes.Cube)
            {
                switch (cubeType)
                {
                    case CubeTypes.Red:
                        spawnedBlock = Instantiate(RedCube).transform;
                        break;
                    case CubeTypes.Blue:
                        spawnedBlock = Instantiate(BlueCube).transform;

                        break;
                    case CubeTypes.Green:
                        spawnedBlock = Instantiate(GreenCube).transform;

                        break;
                    case CubeTypes.Purple:
                        spawnedBlock = Instantiate(PurpleCube).transform;

                        break;
                    case CubeTypes.Yellow:
                        spawnedBlock = Instantiate(YellowCube).transform;

                        break;
                }

            }
            return spawnedBlock;

        }
        
        public Transform SpawnRocket()
        {
            Transform spawnedRocket = null;

            // 0 veya 1: %50 ihtimalle
            int random = Random.Range(0, 2);

            if (random == 0)
            {
                spawnedRocket = Instantiate(HorizontalRocket).transform;
            }
            else
            {
                spawnedRocket = Instantiate(VerticalRocket).transform;
            }

            return spawnedRocket;
        }
    }

}

