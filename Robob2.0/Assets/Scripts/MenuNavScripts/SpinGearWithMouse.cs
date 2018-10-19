using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinGearWithMouse : MonoBehaviour
{
    [SerializeField]
    private float normalRotateSpeed;

    [SerializeField]
    private float mouseOverRotateSpeed;

    [SerializeField]
    private float mouseClickedRotateSpeed;

    private bool mouseIsOver;
    private bool mouseClicked;

    private void Update()
    {
        if(mouseClicked)
            this.gameObject.transform.Rotate(0, 0, mouseClickedRotateSpeed * Time.deltaTime);

        if (mouseIsOver)
            this.gameObject.transform.Rotate(0, 0, mouseOverRotateSpeed * Time.deltaTime);

        else
            this.gameObject.transform.Rotate(0, 0, normalRotateSpeed * Time.deltaTime);
    }

    public void MouseOverMove()
    {
        mouseIsOver = true;
    }

    public void NoMouseOverMove()
    {
        mouseIsOver = false;
    }

    public void MouseClickedMove()
    {
        mouseClicked = true;
    }

    public void MouseNotClicked()
    {
        mouseClicked = false;
    }
}
