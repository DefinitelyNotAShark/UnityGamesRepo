using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruit : MonoBehaviour {

    [SerializeField]
    private List<GameObject> fruitPrefabs;

    private GameObject fruitInstance;
    private GameObject fruitThatNeedsToSpawn;

    private Vector3 worldVector;

    int fruitIndex = 0;
    float fruitXSpawn = 0;

    float spawnRate = 3;
    float rateOverTime = 1;

    private float bufferFloat;

    private void Start()
    {
        worldVector = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));//this works!!!!
        StartCoroutine(Spawn());       
    }

    IEnumerator Spawn()
    {
        for (; ; )
        {
            fruitIndex = Random.Range(0, 3);//picks a number that randomly chooses the type of fruit
            fruitThatNeedsToSpawn = fruitPrefabs[fruitIndex];
            bufferFloat = fruitThatNeedsToSpawn.GetComponent<BoxCollider2D>().size.x;//this works a lot better than calling the renderer bounds!
            fruitXSpawn = Random.Range(-worldVector.x + bufferFloat, worldVector.x - bufferFloat);

            yield return new WaitForSeconds(spawnRate);

            if (spawnRate > 1f)
                spawnRate -= .08f;

            else
                spawnRate = 1f;


            fruitInstance = Instantiate(fruitThatNeedsToSpawn, new Vector2(fruitXSpawn, worldVector.y), transform.rotation);
            fruitInstance.transform.parent = this.gameObject.transform;
            fruitInstance.AddComponent<MoveFruit>();//give the fruit the move script.
            fruitInstance.layer = 1;

            if (fruitInstance.CompareTag("apple"))//enums for days, This is so I can compare the type of fruit to the type of basket
            {
                fruitInstance.GetComponent<MoveFruit>().FState = MoveFruit.FruitState.apple;
            }
            if (fruitInstance.CompareTag("orange"))
            {
                fruitInstance.GetComponent<MoveFruit>().FState = MoveFruit.FruitState.orange;
            }
            if (fruitInstance.CompareTag("banana"))
            {
                fruitInstance.GetComponent<MoveFruit>().FState = MoveFruit.FruitState.banana;
            }
        }
    }
}
