using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetForestSize : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    Vector2 enchantedForestSize;
    float xBounds;
    float yBounds;

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enchantedForestSize = spriteRenderer.bounds.size;
        yBounds = enchantedForestSize.y;
        xBounds = enchantedForestSize.x;
    }
}
