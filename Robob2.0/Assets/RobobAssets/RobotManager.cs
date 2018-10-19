using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class RobotManager
{
    public Color playerColor;
    public Color stunColor;
    public Transform robotSpawnPoint;
    public Canvas myCanvas;

    [HideInInspector] public int playerNumber;
    [HideInInspector] public string coloredRobotText;
    [HideInInspector] public GameObject Instance;

    [HideInInspector] public GameObject imageInstance;
    [HideInInspector] public RectTransform rectTransform;

    private MovePlayer playerMovement;
    private Shoot playerShooting;
    private SetUIForPlayers playerUI;
    private PointSystem pointSystem;


    public void Setup()
    {
        playerMovement = Instance.GetComponent<MovePlayer>();
        playerShooting = Instance.GetComponent<Shoot>();
        playerUI = Instance.GetComponent<SetUIForPlayers>();
        pointSystem = Instance.GetComponent<PointSystem>();

        playerMovement.playerNumber = playerNumber;
        playerShooting.playerNumber = playerNumber;
        playerUI.playerNumber = playerNumber;
        pointSystem.playerNumber = playerNumber;//please work!!!
        playerUI.inventoryColor = playerColor;
        playerMovement.playerColor = playerColor;
        playerMovement.stunColor = stunColor;

        coloredRobotText = "<color=#" + ColorUtility.ToHtmlStringRGB(playerColor) + ">player " + playerNumber + "</color>";

        MeshRenderer[] renderers = Instance.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = playerColor;
        }
    }
}
