using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    static int Toolnum = 5;
    public GameObject[] ToolImg = new GameObject[Toolnum];      //0: NoTool 1: Brush 2: 인지색전이
    public GameObject[] ToolButton = new GameObject[Toolnum];

    int UsingTool;

    // Start is called before the first frame update
    void Start()
    {
        UsingTool = 0;
        for(int i = 0; i < Toolnum; i++)
        {
            ToolImg[i].SetActive(false);
        }
        for (int i = 0; i < Toolnum; i++)
        {
            if(GameManager.Instance.Tool[i] ==1)
                ToolButton[i].SetActive(true);
        }

    }

    public void BrushUse()
    {
        ToolImg[UsingTool].SetActive(false);
        ToolImg[1].SetActive(true);
        UsingTool = 1;
        GameManager.Instance.UsingTool = 1;
    }
    public void PaintUse()
    {
        ToolImg[UsingTool].SetActive(false);
        ToolImg[2].SetActive(true);
        UsingTool = 2;
        GameManager.Instance.UsingTool = 2;
    }
    public void ScissorsUse()
    {
        ToolImg[UsingTool].SetActive(false);
        ToolImg[3].SetActive(true);
        UsingTool = 3;
        GameManager.Instance.UsingTool = 3;
    }
}
