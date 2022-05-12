using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    //public PlayerSpawner playerSpawner;
    public Camera camera;
    public GameObject bullet;
    public GameObject bulletStart;
    public Rigidbody2D rb;

    public float speed = 17.5f;
    public float rotatSpeed = 200.0f;
    private float timeBTWAtatck;
    public float startTimeBTWAttack = 2.0f;

    public override void OnStartLocalPlayer()
    {
        camera = gameObject.AddComponent<Camera>();
        Camera.main.orthographic = false;
        Camera.main.transform.SetParent(transform);
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKey("w"))
            {
                //x = speed * Time.deltaTime;
                //rb.MovePosition(transform.position + Vector3.up * speed);
                this.transform.position += transform.up * Time.deltaTime * speed / 10;
            }
            if (Input.GetKey("s"))
            {
                //x = speed * Time.deltaTime;
                //rb.MovePosition(transform.position + transform.up * Time.deltaTime * -speed);
                this.transform.position -= transform.up * Time.deltaTime * speed / 10;
            }
            if (Input.GetKey("a"))
            {
                this.rb.rotation += rotatSpeed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                this.rb.rotation -= rotatSpeed * Time.deltaTime;
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
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //when player dies make its model explode and not destroy the gameobject
    
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
    }
}
