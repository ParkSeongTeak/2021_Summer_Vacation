using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //string NowColor;
    public bool saveColor;
    Color Color;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        Instance.saveColor = true;

    }

    void Start()
    {
        //getColor = true;
        //Instance.NowColor = GameObject.Find("Canvas").transform.GetChild(0).gameObject.name;
        //Debug.Log(Instance.NowColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   // public string GetNowColorName()
    //{
    //    return NowColor;
    //}
    public void Setcolor(Color color)
    {
        Instance.Color = color;
    }
    public Color Getcolor()
    {
        return Instance.Color;
    }


}
