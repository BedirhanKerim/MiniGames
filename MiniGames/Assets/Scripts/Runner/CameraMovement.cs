using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform target; 
        [SerializeField] private float zOffset = -10f; 
        [SerializeField] private float smoothSpeed = 0.125f; 

        void LateUpdate()
        {
            float newX = Mathf.Lerp(transform.position.x, target.position.x, smoothSpeed);

            float newZ = target.position.z + zOffset;

            transform.position = new Vector3(newX, transform.position.y, newZ);
        }
    }
}