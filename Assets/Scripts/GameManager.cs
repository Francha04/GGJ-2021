using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager _instance;
    public int amountOfErrors;
    private int errorsTolerance = 10;
    public bool playerLostTheGame;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }

        playerLostTheGame = false;
    }

    public bool CheckIfPlayerLostTheGame()
    {
        return amountOfErrors >= errorsTolerance;
    }

    public void ResetStats()
    {
        amountOfErrors = 0;
        playerLostTheGame = false;
    }

    private void Update()
    {
        playerLostTheGame = CheckIfPlayerLostTheGame();

        if(playerLostTheGame)
        {
            //Cargar escena final ?
            Debug.Log("Perdiste");
        }
    }
}
