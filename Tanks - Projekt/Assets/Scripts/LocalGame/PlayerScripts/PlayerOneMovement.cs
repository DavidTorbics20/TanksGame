using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerOneMovement is responsible for the movement of player 1
public class PlayerOneMovement : MonoBehaviour
{
    public PlayerSpawner playerSpawner;
    public GameObject bullet;
    public GameObject bulletStart;
    public Rigidbody2D rb;

    public float _speed = 17.5f;
    public float _rotatSpeed = 180.0f;
    private float _timeBTWAtatck;
    public float _startTimeBTWAttack = 2.0f;

    //at every updates checks inputs
    //with player 1 you move with W, A, S, D and shoot with C
    //later the player will be choose custom buttons
    //also manages shootinng
    void Update()
    {
        var deltaTime = Time.deltaTime;

        if (Input.GetKey("w"))
        {
            //x = speed * Time.deltaTime;
            //rb.MovePosition(transform.position + Vector3.up * speed);

            int negate = 1;
            CalculateMovement(deltaTime, _speed, negate);
        }
        if (Input.GetKey("s"))
        {
            //x = speed * Time.deltaTime;
            //rb.MovePosition(transform.position + transform.up * Time.deltaTime * -speed);

            int negate = -1;
            CalculateMovement(deltaTime, _speed, negate);
        }
        if (Input.GetKey("a"))
        {
            int negate = 1;
            rb.rotation += CalculateRotation(_rotatSpeed, deltaTime, negate);
        }
        if (Input.GetKey("d"))
        {
            int negate = -1;
            rb.rotation += CalculateRotation(_rotatSpeed, deltaTime, negate);
        }

        //caps the attack speed of the player 
        if (_timeBTWAtatck <= 0)
        {
            if (Input.GetKey("c"))
            {
                Instantiate(bullet, bulletStart.transform.position, bulletStart.transform.rotation);
                _timeBTWAtatck = _startTimeBTWAttack;
            }
        }
        else
        {
            _timeBTWAtatck -= deltaTime;
        }
    }

    //calculates direction the player should move to
    //created just fot the tests to work
    public void CalculateMovement(float deltaTime, float speed, float negate)
    {
        transform.position += transform.up * deltaTime * (speed / 10) * negate;
    }

    //calculates rotation of the player
    //created just fot the tests to work
    public float CalculateRotation(float rotateSpeed, float deltaTime, int negate)
    {
        return rotateSpeed * deltaTime * negate;
    }

    //at collision with a gameobject tagged "Bullet" this.gameObject gets destroyed
    //also player 2 gets plus one point
    void OnCollisionEnter2D(Collision2D col)
    {
        //idea for later: when player dies make its model explode and not destroy the gameobject

        if (col.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
            MazeManager.nextRound = true;
            PlayerTwoScore.scoreValue += 1;
        }
    }
}
