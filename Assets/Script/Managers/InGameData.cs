using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameData 
{
    public void init()
    {

    }

    bool _saveColor;
    public bool saveColor { get { return _saveColor; } set { _saveColor = value; } }
    public Color Color;
    public int StageNum = 1;
    public int RoomNum = 1;         // 현위치
    public string RoomNumStr = "asdfasdfasdfdfddddsasdfs";
    public string StageNumStr = "fskljk;ljkl;jk;jkjlkjkjk";

    int[] RoomPoint = new int[7];   // 클리어 점수 저장
    public int _nowPoint = 0;
    public int _availablePoint = 20;

    public int nowPoint { get { return _nowPoint; } set { _nowPoint = value; } }
    public int availablePoint { get { return _availablePoint; } set { _availablePoint = value; } }

    //Tool 
    int[] _tool = new int[10];// 0: NoTool 1: Brush 2: 인지색전이
    public int[] Tool { get { return _tool; } }// 0: NoTool 1: Brush 2: 인지색전이

    public string[] ToolSave = new string[10];

    public int UsingTool = 0;

    public void SetTool(int num)
    {
        Tool[num] = 1;
        PlayerPrefs.SetInt(ToolSave[num], 1);
        PlayerPrefs.SetInt(RoomNumStr, 1);


    }

    public void SetRoomNum(int num)
    {
        RoomNum = num;
        PlayerPrefs.SetInt(RoomNumStr, num);

    }

    public void SetStageNum(int num)
    {
        StageNum = num;
        PlayerPrefs.SetInt(StageNumStr, num);

    }



    // Update is called once per frame

    public void Setcolor(Color color)
    {
        Color = color;
    }
    public Color Getcolor()
    {
        return Color;
    }
    public void reset()
    {
        PlayerPrefs.SetInt(StageNumStr, 1);
        PlayerPrefs.SetInt(RoomNumStr, 1);
        PlayerPrefs.SetInt(ToolSave[0], 1);
        PlayerPrefs.SetInt(ToolSave[1], 0);
        PlayerPrefs.SetInt(ToolSave[2], 0);
        PlayerPrefs.SetInt(ToolSave[3], 0);
        PlayerPrefs.SetInt(ToolSave[4], 0);

    }
}
