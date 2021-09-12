using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
    public GameObject PausePopUp;
    public bool isPause = false;

    public void Pause()
    {
        //Time.timeScale = 0f;
        PausePopUp.SetActive(true);
    }

    public void Resume()
    {
        //Time.timeScale = 1f;
        PausePopUp.SetActive(false);
    }

    public void Option()
    {
        // 추후 수정
    }

    public void ToMainMenu()
    {
        //Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                isPause = true;
                Pause();
            }
            else
            {
                isPause = false;
                Resume();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            FPP_Cam.Instance.TileRe();

        }
    }
}