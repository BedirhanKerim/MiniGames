using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runner
{
 public class SpawnManager : MonoBehaviour
 {
  [SerializeField] private GameObject goldParticle,roadPiecePrefab1,roadPiecePrefab2,roadPiecePrefab3;
  [SerializeField] private Transform roadPiecesParentObj;


  private void OnEnable()
  {
   GameEventManager.Instance.OnSpawnGoldParticle += SpawnGoldParticle;
   GameEventManager.Instance.OnSpawnRoadPiece += SpawnRandomRoad;

  }

  private void OnDisable()
  {
   GameEventManager.Instance.OnSpawnGoldParticle -= SpawnGoldParticle;
  }

  private void SpawnGoldParticle(Vector3 spawnPos)
  {
  var spawnedParticle= Instantiate(goldParticle, spawnPos, Quaternion.identity);
  Destroy(spawnedParticle,3f);
  }

  private void SpawnRandomRoad(float zPosition)
  {
   Vector3 spawnPos = new Vector3(0, 0, zPosition);

   int randomIndex = Random.Range(0, 3); // 0, 1 veya 2
   GameObject prefabToSpawn = null;

   switch (randomIndex)
   {
    case 0:
     prefabToSpawn = roadPiecePrefab1;
     break;
    case 1:
     prefabToSpawn = roadPiecePrefab2;
     break;
    case 2:
     prefabToSpawn = roadPiecePrefab3;
     break;
   }

   Instantiate(prefabToSpawn, spawnPos, Quaternion.identity, roadPiecesParentObj);
  }
 }
}