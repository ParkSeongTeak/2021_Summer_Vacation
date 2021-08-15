using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //string NowColor;
    public bool saveColor;
    Color Color;

    
    
    
    //Tool 
    public int[] Tool = new int[5];// 0: NoTool 1: Brush 2: 인지색전이
    string[] ToolSave = new string[5];
    public int UsingTool = 0;  
    
    // Start is called before the first frame update
    private void Awake()
    {
        ToolSave[0] = "None";
        ToolSave[1] = "Bush";
        ToolSave[2] = "Paint";
        ToolSave[3] = "Scissors";
        ToolSave[4] = "HelloWorld";


        Tool[0] = PlayerPrefs.GetInt(ToolSave[0], 1);
        Tool[1] = PlayerPrefs.GetInt(ToolSave[1], 0);
        Tool[2] = PlayerPrefs.GetInt(ToolSave[2], 0);
        Tool[3] = PlayerPrefs.GetInt(ToolSave[3], 0);
        Tool[4] = PlayerPrefs.GetInt(ToolSave[4], 0);

        Instance = this;
        Instance.saveColor = true;
    }

    public void SetTool(int num)
    {
        Tool[num] = 1;
        PlayerPrefs.SetInt(ToolSave[num], 1);
    }

    void Start()
    {
        //getColor = true;
        //Instance.NowColor = GameObject.Find("Canvas").transform.GetChild(0).gameObject.name;
        //Debug.Log(Instance.NowColor);
    }

    // Update is called once per frame
    
    public void Setcolor(Color color)
    {
        Instance.Color = color;
    }
    public Color Getcolor()
    {
        return Instance.Color;
    }

    public void reset()
    {
        PlayerPrefs.SetInt(ToolSave[0], 1);
        PlayerPrefs.SetInt(ToolSave[1], 0);
        PlayerPrefs.SetInt(ToolSave[2], 0);
        PlayerPrefs.SetInt(ToolSave[3], 0);
        PlayerPrefs.SetInt(ToolSave[4], 0);

    }


}
