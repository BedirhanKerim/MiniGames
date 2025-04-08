using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
 public class SpawnManager : MonoBehaviour
 {
  [SerializeField] private GameObject goldParticle,roadPiecePrefab1;
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
   Instantiate(roadPiecePrefab1, spawnPos, Quaternion.identity,roadPiecesParentObj);
  }
 }
}