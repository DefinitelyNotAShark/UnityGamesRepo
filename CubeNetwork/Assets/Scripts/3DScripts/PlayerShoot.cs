using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    InputManager input;

    [SerializeField]
    private float laserSpeed;

    [SerializeField]
    Rigidbody squareBulletRbdy;

    [SerializeField]
    Rigidbody circleBulletRbdy;

    [SerializeField]
    Transform spawnLaser;

    private int speedMultiplier = 10;
    private float currentLaunchForce;
    public static bool ableToFire = true;

    private void Awake()
    {
        input = GetComponent<InputManager>();
    }

    void Start()
    {
            Physics.IgnoreCollision(circleBulletRbdy.GetComponent<Collider>(), GetComponent<Collider>());
            Physics.IgnoreCollision(squareBulletRbdy.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void Update()
    {
        if (Input.GetButtonDown(InputManager.squareFireButton))//is button pressed?
        {
            Fire(squareBulletRbdy);
        }
        if (Input.GetButtonDown(InputManager.circleFireButton))
        {
            Fire(circleBulletRbdy);
        }
    }


    private void Fire(Rigidbody rigidbody)
    {
        if (ableToFire)
        {
            Rigidbody laserInstance = Instantiate(rigidbody, spawnLaser.position, spawnLaser.rotation) as Rigidbody;//its' not this that is being the bitch
            laserInstance.transform.parent = this.gameObject.GetComponentInParent<Transform>();
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
