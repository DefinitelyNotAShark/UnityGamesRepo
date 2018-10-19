using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNavigation : MonoBehaviour {

    [SerializeField]
    private AudioSource buttonClick;

    [SerializeField]
    private AudioSource MenuMusic;

    [SerializeField]
    private GameObject playGear;

    [SerializeField]
    private GameObject howToPlayGear;

    [SerializeField]
    private GameObject creditsGear;

    [SerializeField]
    private GameObject exitGear;

    private bool selected;
    private int selectedIndex;
    private float verticalAxisValue;
    private string verticalAxisName;

    private void Start()
    {
        selectedIndex = 0;//only = 0 at the start.
        SetUpVerticalAxes();//this sees whether the player is using a controller or not...
        GetSelectedButton();
        selected = false;
    }

    private bool controllerIsConnected()//checks if player has a controller connected or not
    {//if this returns true, we use controller controls. If not, we use keyboard controls.
        string[] names = Input.GetJoystickNames();

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].Length == 33)//if there are 33 axes, its an xbox controller
            {
                Debug.Log("Xbox 360 or one controller is connected");
                return true;
            }

            else if (names[i].Length == 19)//if there are 19 axes, it's a ps4 controller
            {
                Debug.Log("PS4 Controller is connected");
                return true;
            }
            else
                return false;
        }
        return false;
    }

    void GetSelectedButton()
    {
        while(selected == false)
        {
            Debug.Log("Pause");
            verticalAxisValue = Input.GetAxis(verticalAxisName);
            if (verticalAxisValue > 0)
            {
                MoveSelectedUp();
            }
            else if (verticalAxisValue < 0)
            {
                MoveSelectedDown();
            }
            ActivateSelectedGear();
            Debug.Log("vertical value:" + verticalAxisValue.ToString() + "index: " + selectedIndex.ToString());
        }
    }

    void SetUpVerticalAxes()//get controls
    {
        if (controllerIsConnected())//if we got controller
        {
            //check controller vert index
            verticalAxisName = "ControllerDPads";
        }

        else
            verticalAxisName = "Vertical1";//keyboard up down buttons
    }

    void MoveSelectedUp()//dec index
    {
        if (selectedIndex > 0)//cant be 0
        {
            selectedIndex -= 1;
        }
    }

    void MoveSelectedDown()//inc index
    {
        if (selectedIndex < 4)//cant be 4
        {
            selectedIndex += 1;
        }
    }

    void ActivateSelectedGear()
    {
        switch (selectedIndex)
        {
            case 0://nothing selected
                playGear.SetActive(false);
                howToPlayGear.SetActive(false);
                creditsGear.SetActive(false);
                exitGear.SetActive(false);

                break;
            case 1://play selected
                playGear.SetActive(true);
                howToPlayGear.SetActive(false);
                creditsGear.SetActive(false);
                exitGear.SetActive(false);
                break;
            case 2://how to play selected
                playGear.SetActive(false);
                howToPlayGear.SetActive(true);
                creditsGear.SetActive(false);
                exitGear.SetActive(false);
                break;
            case 3://credits selected
                playGear.SetActive(false);
                howToPlayGear.SetActive(false);
                creditsGear.SetActive(true);
                exitGear.SetActive(false);
                break;
            case 4://exit selected
                playGear.SetActive(false);
                howToPlayGear.SetActive(false);
                creditsGear.SetActive(false);
                exitGear.SetActive(true);
                break;
        }
    }




    public void NewGameButton()
    {
        MenuMusic.Stop();
        buttonClick.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitGameButton()
    {
        MenuMusic.Stop();
        buttonClick.Play();
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void PlayAgain()
    {
        buttonClick.Play();
        SceneManager.LoadScene(0);
    }

    public void HowToPlay()
    {
        buttonClick.Play();
        SceneManager.LoadScene(4);
    }

    public void Back()
    {
        buttonClick.Play();
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        buttonClick.Play();
        SceneManager.LoadScene(5);
    }
}
