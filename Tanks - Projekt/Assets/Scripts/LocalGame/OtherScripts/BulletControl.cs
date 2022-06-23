using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controlls the bullets speed when shot
public class BulletControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float _bulletSpeed;
    public float bulletLifetime = 3;

    //looks for the Rigidbody2D component of the bullet
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveBullet(_bulletSpeed);
    }

    //adds force to the bullet gameobject
    public void MoveBullet(float bulletSpeed)
    {
        rb.AddForce(transform.up * bulletSpeed * 100 * Time.deltaTime);
        Destroy(gameObject, bulletLifetime);
    }
}
