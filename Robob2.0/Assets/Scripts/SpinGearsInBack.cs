using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinGearsInBack : MonoBehaviour
{
    private enum Rotation
    {
        left, right
    }

    [SerializeField]
    private float gearSpeed;

    [SerializeField]
    private Rotation myRotation;

    private void Start()
    {
        if (myRotation == Rotation.right)
            gearSpeed = gearSpeed * -1;

    }

    void Update ()
    {
        transform.Rotate(new Vector3(0, 0, gearSpeed * Time.deltaTime));
	}
}
