using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour//this new name is UI manager, but I'm lazy because i moved the point var
{
    [SerializeField]
    private Text pointsText;

    [SerializeField]
    private Slider patienceSlider;
    public static int patienceValue = 100;

    // Update is called once per frame
    void FixedUpdate()
    {
        pointsText.text = "Fruit Collected: " + GameData.points.ToString();
        patienceSlider.value = patienceValue;

        CheckForLoseGame();
    }

    private void CheckForLoseGame()
    {
        if(patienceSlider.value <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }


    //at a certain amount of points, an invisible level should increase, increasing the types of fruit that fall.
}
