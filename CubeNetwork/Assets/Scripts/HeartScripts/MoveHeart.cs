using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHeart : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("My heart's direction is " + direction.ToString());
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
	}

    private void Move()
    {
        this.gameObject.transform.Translate(direction * speed * Time.deltaTime);
    }
}
