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
    InGameData _inGameData = new InGameData();
    static GameManager Instance { get { Init(); return _instance; }}
    public static InputManager Input  { get { return Instance._input; } }
    public static SoundManager Sound  { get { return Instance._sound; } }
    public static UIManager UI        { get { return Instance._ui; } }
    public static DataManager Data     { get { return Instance._data; } }


    public static InGameData InGameData { get { return Instance._inGameData; } }

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

            _instance._inGameData.ToolSave = Enum.GetNames(typeof(Tools)); 
            
            _instance._inGameData.Tool[(int)Tools.None] = PlayerPrefs.GetInt(_instance._inGameData.ToolSave[(int)Tools.None], 1);
            _instance._inGameData.Tool[(int)Tools.Brush] = PlayerPrefs.GetInt(_instance._inGameData.ToolSave[(int)Tools.Brush], 0);
            _instance._inGameData.Tool[(int)Tools.Paint] = PlayerPrefs.GetInt(_instance._inGameData.ToolSave[(int)Tools.Paint], 0);
            _instance._inGameData.Tool[(int)Tools.Scissors] = PlayerPrefs.GetInt(_instance._inGameData.ToolSave[(int)Tools.Scissors], 0);
            

            //방 위치
            _instance._inGameData.RoomNum = PlayerPrefs.GetInt(_instance._inGameData.RoomNumStr, 1);
            _instance._inGameData.StageNum = PlayerPrefs.GetInt(_instance._inGameData.StageNumStr, 1);

            _instance._inGameData.saveColor = true;


        }

    }

    public static void Clear()
    {
        _instance._input.Clear();
        _instance._sound.Clear();
        _instance._ui.Clear();
    }


    
    // Start is called before the first frame update
    

    
    
    

}
