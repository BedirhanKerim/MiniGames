using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class Coin : CollectibleActor
    {
        public override void Interact()
        {
            GameEventManager.Instance.ScoreChanged(10);
            GameEventManager.Instance.SpawnGoldParticle(transform.position);
            Destroy(gameObject);
        }
    }
}