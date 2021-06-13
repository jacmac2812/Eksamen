using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadBTN : MonoBehaviour
{
    public int timeRemaining;
    public Text timeText;

    void Start()
    {
        timeText.gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        timeText.gameObject.SetActive(true);
        StartCoroutine(CountDownToStart(sceneName));
    }

    IEnumerator CountDownToStart(string sceneName)
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        while (timeRemaining > 0)
        {
            timeText.text = timeRemaining.ToString();
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }
        timeText.text = "0";
        SceneManager.LoadScene(sceneName);
    }
}
