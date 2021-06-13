using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private Health m_health;
    public Text endTime;

    public GameObject gameWonPanel, gameOverPanel, hudContainer;

    public bool gamePlaying { get; private set; }

    private void Awake()
    {
        instance = this;
        if (m_health != null)
        {
            m_health.OnDeath += OnDeath;
        }
    }
    private void Start()
    {
        gamePlaying = true;
        gameWonPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        hudContainer.SetActive(true);
    }

    public void EndGame()
    {
        gamePlaying = false;
        TimerController.instance.EndTimer();
        Invoke("ShowGameOverScreen", 1.25f);
    }

    private void ShowGameOverScreen()
    {

        gameWonPanel.SetActive(true);
        hudContainer.SetActive(false);
        string endTimeStr = TimerController.instance.timeCounter.text;
        endTime.text = endTimeStr;
        Time.timeScale = 0;
    }
    private void OnDeath()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}
