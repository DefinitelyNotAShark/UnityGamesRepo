using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFruit : MonoBehaviour
{

    private float yPosition;
    private float yPixelPosition;

    private float pixelSpeed = .7f;

    private float positionToDestroy;

    public float speed = .05f;
    public bool usePixelMovement = false;
    public bool useNormalMovement = true;

    public enum FruitState { apple, orange, banana }
    public FruitState FState;

    private void Start()
    {
        positionToDestroy = -1 * (Camera.main.orthographicSize * 2);//this is the bottom of the screen!
    }

    public void ToggleMovementType()
    {
        if (usePixelMovement)
        {
            StartCoroutine(PixelMove());
            useNormalMovement = false;
        }
        else
        {
            StopCoroutine(PixelMove());
            useNormalMovement = true;
        }
    }

    private void Update()
    {
        CheckIfDestroy();
    }

    private void FixedUpdate()
    {
        if (useNormalMovement)
            Move();
    }
    IEnumerator PixelMove()
    {
        for (; ; )
        {
            transform.Translate(new Vector2(0, yPixelPosition));
            yield return new WaitForSeconds(.5f);
            yPixelPosition -= (pixelSpeed * Time.deltaTime);
        }
    }

    void Move()
    {
        transform.Translate(new Vector2(0, yPosition));
        yPosition -= (speed * Time.deltaTime / 3);
    }

    void CheckIfDestroy()
    {
        if (transform.position.y <= positionToDestroy)
        {
            Destroy(this.gameObject);
            PointManager.patienceValue -= 10;
        }
    }
}
