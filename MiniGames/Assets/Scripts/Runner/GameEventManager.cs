using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Runner
{
    public class GameEventManager : Singleton<GameEventManager>
    {
        public event UnityAction<int> OnCollectGold;
        public event UnityAction<Vector3> OnSpawnGoldParticle;
        public event UnityAction OnEndGame;
        public event UnityAction<float> OnSpawnRoadPiece;

        public  void CollectGold(int arg0)
        {
            OnCollectGold?.Invoke(arg0);
        }

        public  void SpawnGoldParticle(Vector3 arg0)
        {
            OnSpawnGoldParticle?.Invoke(arg0);
        }

        public  void EndGame()
        {
            OnEndGame?.Invoke();
        }

        public  void SpawnRoadPiece(float arg0)
        {
            OnSpawnRoadPiece?.Invoke(arg0);
        }
    }
}