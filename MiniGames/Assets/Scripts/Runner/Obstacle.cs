using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class Obstacle : MonoBehaviour,IInteractable
    {
        public virtual void Interact() { }
    }
}