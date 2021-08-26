using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string NextStage = "Stage_2";
    public GameObject LoadingPage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            GameManager.Instance.RoomNum = 1;
            LoadingPage.SetActive(true);
            SceneManager.LoadScene(NextStage);
        }
    }
}
