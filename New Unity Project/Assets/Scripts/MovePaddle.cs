using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour {

    public Vector2 Direction;
    public float Speed;

    private Vector3 moveTranslation;
    private float halfSize;
    private Rigidbody2D rb2D;
    SpriteRenderer spriteRenderer;
    PlayerController playerController;

    Vector3 worldVector;

    void Awake()
    {
        Util.GetComponentIfNull(this, ref spriteRenderer);
        rb2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            playerController = this.gameObject.AddComponent<PlayerController>();
        }

        worldVector = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
        halfSize = spriteRenderer.bounds.size.x / 2;        
    }

    void Update()
    {

        if (playerController.IsKeyDown)
        {
            this.Direction = playerController.direction;
        }
        else
        {
            this.Direction = Vector3.zero;
        }

        if (rb2D != null)//better keep on screen!
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,
                0 - worldVector.x + halfSize, worldVector.x - halfSize),
                transform.position.y);
        }
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + Direction * Speed * Time.fixedDeltaTime);
    }
}
