using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    [SerializeField]
    private GameObject paddle;

    public Vector2 Direction;
    public float Speed;

    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;

    public Text debugText;

    private float randomReflectInt;

    private Vector3 worldVector;


    void Awake()
    {
        Util.GetComponentIfNull(this, ref spriteRenderer);
        rb2D = GetComponent<Rigidbody2D>();
        worldVector = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
    }

    void FixedUpdate()
    {
        if (rb2D != null)
        {
            //Keep on screen
            this.rb2D.position = Util.BounceOffWalls(this.transform.position,
                spriteRenderer.bounds.size.x - 1,
                spriteRenderer.bounds.size.y - 1, ref this.Direction);
        }

        rb2D.MovePosition(rb2D.position + Direction * Speed * Time.fixedDeltaTime);
    }

    public void RelfectY()
    {
        UpdateBallCollisionRandom();
    }

    public void RelfectX()
    {
        this.Direction.x *= -1;
    }

    public void UpdateBallCollisionRandom()
    {
        this.Direction.y = GetReflectEntropy();
    }

    private float GetReflectEntropy()
    {
        return -1 + ((Random.Range(0, 4) - 1) * 0.1f);
    }
}
