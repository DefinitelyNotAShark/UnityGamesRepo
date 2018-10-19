using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour {

    [SerializeField]
    float rotationSpeed = 1;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        Rotate();
	}

    void Rotate()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
