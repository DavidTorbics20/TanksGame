using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool nextRoundB;

    public PlayerSpawner playerSpawner;
    public GameObject bullet;
    public GameObject bulletStart;
    public Rigidbody2D rb;

    public float speed = 17.5f;
    public float rotatSpeed = 180.0f;
    private float timeBTWAtatck;
    public float startTimeBTWAttack = 2.0f;

    void Update()
    {
        if (Input.GetKey("w"))
        {
            //x = speed * Time.deltaTime;
            //rb.MovePosition(transform.position + Vector3.up * speed);
            transform.position += transform.up * Time.deltaTime * speed / 10;
        }
        if (Input.GetKey("s"))
        {
            //x = speed * Time.deltaTime;
            //rb.MovePosition(transform.position + transform.up * Time.deltaTime * -speed);
            transform.position -= transform.up * Time.deltaTime * speed / 10;
        }
        if (Input.GetKey("a"))
        {
            rb.rotation += rotatSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            rb.rotation -= rotatSpeed * Time.deltaTime;
        }

        if (timeBTWAtatck <= 0)
        {
            if (Input.GetKey("c"))
            {
                Instantiate(bullet, bulletStart.transform.position, bulletStart.transform.rotation);
                timeBTWAtatck = startTimeBTWAttack;
            }
        }
        else
        {
            timeBTWAtatck -= Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //when player dies make its model explode and not destroy the gameobject
    
        if (col.gameObject.tag == "Bullet")
        {
            nextRoundB = true;
            PlayerTwoScore.scoreValue += 1;
        }
    }
}
