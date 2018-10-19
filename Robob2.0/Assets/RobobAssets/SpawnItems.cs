using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField]
    private GameObject batteryPrefab;
    [SerializeField]
    private GameObject gearPrefab;
    [SerializeField]
    private GameObject wirePrefab;

    private List<Transform> wireSpawnPoints;
    private List<Transform> gearSpawnPoints;
    private List<Transform> batterySpawnPoints;

    [HideInInspector]
    public List<GameObject> objectsToDestroy;

    private Transform wireSpawnPoint;
    private Transform gearSpawnPoint;
    private Transform batterySpawnPoint;

    private GameObject batteryObject;
    private GameObject gearObject;
    private GameObject wireObject;

    private void Start()
    {
        wireSpawnPoints = new List<Transform>();
        gearSpawnPoints = new List<Transform>();
        batterySpawnPoints = new List<Transform>();
        objectsToDestroy = new List<GameObject>();

        AddSpawnPoints();//adds spawn points to the list
        PickRandomSpawnPoints();
        SpawnAtRandomPoint(wireSpawnPoint, gearSpawnPoint, batterySpawnPoint);
    }

    void AddSpawnPoints()
    {
        foreach(Transform child in transform)
        {
            if (child.CompareTag("wire"))//if the game object is tagged with wire
                wireSpawnPoints.Add(child);//add it to wirespawn points

            if (child.CompareTag("battery"))//if the game object is tagged with battery
                batterySpawnPoints.Add(child);//add it to wirespawn points

            if (child.CompareTag("gear"))//if the game object is tagged with gear
                gearSpawnPoints.Add(child);//add it to wirespawn points
        }
    }

    public void SpawnAtRandomPoint(Transform wire, Transform gear, Transform battery)//spawn items and add to list of objects created
    {
        wireObject = (Instantiate(wirePrefab, wire.position, wire.rotation) as GameObject);//make the object and set it to ref to gameObject
        wireObject.transform.parent = wireSpawnPoint.transform;//set the object's transform to the spawn point
        objectsToDestroy.Add(wireObject);//add object to list of objects to destroy

        gearObject = (Instantiate(gearPrefab, gear.position, gear.rotation) as GameObject);//do the same to the rest
        gearObject.transform.parent = gearSpawnPoint.transform;
        objectsToDestroy.Add(gearObject);

        batteryObject = (Instantiate(batteryPrefab, battery.position, battery.rotation) as GameObject);
        batteryObject.transform.parent = batterySpawnPoint.transform;
        objectsToDestroy.Add(batteryObject);
    }

    void PickRandomSpawnForWire()
    {
        int wireInt = UnityEngine.Random.Range(0, 3);
        wireSpawnPoint = wireSpawnPoints[wireInt];
    }

    void PickRandomSpawnForGear()
    {
        int gearInt = UnityEngine.Random.Range(0, 3);
        gearSpawnPoint = gearSpawnPoints[gearInt];
    }

    void PickRandomSpawnForBattery()
    {
        int batteryInt = UnityEngine.Random.Range(0, 3);
        batterySpawnPoint = batterySpawnPoints[batteryInt];
    }

    public void PickRandomSpawnPoints()
    {
        PickRandomSpawnForWire();//get all them spawn points
        PickRandomSpawnForBattery();
        PickRandomSpawnForGear();
    }

    public void RespawnItems()
    {
        foreach (GameObject g in objectsToDestroy)
        {
            Destroy(g);
        }
        PickRandomSpawnPoints();
        SpawnAtRandomPoint(wireSpawnPoint, gearSpawnPoint, batterySpawnPoint);
    }
}
