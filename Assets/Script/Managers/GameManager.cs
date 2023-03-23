using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    InputManager _input = new InputManager();
    SoundManager _sound = new SoundManager();
    UIManager _ui = new UIManager();

    public static GameManager Instance { get { Init(); return _instance; }}
    public InputManager Input  { get { return _instance._input; } }
    public SoundManager Sound  { get { return _instance._sound; } }
    public UIManager UI        { get { return _instance._ui; } }

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
            }
            DontDestroyOnLoad(GameManager);
            _instance = GameManager.GetComponent<GameManager>();
            _instance._input.Init();
            _instance._sound.Init();
            _instance._ui.Init();


            _instance.ToolSave[0] = "None";
            _instance.ToolSave[1] = "Brush";
            _instance.ToolSave[2] = "Paint";
            _instance.ToolSave[3] = "Scissors";
            _instance.ToolSave[4] = "HelloWorld";

            _instance.Tool[0] = PlayerPrefs.GetInt(_instance.ToolSave[0], 1);
            _instance.Tool[1] = PlayerPrefs.GetInt(_instance.ToolSave[1], 0);
            _instance.Tool[2] = PlayerPrefs.GetInt(_instance.ToolSave[2], 0);
            _instance.Tool[3] = PlayerPrefs.GetInt(_instance.ToolSave[3], 0);
            _instance.Tool[4] = PlayerPrefs.GetInt(_instance.ToolSave[4], 0);

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
