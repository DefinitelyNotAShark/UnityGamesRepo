using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUIForPlayers : MonoBehaviour {

    private GameObject imagePanel;
    private PlayerInventory playerInventory;

    public int playerNumber = 1;
    public Color inventoryColor;
    public Color fullColor;

    private Image[] images;
    private Image image;

    private float alphaInt = 1;

    // Use this for initialization
    void Start ()
    {
        fullColor = Color.white;
        playerInventory = GetComponent<PlayerInventory>();
        imagePanel = GameObject.Find("InventoryIcon" + playerNumber);

        images = imagePanel.GetComponentsInChildren<Image>();
        foreach (Image i in images)
        {
            if (i.gameObject.name == ("PanelImage"))
            {
                alphaInt = 1;
                fullColor.a = alphaInt;//set int to temp color
                i.color = fullColor;
                image = i;
            }

            alphaInt -= .1f;
            //also set color of everything  
            Color tempColor = inventoryColor;
            tempColor.a = alphaInt;//set int to temp color
            i.color = tempColor;//this works but the alpha doesn't show!!!!!

        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        CheckClearInventoryUI();
	}

    public void CheckClearInventoryUI()//only for one player check player!!!
    {
        if (playerInventory.Inventory == PlayerInventory.InventoryState.nothing)
        {
            image.enabled = false;
        }
    }

    public void ChangeImageToItem(Sprite imageSprite)
    {
        Debug.Log("This is player " + playerNumber);
        image.enabled = true;//set image to true
        image.sprite = imageSprite;//change sprite to item collected
    }
}
