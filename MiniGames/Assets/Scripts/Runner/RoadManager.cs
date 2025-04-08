using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class RoadManager : MonoBehaviour
    {
        [SerializeField] private Transform roadPiecesParentObj,player;
        private float _maxRoadDistance = 20;

        private void Start()
        {
            InvokeRepeating(nameof(CheckRoads),2,2);
        }

        private void CheckRoads()
        {
            float z = player.position.z;
            if (z>_maxRoadDistance)
            {
                GameEventManager.Instance.SpawnRoadPiece(_maxRoadDistance+100);
               Destroy(roadPiecesParentObj.GetChild(0).gameObject); 
               _maxRoadDistance += 20;

            }
        }
    }
}