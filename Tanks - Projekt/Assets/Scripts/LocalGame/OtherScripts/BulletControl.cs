using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controlls the bullets speed when shot
public class BulletControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bulletSpeed;
    public float bulletLifetime = 3;

    //looks for the Rigidbody2D component of the bullet
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //adds force to the bullet gameobject
    void Start()
    {
        rb.AddForce(transform.up * bulletSpeed * 100 * Time.deltaTime);
        Destroy(gameObject, bulletLifetime);
    }
}
