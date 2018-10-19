using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    [SerializeField]
    LayerMask robobMask;

    [SerializeField]
    float lifeTime = 4.0f;

    [SerializeField]
    float hitRadius = 1f;

    private MovePlayer playerMovement;

    // Use this for initialization
    void Start()
    {//ignore collision between this collider and all its parent colliders
        Collider[] colliders = GetComponentsInParent<Collider>();
        foreach(Collider c in colliders)
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), c);//make sure it ignores colliding with self!
        }
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)//when the laser hits something
    {
        if (other.CompareTag("robot"))//only do this if you hit a robot
        {
            Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();
            Shoot targetStun = targetRigidbody.GetComponent<Shoot>();//finds the stun script on the rigidbody
            playerMovement = targetRigidbody.GetComponent<MovePlayer>();
            playerMovement.stun = true;
        }
    }
}
