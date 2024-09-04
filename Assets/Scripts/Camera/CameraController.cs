using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public ColorBlindFilter filter;
    void Start()
    {
        filter = GetComponent<ColorBlindFilter>();   
    }
}
