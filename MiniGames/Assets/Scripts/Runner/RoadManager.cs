using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class RoadManager : MonoBehaviour
    {
        [SerializeField] private Transform roadPiecesParentObj,player,roadBgPiecesMainObj;
        private float _maxRoadDistance = 20;

        private void Start()
        {
            InvokeRepeating(nameof(CheckRoads),2,2);
            InvokeRepeating(nameof(CheckBgPieces),5,5);

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

        private void CheckBgPieces()
        {
            for (int i = 0; i < roadBgPiecesMainObj.childCount; i++)
            {
                Transform bgPiece = roadBgPiecesMainObj.GetChild(i);
                Vector3 position = bgPiece.position;

                if (player.position.z - 100 > position.z)
                {
                    position.z += 550;
                    bgPiece.position = position;
                }
            }
        }
    }
}