using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    float time;
    bool Pause;

    //public static Action onWin;
    //public static Action onLoose;

    public IvHandlerEvent onWin;
    public IvHandlerEvent onLoose;

    private void OnEnable()
    {
        onWin.OnGameCondition += EndGame;
        onLoose.OnGameCondition += EndGame;
    }
    private void OnDisable()
    {
        onWin.OnGameCondition -= EndGame;
        onLoose.OnGameCondition -= EndGame;
    }

    private void Start()
    {
        Pause = false;
        Time.timeScale = 1;
    }
    private void Update()
    {
        UpdateTime();
    }
    private void UpdateTime()
    {
        if (!Pause)
        {
            time += Time.deltaTime; 
        }
    }


    public string GetTime()
    {
        int minutes = Mathf.FloorToInt(time / 60); 
        int seconds = Mathf.FloorToInt(time % 60); 
        return string.Format("{0:00}:{1:00}", minutes, seconds); 
    }
    public void PauseGame(bool Pause)
    {
        if(Pause == true)
        Time.timeScale = 0f;

        else
        Time.timeScale = 1f;

    }
    public void CheckGameStatus()
    {
        Pause = !Pause;
        PauseGame(Pause);
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
    }

}
