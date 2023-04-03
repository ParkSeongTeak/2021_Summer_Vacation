using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConsoleManager : MonoBehaviour // JH 20210925
{
    GameObject _GMObj;
    public GameObject GMObj { get { return _GMObj; } set { _GMObj = value; } }

    public GameObject tabObj1;
    public GameObject tabObj2;
    public GameObject tabObj3;

    public GameObject talkObj;
    public GameObject colseButtonObj;

    public GameObject GameClearIamge;
    public GameObject GameFailImage;
    public CursorLockHide CursorScript;


    public void OpenTab1(){
        tabObj1.SetActive(true);
        tabObj2.SetActive(false);
        tabObj3.SetActive(false);
    }

    public void OpenTab2(){
        tabObj1.SetActive(false);
        tabObj2.SetActive(true);
        tabObj3.SetActive(false);
    }

    public void OpenTab3(){
        tabObj1.SetActive(false);
        tabObj2.SetActive(false);
        tabObj3.SetActive(true);
    }

    public void Option_Reset(){

        GMObj=GameObject.Find("GameManager");
        GameManager.Instance.reset();
        SceneManager.LoadScene("MainMenu");

    }




    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
