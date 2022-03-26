using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bulletSpeed;
    public float bulletLifetime = 3;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.AddForce(transform.up * bulletSpeed * 100 * Time.deltaTime);
        Destroy(gameObject, bulletLifetime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            Destroy(this.gameObject);
            col.gameObject.SetActive(false);
            PlayerSpawner.shouldSpawn = true;
        }
    }
}
