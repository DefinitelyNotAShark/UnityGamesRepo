using UnityEngine;
using System.Collections;

public class BallCollision : MonoBehaviour
{
    private BallController moveBall;

    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private ScoreManager sm;
    private bool reflected;

    void Awake()
    {
        Util.GetComponentIfNull(this, ref spriteRenderer);
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    { 
        moveBall = this.GetComponent<BallController>();
        if (moveBall == null)
        {
            moveBall = gameObject.AddComponent<BallController>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        reflected = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            if (moveBall.Direction.y > 0) { }
                //this is so you can't dribble the ball under the paddle

            else
                moveBall.Direction.y *= -1;
        }


        if (coll.gameObject.GetComponent<WhenHitScript>() != null)//if it has a when hit script...
        {
            ReflectBall(coll);
            coll.gameObject.GetComponent<WhenHitScript>().HitBlock();//reflect and then call the script...
        }
    }//end on collision 2D

    void ReflectBall(Collision2D coll)
    {
        Vector3 dir = (coll.gameObject.transform.position - gameObject.transform.position).normalized;
        if (Mathf.Abs(dir.y) < 0.01f)
        {
            if (dir.x > 0)
            {
                if (!reflected)
                {
                    Debug.Log("RIGHT");
                    this.moveBall.RelfectX();
                    reflected = true;
                }
            }
            else if (dir.x < 0)
            {
                if (!reflected)
                {
                    Debug.Log("LEFT");
                    this.moveBall.RelfectX();
                    reflected = true;
                }
            }
        }
        else
        {
            if (dir.y > 0)
            {
                if (!reflected)
                {
                    Debug.Log("TOP");
                    this.moveBall.RelfectY();
                    reflected = true;
                }
            }
            else if (dir.y < 0)
            {
                if (!reflected)
                {
                    Debug.Log("BOTTOM");
                    this.moveBall.RelfectY();
                    reflected = true;
                }
            }
        }
    }
}
