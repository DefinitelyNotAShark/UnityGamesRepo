using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawn : MonoBehaviour
{
    //goes on each spawner
    public Vector2 direction;//gets set by the manager

    public float mySpeed;
    private GameObject myHeart;
    private MoveHeart moveHeartScript;

    public void SpawnHearts(GameObject heartPrefab)
    {
        myHeart = heartPrefab;
        Debug.Log(gameObject.name.ToString() + " is trying to make a heart");//delete later
        Instantiate(myHeart, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), this.gameObject.transform.rotation);
        GiveHeartAMovementScript();
    }

    private void GiveHeartAMovementScript()
    {
        moveHeartScript = myHeart.GetComponent<MoveHeart>();

        moveHeartScript.direction = direction;
        moveHeartScript.speed = mySpeed;
    }
}
