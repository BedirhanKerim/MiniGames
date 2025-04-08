using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
 public class SpawnManager : MonoBehaviour
 {
  [SerializeField] private GameObject goldParticle;

  private void OnEnable()
  {
   GameEventManager.Instance.OnSpawnGoldParticle += SpawnGoldParticle;
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
 }
}