using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleActor : MonoBehaviour,IInteractable
{
    [SerializeField] protected private float rotationSpeed = 90f;
    [SerializeField] private Transform childObj;
    void Update()
    {
        childObj.localRotation *= Quaternion.Euler(Vector3.down * rotationSpeed * Time.deltaTime);
        
    }

    public virtual void Interact() { }
}
