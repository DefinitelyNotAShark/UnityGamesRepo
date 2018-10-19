using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateGearsMenu : MonoBehaviour {

    [SerializeField]
    private Image gear1;
    [SerializeField]
    private Image gear2;

    private float rotateGear1;
    private float rotateGear2;

    private void Start()
    {
        rotateGear1 = 20 * Time.deltaTime;
        rotateGear2 = -50 * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate () {
        UpdateGears();
	}

    private void UpdateGears()
    {
        gear1.transform.Rotate(0, 0, rotateGear1);
        gear2.transform.Rotate(0, 0, rotateGear2);

    }
}
