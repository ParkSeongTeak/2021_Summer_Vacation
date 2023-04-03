using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;



public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    InputManager _input = new InputManager();
    SoundManager _sound = new SoundManager();
    UIManager _ui;
    DataManager _data = new DataManager();
    public static GameManager Instance { get { Init(); return _instance; }}
    public InputManager Input  { get { return _instance._input; } }
    public SoundManager Sound  { get { return _instance._sound; } }
    public UIManager UI        { get { return _instance._ui; } }
    public DataManager Data     { get { return _instance._data; } }

    bool _saveColor;
    public bool saveColor { get { return _saveColor; } set { _saveColor = value; } }
    Color Color;
    public int StageNum = 1;
    public int RoomNum = 1;         // 현위치
    string RoomNumStr = "asdfasdfasdfdfddddsasdfs";
    string StageNumStr = "fskljk;ljkl;jk;jkjlkjkjk";

    int[] RoomPoint = new int[7];   // 클리어 점수 저장
    public int _nowPoint = 0;
    public int _availablePoint = 20;

    public int nowPoint { get { return _instance._nowPoint; } set { _instance._nowPoint = value; } }
    public int availablePoint { get { return _instance._availablePoint; } set { _instance._availablePoint = value; } }

    //Tool 
    int[] _tool = new int[10];// 0: NoTool 1: Brush 2: 인지색전이
    public int[] Tool { get { return _tool; } }// 0: NoTool 1: Brush 2: 인지색전이

    string[] ToolSave = new string[10];

    public int UsingTool = 0;
    private static void Init()
    {
        if (_instance == null)
        {
            GameObject GameManager = GameObject.Find("GameManager");
            if(GameManager == null)
            {
                GameManager = new GameObject{ name = "GameManager"};
                GameManager.AddComponent<GameManager>();
                GameManager.AddComponent<UIManager>();
            }
            DontDestroyOnLoad(GameManager);
            _instance = GameManager.GetComponent<GameManager>();
            _instance._ui = GameManager.GetComponent<UIManager>();
            _instance._input.Init();
            _instance._sound.Init();
            _instance._ui.Init();

            _instance.ToolSave = Enum.GetNames(typeof(Tools)); 
            
            _instance.Tool[(int)Tools.None] = PlayerPrefs.GetInt(_instance.ToolSave[(int)Tools.None], 1);
            _instance.Tool[(int)Tools.Brush] = PlayerPrefs.GetInt(_instance.ToolSave[(int)Tools.Brush], 0);
            _instance.Tool[(int)Tools.Paint] = PlayerPrefs.GetInt(_instance.ToolSave[(int)Tools.Paint], 0);
            _instance.Tool[(int)Tools.Scissors] = PlayerPrefs.GetInt(_instance.ToolSave[(int)Tools.Scissors], 0);
            

            //방 위치
            _instance.RoomNum = PlayerPrefs.GetInt(_instance.RoomNumStr, 1);
            _instance.StageNum = PlayerPrefs.GetInt(_instance.StageNumStr, 1);

            Instance.saveColor = true;


        }

    }

    public void Clear()
    {
        _instance._input.Clear();
        _instance._sound.Clear();
        _instance._ui.Clear();
    }


    
    // Start is called before the first frame update
    

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
