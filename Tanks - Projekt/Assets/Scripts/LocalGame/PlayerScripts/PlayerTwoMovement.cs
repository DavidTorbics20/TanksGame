using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerTwoMovement is responsible for the movement of player 2
public class PlayerTwoMovement : MonoBehaviour
{
    public PlayerSpawner playerSpawner;
    public GameObject bullet;
    public GameObject bulletStart;
    public Rigidbody2D rb;

    public float speed = 17.5f;
    public float rotatSpeed = 180.0f;
    private float timeBTWAtatck;
    public float startTimeBTWAttack = 2.0f;

    //at every updates checks inputs
    //with player 2 you move with UP, DOWN, LEFT, RIGHT and shoot with NUM 0
    //later the player will be choose custom buttons
    //also manages shootinng
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //x = speed * Time.deltaTime;
            //rb.MovePosition(transform.position + Vector3.up * speed);
            transform.position += transform.up * Time.deltaTime * speed / 10;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //x = speed * Time.deltaTime;
            //rb.MovePosition(transform.position + transform.up * Time.deltaTime * -speed);
            transform.position -= transform.up * Time.deltaTime * speed / 10;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.rotation += rotatSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.rotation -= rotatSpeed * Time.deltaTime;
        }

        if (timeBTWAtatck <= 0)
        {
            if (Input.GetKey(KeyCode.Keypad0))
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

    //at collision with a gameobject tagged "Bullet" this.gameObject gets destroyed
    //also player 1 gets plus one point
    void OnCollisionEnter2D(Collision2D col)
    {
        //idea for later: when player dies make its model explode and not destroy the gameobject

        if (col.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
            MazeManager.nextRound = true;
            PlayerOneScore.scoreValue += 1;
        }
    }
}
