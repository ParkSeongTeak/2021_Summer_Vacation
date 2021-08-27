using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    static int Toolnum = 5;
    public GameObject[] ToolCursor = new GameObject[Toolnum];      //0: NoTool 1: Brush 2: 인지색전이
    public GameObject[] ToolButton = new GameObject[Toolnum];
    public GameObject[,] ToolState = new GameObject[5,4];

    int UsingTool;

    // Start is called before the first frame update
    void Start()
    {
        
        
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                ToolState[i,j] = ToolButton[i].transform.GetChild(j).gameObject;
            }
        }
        UsingTool = 0;
        for(int i = 1; i < Toolnum; i++)
        {
            ToolCursor[i].SetActive(false);
        }
        for (int i = 1; i < Toolnum; i++)
        {
            if (GameManager.Instance.Tool[i] == 1)
                ToolStateSet(i, 1);
            else
            {
                ToolStateSet(i, 0);
            }
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (GameManager.Instance.Tool[1] == 1)
            {
                ToolStateSet(UsingTool, 1);
                ToolStateSet(1, 2);
                BrushUse();
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (GameManager.Instance.Tool[2] == 1)
            {
                ToolStateSet(UsingTool, 1);
                ToolStateSet(2, 2);
                LighttUse();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (GameManager.Instance.Tool[1] == 1)
            {
                ToolStateSet(UsingTool, 1);
                ToolStateSet(3, 2);
                PaintUse();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (GameManager.Instance.Tool[1] == 1)
            {
                ToolStateSet(UsingTool, 1);
                ToolStateSet(4, 2);
                FourUse();
            }

        }

    }

    void NoneUse()
    {
        ToolCursor[UsingTool].SetActive(false);
        ToolCursor[0].SetActive(true);
        UsingTool = 0;
        GameManager.Instance.UsingTool = 0;

    }

    void BrushUse()
    {
        ToolCursor[UsingTool].SetActive(false);
        ToolCursor[1].SetActive(true);
        UsingTool = 1;
        GameManager.Instance.UsingTool = 1;
    }
    void LighttUse()
    {
        ToolCursor[UsingTool].SetActive(false);
        ToolCursor[2].SetActive(true);
        UsingTool = 2;
        GameManager.Instance.UsingTool = 2;
    }
    void PaintUse()
    {
        ToolCursor[UsingTool].SetActive(false);
        ToolCursor[3].SetActive(true);
        UsingTool = 3;
        GameManager.Instance.UsingTool = 3;
    }
    void FourUse()
    {
        ToolCursor[UsingTool].SetActive(false);
        ToolCursor[4].SetActive(true);
        UsingTool = 4;
        GameManager.Instance.UsingTool = 4;
    }

    public void ToolStateSet(int tool , int state)
    {
        
        for (int i = 0; i < 4; i++)
        {
            ToolState[tool,i].SetActive(false);
        }
        ToolState[tool,state].SetActive(true);

    }
}
