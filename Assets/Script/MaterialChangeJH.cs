using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeJH : MonoBehaviour
{
    [SerializeField]
    Material ColorRendererRed;
    [SerializeField]
    Material ColorRendererGreen;
    [SerializeField]
    Material ColorRendererBlue;
    [SerializeField]
    Material ColorRendererOrange;
    [SerializeField]
    Material ColorRendererBlack;

    // Start is called before the first frame update
    void Start()
    {
        ColorRendererRed.color = new Color(249f/255f, 66f/255f, 58f/255f, 1f);
        ColorRendererGreen.color = new Color(133f/255f, 245f/255f, 168f/255f, 1f);
        ColorRendererBlue.color = new Color(128f/255f, 188f/255f, 251f/255f, 1f);
    }

    void OnApplicationQuit() {
        ColorRendererRed.color = new Color(240f/255f, 240f/255f, 240f/255f, 1f);
        ColorRendererGreen.color = new Color(240f/255f, 240f/255f, 240f/255f, 1f);
        ColorRendererBlue.color = new Color(240f/255f, 240f/255f, 240f/255f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
