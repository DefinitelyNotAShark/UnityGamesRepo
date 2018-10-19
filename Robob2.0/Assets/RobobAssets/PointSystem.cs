using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointSystem : MonoBehaviour {

    [HideInInspector]
    public int points = 0;

    [HideInInspector]
    public int amountOfPointsTillWin = 8;

    public int playerNumber = 0;

    private void Update()
    {
        CheckIfWin();
    }

    public bool CheckIfUpgrade(int pointAmount)
    {
        if (points == pointAmount)
        {
            return true;
        }
        else return false;
    }
    public void AddPoints(int pointAmount)
    {
        points += pointAmount;
    }

    private void CheckIfWin()
    {
        if (points == amountOfPointsTillWin)
        {
            //check player number//if player number is one, get first win screen. If number is 2 get second win screen
            SceneManager.LoadScene("WinScene" + playerNumber);
        }
    }
}
