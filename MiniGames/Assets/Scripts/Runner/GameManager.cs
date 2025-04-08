using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runner
{
    

public class GameManager : MonoBehaviour
{
    private int _score;

    private void Start()
    {
        _score = PlayerPrefs.GetInt("ScoreRunner", 0);
        GameEventManager.Instance.ScoreChangedUI(_score);
    }
   
    private void OnEnable()
    {
        GameEventManager.Instance.OnScoreChanged += AddScore;

        GameEventManager.Instance.OnEndGame += EndGame;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.OnEndGame -= EndGame;
        GameEventManager.Instance.OnScoreChanged -= AddScore;


    }

    private void AddScore(int value)
    {
        _score += value;
        GameEventManager.Instance.ScoreChangedUI(_score);
        PlayerPrefs.SetInt("ScoreRunner", _score);
    }

    private void EndGame()
    {
        Debug.Log("End Game");
    }
}
}