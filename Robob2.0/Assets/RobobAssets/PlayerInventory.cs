using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector]
    public enum InventoryState { nothing, battery, gear, wire, };//set a state for whatever the player has in their inventory

    private InventoryState inventory;
    [HideInInspector]
    public InventoryState Inventory { get { return inventory; } set { inventory = value; } }

    [HideInInspector]
    public bool ableToCollectThings;

    void Start()
    {
        ableToCollectThings = true;
        inventory = InventoryState.nothing;
    }
}
