using System;
using System.Collections;
using System.Collections.Generic;
using Runner;
using UnityEngine;

namespace Runner
{
    public class Spikes : Obstacle
    {
        public override void Interact()
        {
            GameEventManager.Instance.EndGame();
        }
    }
}