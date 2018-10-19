using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GiveOverlordItems : MonoBehaviour {

    enum ItemWantedState {battery, gear, wire};
    public Sprite[] sprites;
    public Image spriteCanvas;
    private ItemWantedState itemState;
    private int itemNum;
    ChangeOverlordColor colorChangeScript;


    [SerializeField]
    private GameObject overlord1;
    [SerializeField]
    private GameObject overlord2;
    [SerializeField]
    private GameObject overlord3;
    [SerializeField]
    private GameObject overlord4;

    private SpawnItems spawn;
    private PlayerInventory playerInventory;
    private PointSystem pointSystem;

    private int overlordItemAmount = 0;
    private int amountTillFirstUpgrade = 2;
    private int amountTillSecondUpgrade = 4;
    private int amountTillThirdUpgrade = 6;

    // Use this for initialization
    void Start () {
        spawn = FindObjectOfType<SpawnItems>();
        colorChangeScript = GetComponent<ChangeOverlordColor>();
        spriteCanvas = GetComponentInChildren<Image>();//this works now!
        spriteCanvas.enabled = false;
        StartCoroutine(BufferTimeBetweenChoosingItems());//wait 1 sec and then show item to get!
	}

    IEnumerator BufferTimeBetweenChoosingItems()
    {
        spriteCanvas.enabled = false;
        yield return new WaitForSeconds(1);
        CheckForOverlordChanges();//check for change after color is shown
        ChooseRandomItem();
        spriteCanvas.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CheckIfItemMatches(collision))//if the player is carrying the right item, change item to ask for 
        {
            overlordItemAmount++;
            StartCoroutine(colorChangeScript.CorrectAnswer());//turn green
            pointSystem.AddPoints(1);
            StartCoroutine(BufferTimeBetweenChoosingItems());
            spawn.GetComponent<SpawnItems>().RespawnItems();//this is still nulllllll!
        }

        else
        {
            StartCoroutine(colorChangeScript.WrongAnswer());//if you give the dude the wrong item, he flash red 
            CheckForOverlordChanges();
        }

        playerInventory.ableToCollectThings = true;//set you to be able to collect things again
        playerInventory.Inventory = PlayerInventory.InventoryState.nothing;//i also need to change the item state back to nothing
    }


    private void ChooseRandomItem()//returns random state
    {
        System.Random r = new System.Random();
        itemNum = r.Next(0, 3);
        switch (itemNum)
        {
            case 0:
                itemState = ItemWantedState.battery;
                spriteCanvas.sprite = sprites[itemNum];
                break;
            case 1:
                itemState = ItemWantedState.gear;
                spriteCanvas.sprite = sprites[itemNum];
                break;
            case 2:
                itemState = ItemWantedState.wire;
                spriteCanvas.sprite = sprites[itemNum];
                break;
        }
    }

    private bool CheckIfItemMatches(Collision collision)
    {
        if (collision.gameObject.tag == "robot")//check if robot has the correct item, if false, flash wrong answer color;;;;
        {
            playerInventory = collision.gameObject.GetComponent<PlayerInventory>();//get the player's robot manager script
            pointSystem = collision.gameObject.GetComponent<PointSystem>();//get the robot's point system script
            if (playerInventory.Inventory.ToString() == itemState.ToString())//compare the strings of each state!
            {
                return true;
            }
        }
        return false;
    }

    private void CheckForOverlordChanges()
    {
        if (overlordItemAmount == amountTillFirstUpgrade)//checks for first upgrade
        {
            ChangeActiveOverlord(false, true, false, false);
            colorChangeScript.GoBackToNormal();
        }

        else if (overlordItemAmount == amountTillSecondUpgrade)//checks for second upgrade
        {
            ChangeActiveOverlord(false, false, true, false);
            colorChangeScript.GoBackToNormal();
        }

        else if (overlordItemAmount == amountTillThirdUpgrade)//checks for second upgrade
        {
            ChangeActiveOverlord(false, false, false, true);
            colorChangeScript.GoBackToNormal();
        }
    }

    private void ChangeActiveOverlord(bool overlord1Active, bool overlord2Active, bool overlord3Active, bool overlord4Active)
    {
        overlord1.SetActive(overlord1Active);
        overlord2.SetActive(overlord2Active);
        overlord3.SetActive(overlord3Active);
        overlord4.SetActive(overlord4Active);
    }
}

