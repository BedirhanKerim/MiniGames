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
        [SerializeField] private TextMeshProUGUI scoreText;


        private void Start()
        {
            GameEventManager.Instance.OnScoreChanged += AddScore;
             _score = PlayerPrefs.GetInt("Score", 0);
            scoreText.text = _score.ToString();
        }

        private void AddScore(int value)
        {
            _score += value;
            scoreText.text = _score.ToString();
            PlayerPrefs.SetInt("Score", _score);
        }
    }
}