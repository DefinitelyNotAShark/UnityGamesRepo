
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 4.0f;

    [SerializeField]
    float hitRadius = 1f;

    private MovePlayer playerMovement;

    void Start()
    {//ignore collision between this collider and all its parent colliders
        Collider[] colliders = GetComponentsInParent<Collider>();

        foreach (Collider c in colliders)
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), c);//make sure it ignores colliding with self!
        }
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);//this might not trigger the other collision trigger
    }
}