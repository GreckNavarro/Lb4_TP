using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text Life;
    [SerializeField] private Text Coins;
    [SerializeField] private Text Time;
    [SerializeField] private GameObject WinCanvas;
    [SerializeField] private Text winText;
    [SerializeField] private GameObject LooseCanvas;
    [SerializeField] private Text looseText;

    [SerializeField] private GameManager GM;

    [SerializeField] HandlerEvents UpdateEventSO;
    [SerializeField] HandlerEvents UpdateHealthSO;

    public IvHandlerEvent onWin;
    public IvHandlerEvent onLoose;

    private void OnEnable()
    {

        UpdateHealthSO.eventScriptableObject += UpdateLife;
        UpdateEventSO.eventScriptableObject += UpdateCoins;

        //Modificar
        onWin.OnGameCondition += ActiveWin;
        onLoose.OnGameCondition += ActiveLoose;
    }

    private void OnDisable()
    {
        UpdateHealthSO.eventScriptableObject -= UpdateLife;
        UpdateEventSO.eventScriptableObject -= UpdateCoins;


        //Modificar
        onWin.OnGameCondition -= ActiveWin;
        onLoose.OnGameCondition -= ActiveLoose;
    }


    public void UpdateLife(int number)
    {
        Life.text = number.ToString();
    }

    public void UpdateCoins(int number)
    {
        Coins.text = number.ToString();
    }

    private void UpdateTime()
    {
        Time.text = GM.GetTime();
    }
    void ActiveWin()
    {
        WinCanvas.SetActive(true);
        winText.text = GM.GetTime();
    }
    void ActiveLoose()
    {
        LooseCanvas.SetActive(true);
        looseText.text = GM.GetTime();
    }
    private void Update()
    {
        UpdateTime();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("MainGame");
    }


}
