using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePacman : MonoBehaviour {

    [SerializeField]
    float speed = 5;

    [SerializeField]
    Vector3 Direction = new Vector3(1, 0, 0);

    public MovePacman()
    {

    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += Direction * speed * Time.deltaTime;
	}
}
