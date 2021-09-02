using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
 
    
    public bool saveColor;
    Color Color;

    public int StageNum = 1;
    public int RoomNum = 1;         // 현위치
    string RoomNumStr = "asdfasdfasdfdfddddsasdfs";
    string StageNumStr = "fskljk;ljkl;jk;jkjlkjkjk";

    int[] RoomPoint = new int[7];   // 클리어 점수 저장
    public int nowPoint = 0;
    public int availablePoint = 20;


    //Tool 
    public int[] Tool = new int[5];// 0: NoTool 1: Brush 2: 인지색전이
    string[] ToolSave = new string[5];
    
    public int UsingTool = 0;  
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        ToolSave[0] = "None";
        ToolSave[1] = "Brush";
        ToolSave[2] = "Paint";
        ToolSave[3] = "Scissors";
        ToolSave[4] = "HelloWorld";

        //도구저장
        Tool[0] = PlayerPrefs.GetInt(ToolSave[0], 1);
        Tool[1] = PlayerPrefs.GetInt(ToolSave[1], 0);
        Tool[2] = PlayerPrefs.GetInt(ToolSave[2], 0);
        Tool[3] = PlayerPrefs.GetInt(ToolSave[3], 0);
        Tool[4] = PlayerPrefs.GetInt(ToolSave[4], 0);
        
        //방 위치
        RoomNum = PlayerPrefs.GetInt(RoomNumStr, 1);
        StageNum = PlayerPrefs.GetInt(StageNumStr, 1);

        Instance.saveColor = true;
    }

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


        PlayerPrefs.SetInt(StageNumStr, 1);
        PlayerPrefs.SetInt(RoomNumStr, 1);

        PlayerPrefs.SetInt(ToolSave[0], 1);
        PlayerPrefs.SetInt(ToolSave[1], 0);
        PlayerPrefs.SetInt(ToolSave[2], 0);
        PlayerPrefs.SetInt(ToolSave[3], 0);
        PlayerPrefs.SetInt(ToolSave[4], 0);

    }


}
