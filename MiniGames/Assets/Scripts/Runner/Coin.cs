using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class Coin : CollectibleActor
    {
        public override void Interact()
        {
            GameEventManager.Instance.CollectGold(10);
            GameEventManager.Instance.SpawnGoldParticle(transform.position);
            Destroy(gameObject);
        }
    }
}