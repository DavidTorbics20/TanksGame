using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//spins the player sprite image
public class PlayerImageSpin : MonoBehaviour
{
    Image image;
    public float rotationsPerMinute;

    //gets the image component of the player
    void Start()
    {
        image = GetComponent<Image>();
    }

    //rotates the image with a constant speed
    void Update()
    {
        image.transform.Rotate(0, 0, 6.0f * rotationsPerMinute * Time.deltaTime);
    }
}
