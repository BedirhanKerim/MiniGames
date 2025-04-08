using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Match3Game
{
    public class GameManager : Singleton<GameManager>
    {
        private int _score;
        private void OnEnable()
        {
            GameEventManager.Instance.OnScoreChanged += AddScore;

        }

        private void OnDisable()
        {
            GameEventManager.Instance.OnScoreChanged -= AddScore;


        }
        private void Start()
        {
             _score = PlayerPrefs.GetInt("Score", 0);
             GameEventManager.Instance.ScoreChangedUI(_score);
        }

        private void AddScore(int value)
        {
            _score += value;
            GameEventManager.Instance.ScoreChangedUI(_score);
            PlayerPrefs.SetInt("Score", _score);
        }
    }
}