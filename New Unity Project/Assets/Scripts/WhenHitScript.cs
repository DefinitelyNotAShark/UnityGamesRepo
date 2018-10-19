using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WhenHitScript : MonoBehaviour {

    private GameObject paddleObject;

    [SerializeField]
    private Sprite crackedSprite;

    [SerializeField]
    private Sprite crackedTwiceSpriteOne;

    [SerializeField]
    private Sprite crackedTwiceSpriteTwo;


    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;


    Vector3 bigScale;
    Vector3 normalScale;

    private bool cracked = false;
    private int timesCracked = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

        paddleObject = GameObject.Find("Paddle");
        normalScale = new Vector3(2, 2, 2);
        bigScale = new Vector3(3, 2, 2);
    }

    public void HitBlock()
    {
        if (gameObject.CompareTag("Block"))
        {
            Destroy(this.gameObject);
        }

        else if (gameObject.CompareTag("CrackBlock"))
        {
            if (!cracked)
            {
                this.spriteRenderer.sprite = crackedSprite;
                cracked = true;
            }

            else if (cracked)
                Destroy(this.gameObject);
        }

        else if (gameObject.CompareTag("TwiceCrackBlock"))
        {
            switch(timesCracked)
            {
                case 0:
                    this.spriteRenderer.sprite = crackedTwiceSpriteOne;
                    timesCracked++;
                    break;
                case 1:
                    this.spriteRenderer.sprite = crackedTwiceSpriteTwo;
                    timesCracked++;
                    break;
                case 2:
                    Destroy(this.gameObject);
                    break;
            }
        }
        else if (gameObject.CompareTag("PaddleBlock"))
        {
            Debug.Log("This is a powerup!");

            collider.enabled = false;
            spriteRenderer.enabled = false;
            StartCoroutine(PaddlePowerUp());
        }
    }

    IEnumerator PaddlePowerUp()
    {
        paddleObject.transform.localScale = bigScale;
        yield return new WaitForSeconds(8);
        paddleObject.transform.localScale = normalScale;
        Destroy(this.gameObject);
    }
}
