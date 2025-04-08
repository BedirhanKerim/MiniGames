using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runner
{
    

public class GameManagerRunner : MonoBehaviour
{
    private int _score;
    [SerializeField] private TextMeshProUGUI scoreText;


    private void Start()
    {
        _score = PlayerPrefs.GetInt("ScoreRunner", 0);
        scoreText.text = _score.ToString();
    }

    private void OnEnable()
    {
        GameEventManager.Instance.OnCollectGold += AddScore;
        GameEventManager.Instance.OnEndGame += EndGame;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.OnCollectGold -= AddScore;
        GameEventManager.Instance.OnEndGame -= EndGame;

    }

    private void AddScore(int value)
    {
        _score += value;
        scoreText.text = _score.ToString();
        PlayerPrefs.SetInt("ScoreRunner", _score);
    }

    private void EndGame()
    {
        Debug.Log("End Game");
    }
}
}