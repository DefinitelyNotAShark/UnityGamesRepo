using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCollisions : MonoBehaviour
{
    private SpriteRenderer renderer;
    private Color pink;
    private Color invisible;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        pink = new Color32(255, 117, 236, 255);
        invisible = new Color32(0, 0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)//whenever our heart runs into anything
    {
        if (collision.tag == "goodZone")
        {
            renderer.color = pink;           
        }
        if (collision.tag == "perfectZone")
        {
            Debug.Log("PERFECT ZONE");
        }
        //then see if we click
        //and if we click, see what part the heart was over
        //also detect if we clicked without collision
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "goodZone")
        {
            renderer.color = invisible;
            //remember to take away points here
        }
    }

}
