using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Game
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject RedCube, BlueCube, GreenCube,YellowCube,PurpleCube;

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
    }
}

