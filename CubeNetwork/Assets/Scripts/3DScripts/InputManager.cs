using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static int PS4_Controller = 0;
    public static int Xbox_One_Controller = 0;

    public static bool controllerIsConnected = false;

    public static string squareFireButton;
    public static string circleFireButton;

    // Use this for initialization
    void Awake ()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            print(names[x].Length);
            if (names[x].Length == 19)
            {
                Debug.Log("PS4 CONTROLLER IS CONNECTED");
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
                controllerIsConnected = true;
            }
            if (names[x].Length == 33)
            {
                Debug.Log("XBOX ONE CONTROLLER IS CONNECTED");
                //set a controller bool to true
                PS4_Controller = 0;
                Xbox_One_Controller = 1;
                controllerIsConnected = true;
            }
        }
        if (controllerIsConnected == true)
        {

            if (Xbox_One_Controller == 1)
            {
                squareFireButton = "XBoxOneControllerSquareFire";
                circleFireButton = "XBoxOneControllerCircleFire";
            }
            else if (PS4_Controller == 1)
            {

                squareFireButton = "PS4ControllerSquareFire";
                circleFireButton = "PS4ControllerCircleFire";
            }
        }
    }
}
