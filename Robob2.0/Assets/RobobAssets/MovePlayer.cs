using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField]
    public int playerNumber = 1;

    [SerializeField]
    private float speed = 12f;

    [SerializeField]
    public float turnSpeed = 180f;

    [SerializeField]
    private AudioSource stunSound;

    private string movementAxisName;
    private string turnAxisName;
    private Rigidbody rigidbody;
    private float movementInputValue;
    private float turnInputValue;
    public static int xboxOneController = 0;

    public bool stun = false;
    private bool stunPlayed = false;

    public Color playerColor;
    public Color stunColor;

    private MeshRenderer[] renderers;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();//dont split up turn and move. Have it turn BASED ON MOVE
    }
    // Use this for initialization
    void Start()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();

        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length == 33)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                xboxOneController = 1;
            }
        }

        if (xboxOneController == 1)
        {
            movementAxisName = "ControllerVertical" + playerNumber;
            turnAxisName = "ControllerHorizontal" + playerNumber;
        }
        else
        {
            movementAxisName = "Vertical" + playerNumber;
            turnAxisName = "Horizontal" + playerNumber;
        }

    }

    // Update is called once per frame
    void Update()
    {
        movementInputValue = Input.GetAxis(movementAxisName);//stores my input
        turnInputValue = Input.GetAxis(turnAxisName);
    }

    private void FixedUpdate()
    {
        if (!stun)
        {
            Move();

            if (xboxOneController == 0)//only do turn if the controller isn't connected
                Turn();
        }

        if (stun)//check if you should be stunned
        {
            if (!stunPlayed)
            {
                stunSound.Play();
                stunPlayed = true;
            }
            StartCoroutine(Stun());//and then stun you
        }
    }

    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
    }

    private void Move()
    {
        if (xboxOneController == 0)
        {
            Vector3 movement = transform.forward * movementInputValue * speed * Time.deltaTime;//sets a vector3 to forward times input value
            rigidbody.MovePosition(rigidbody.position + movement);//moves my rigidbody the vector3
        }

        else if (xboxOneController == 1)
        {
            Vector3 movement = new Vector3(turnInputValue, 0, movementInputValue);//this should move normally

            //All i have to do now is get the robot to turn the direction it's moving in
            transform.rotation = Quaternion.LookRotation(movement);
            rigidbody.MovePosition(rigidbody.position + movement * speed * Time.deltaTime);//i really hope this moves normally.
        }
    }

    public IEnumerator Stun()
    {
        ChangePlayerColor(stunColor);
        yield return new WaitForSeconds(2);
        ChangePlayerColor(playerColor);
        stun = false;
        stunPlayed = false;
    }

    public void ChangePlayerColor(Color thisColor)
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = thisColor;
        }
    }
}
