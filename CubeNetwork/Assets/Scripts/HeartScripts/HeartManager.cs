using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    //General Notes:
    //this is going to go on all the spawn points.
    //it's going to give a move script to each heart (detection script goes on area instead)

    //here is what this script actually needs to do, motherfucker
    //it needs to be 1 script
    //we gon attatch it to an object
    //it's gon take in all the spawners
    //at a fixed or random time (idk yet) we gon spawn hearts from random spawner

    [SerializeField]
    private GameObject leftSpawner;

    [SerializeField]
    private GameObject rightSpawner;

    [SerializeField]
    private GameObject topSpawner;

    [SerializeField]
    private GameObject heartPrefab;

    [SerializeField]
    private float speed;

    //[SerializeField]
    //private MoveHeart moveHeartScript;

    private HeartSpawn leftSpawnScript;
    private HeartSpawn rightSpawnScript;
    private HeartSpawn topSpawnScript;

    private void Awake()
    {
        leftSpawnScript = leftSpawner.GetComponent<HeartSpawn>();
        rightSpawnScript = rightSpawner.GetComponent<HeartSpawn>();
        topSpawnScript = topSpawner.GetComponent<HeartSpawn>();

        leftSpawnScript.direction = Vector2.left;
        rightSpawnScript.direction = Vector2.down;
        topSpawnScript.direction = Vector2.right;
    }

    void Start()
    {
        StartCoroutine(RandomlySpawnHearts());
    }

    IEnumerator RandomlySpawnHearts()
    {
        yield return new WaitForSeconds(2);
        leftSpawnScript.mySpeed = speed;
        leftSpawnScript.SpawnHearts(heartPrefab);//example spawn call to be used at random times to make hearts appear
        yield return new WaitForSeconds(1.5f);
        rightSpawnScript.mySpeed = speed;
        rightSpawnScript.SpawnHearts(heartPrefab);//example spawn call to be used at random times to make hearts appear
        yield return new WaitForSeconds(1);
        topSpawnScript.mySpeed = speed;
        topSpawnScript.SpawnHearts(heartPrefab);//example spawn call to be used at random times to make hearts appear
        yield return new WaitForSeconds(1);
    }
}
