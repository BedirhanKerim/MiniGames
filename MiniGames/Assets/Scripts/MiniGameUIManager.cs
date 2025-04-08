using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button reloadButton, backToMenuButton, settingsButton, resumeSettingsButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Start()
    {
        reloadButton.onClick.AddListener(ReloadButton);
        backToMenuButton.onClick.AddListener(BackToMenuButton);
        settingsButton.onClick.AddListener(SettingsButton);
        resumeSettingsButton.onClick.AddListener(ResumeSettingsButton);
        GameObject gameEventManagerObject = GameObject.Find("GameEventManager");
        if (gameEventManagerObject != null)
        {
            IGameEventManager gameEventManager = gameEventManagerObject.GetComponent<IGameEventManager>();
            gameEventManager.OnEndGame += SettingsButton;
            gameEventManager.OnScoreChangedUI+=UpdateScoreText;
        }
    }

    private void ReloadButton()
    {
        Time.timeScale = 1;
        SceneLoader.Instance.Reload();
    }

    private void BackToMenuButton()
    {      
        Time.timeScale = 1;
        SceneLoader.Instance.BackToMenu();
    }

    private void SettingsButton()
    {
        settingsPanel.SetActive(true);

    }
    private void ResumeSettingsButton()
    {
        settingsPanel.SetActive(false);

    }

    private void UpdateScoreText(int value)
    {
        scoreText.text = value.ToString();
    }

}
