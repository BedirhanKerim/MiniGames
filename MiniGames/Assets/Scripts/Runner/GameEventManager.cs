using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Runner
{
    public class GameEventManager : Singleton<GameEventManager>,IGameEventManager
    {
        public event UnityAction<int> OnScoreChanged;
        public event UnityAction<int> OnScoreChangedUI;
        public event UnityAction<Vector3> OnSpawnGoldParticle;
        public event UnityAction OnEndGame;

        public event UnityAction<float> OnSpawnRoadPiece;

        public  void ScoreChanged(int arg0)
        {
            OnScoreChanged?.Invoke(arg0);
        }
        public  void ScoreChangedUI(int arg0)
        {
            OnScoreChangedUI?.Invoke(arg0);
        }
        public  void SpawnGoldParticle(Vector3 arg0)
        {
            OnSpawnGoldParticle?.Invoke(arg0);
        }

        public  void EndGame()
        {
            OnEndGame?.Invoke();
            Time.timeScale = 0;

        }

        public  void SpawnRoadPiece(float arg0)
        {
            OnSpawnRoadPiece?.Invoke(arg0);
        }
    }
}