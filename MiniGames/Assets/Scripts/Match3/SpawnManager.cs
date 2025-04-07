using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Match3Game
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject RedCube,
            BlueCube,
            GreenCube,
            YellowCube,
            PurpleCube,
            HorizontalRocket,
            VerticalRocket,
            CubeCrackParticleBlue,
            CubeCrackParticleRed,
            CubeCrackParticleGreen,
            CubeCrackParticlePurple,
            CubeCrackParticleYellow;



        private void OnEnable()
        {
            GameEventManager.Instance.OnSpawnBlockRocket += SpawnRocket;
            GameEventManager.Instance.OnSpawnRandomBlockCube += SpawnRandomBlockCube;
            GameEventManager.Instance.OnSpawnCubeCrackParticle += SpawnCubeCrackParticle;
            
        }

        private void OnDisable()
        {
            GameEventManager.Instance.OnSpawnBlockRocket -= SpawnRocket;
            GameEventManager.Instance.OnSpawnRandomBlockCube -= SpawnRandomBlockCube;
            GameEventManager.Instance.OnSpawnCubeCrackParticle -= SpawnCubeCrackParticle;
            
        }

        private Transform SpawnRandomBlockCube()
        {
            CubeTypes cubeType;


            int cubeTypeCount = System.Enum.GetValues(typeof(CubeTypes)).Length - 2;
            cubeType = (CubeTypes)Random.Range(0, cubeTypeCount);


            Transform spawnedBlock = null;


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

            return spawnedBlock;
        }

        private Transform SpawnRocket()
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


        private void SpawnCubeCrackParticle(CubeTypes colorType, Vector3 spawnPosition)
        {
            Transform spawnedParticle = null;

            switch (colorType)
            {
                case CubeTypes.Red:
                    spawnedParticle = Instantiate(CubeCrackParticleRed, spawnPosition, Quaternion.identity).transform;
                    break;
                case CubeTypes.Blue:
                    spawnedParticle = Instantiate(CubeCrackParticleBlue, spawnPosition, Quaternion.identity).transform;
                    break;
                case CubeTypes.Green:
                    spawnedParticle = Instantiate(CubeCrackParticleGreen, spawnPosition, Quaternion.identity).transform;
                    break;
                case CubeTypes.Purple:
                    spawnedParticle = Instantiate(CubeCrackParticlePurple, spawnPosition, Quaternion.identity)
                        .transform;
                    break;
                case CubeTypes.Yellow:
                    spawnedParticle = Instantiate(CubeCrackParticleYellow, spawnPosition, Quaternion.identity)
                        .transform;
                    break;
            }

            Destroy(spawnedParticle.gameObject, 3f);
        }
    }
}