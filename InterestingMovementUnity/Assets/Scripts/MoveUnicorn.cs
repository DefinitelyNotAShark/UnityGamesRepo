using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnicorn : MonoBehaviour {

    [SerializeField]
    float speed;

    [SerializeField]
    float turnSpeed;

    private float moveAxis;
    private float turnAxis;
    private float movementInput;
    private float turnInput;
    private float turn;
    private float horizontalInput;
    private float verticalInput;
    private float angle;

    float movement;


    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Turn()
    {
        turnInput = Input.GetAxis("Horizontal");
        Debug.Log("trying to turn");
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * turnSpeed * -Time.smoothDeltaTime);
    }

    private void Move()
    {
         
        movementInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Debug.Log("trying to move");
        transform.Translate(0, movementInput, 0);

    }


    //failed code

        //if (verticalInput > 0)
        //{
        //    canGetSmall = true;
        //}
        //else
        //    canGetSmall = false;

        //if (verticalInput < 0)
        //{
        //    canGetBig = true;
        //}
        //else
        //    canGetBig = false;
    //void SetVarsToScale()
    //{
    //    if (verticalInput > 0)
    //    {
    //        StartCoroutine(Shrink());
    //    }

    //    if (verticalInput < 0)
    //    {
    //        StartCoroutine(Grow());
    //    }
    //}

    //IEnumerator Shrink()
    //{
    //    while (transform.position.y < maxHeight && canGetSmall && transform.localScale.x > smallest)
    //    {
    //        Debug.Log("Supposed to shrink");
    //        yield return new WaitForSeconds(.5f);
    //        transform.localScale -= new Vector3(scaleBy, scaleBy, 0);
    //    }
    //}

    //IEnumerator Grow()
    //{
    //    while (transform.position.y > minHeight && canGetBig && transform.localScale.x < biggest)
    //    {
    //        Debug.Log("Supposed to grow");
    //        yield return new WaitForSeconds(.5f);
    //        transform.localScale += new Vector3(scaleBy, scaleBy, 0);
    //    }
    //}
}
