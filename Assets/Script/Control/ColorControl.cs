using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControl : MonoBehaviour
{
    public int R = 0;
    public int G = 0;
    public int B = 0;
    float r;
    float g;
    float b;

    // Start is called before the first frame update
    void Start()
    {
        r = (float)R / 255f;
        g = (float)G / 255f;
        b = (float)B / 255f;
        Color color;
        color.a = 1f;
        color.r = r;
        color.g = g;
        color.b = b;

        this.GetComponent<Renderer>().material.color = color;


    }

    
}
