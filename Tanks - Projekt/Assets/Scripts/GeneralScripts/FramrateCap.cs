using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramrateCap : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Application.targetFrameRate = 60;
    }
}
