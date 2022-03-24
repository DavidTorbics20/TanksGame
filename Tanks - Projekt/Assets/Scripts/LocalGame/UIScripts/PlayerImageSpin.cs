using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerImageSpin : MonoBehaviour
{
    Image image;
    public float rotationsPerMinute;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.transform.Rotate(0, 0, 6.0f * rotationsPerMinute * Time.deltaTime);
    }
}
