using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField]
    private float laserSpeed;

    [SerializeField]
    Rigidbody bulletRbdy;

    [SerializeField]
    Transform spawnLaser;

    [SerializeField]
    AudioSource laser;

    public int playerNumber = 1;
    private int speedMultiplier = 10;
    private float currentLaunchForce;
    public static  bool ableToFire = true;

    //private GameObject[] robobChildren;// maybe if i need to ignore the collision

    string fireButton;

	// Use this for initialization
	void Start () {
        if (MovePlayer.xboxOneController == 0)
            fireButton = "Fire" + playerNumber;

        else if (MovePlayer.xboxOneController == 1)
            fireButton = "ControllerFire" + playerNumber;

        Physics.IgnoreCollision(bulletRbdy.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(fireButton))//is button pressed?
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (ableToFire)
        {
            laser.Play();
            Rigidbody laserInstance = Instantiate(bulletRbdy, spawnLaser.position, spawnLaser.rotation) as Rigidbody;//its' not this that is being the bitch
            laserInstance.transform.parent = this.gameObject.GetComponentInParent<Transform>();
            laserInstance.transform.Rotate(0, 0, 90);//make sure bullet is rotated to look more like a laser
            laserInstance.velocity = GetComponentInParent<Transform>().forward * laserSpeed * Time.deltaTime * speedMultiplier;
            laserInstance.transform.rotation = Quaternion.identity;
            StartCoroutine(ShootBuffer());
        }
    }

    private IEnumerator ShootBuffer()
    {
        ableToFire = false;
        yield return new WaitForSeconds(.1f);
        ableToFire = true;
    }
}
