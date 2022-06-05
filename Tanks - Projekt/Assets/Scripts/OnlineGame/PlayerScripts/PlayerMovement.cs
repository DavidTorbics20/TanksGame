using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//is responsible for the player inputs to move the player character
//still work in progress
public class PlayerMovement : NetworkBehaviour
{
    //public PlayerSpawner playerSpawner;
    public GameObject bullet;
    public GameObject bulletStart;
    public Rigidbody2D rb;

    public float speed = 17.5f;
    public float rotatSpeed = 200.0f;
    private float timeBTWAtatck;
    public float startTimeBTWAttack = 2.0f;

    //checks if the player is a local player
    //disables Camera and PlayerMovement if not
    void Start()
    {
        if (!isLocalPlayer)
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponentInChildren<Camera>().enabled = false;
        }
    }

    //when the player joins it gets a camera to see things
    //this camera is set ontop of the player with a little offset
    public override void OnStartLocalPlayer()
    {
        Camera.main.orthographic = false;
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.position = this.gameObject.transform.position + new Vector3(0f, 0f, -10f);
    }

    //if the player is local player it registers key inputs and moves player
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        else
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

            //because the camera is weirdly bound to the player the z value has to be negated
            Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, this.gameObject.transform.rotation.z * -1);
        }
    }

    //on collision with a gameobject tagged "Bullet" the player gets destroyed
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
