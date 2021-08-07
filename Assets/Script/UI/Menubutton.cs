using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menubutton : MonoBehaviour
{
    public GameObject[] SlideImg = new GameObject[4];
    public GameObject[] StartImg = new GameObject[2];

    GameObject Target = null;
    //public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    Vector3 targetPosition = new Vector3(-543,0,0);
    int idx;

    void Update()
    {
        if (Target != null)
        {
            // Define a target position above and behind the target transform
            //Vector3 targetPosition = Target.transform.TransformPoint(new Vector3(0, 5, -10));

            // Smoothly move the camera towards that target position
            Target.transform.position = Vector3.SmoothDamp(SlideImg[idx].transform.position, targetPosition, ref velocity, smoothTime);
        }



    }

    void StartButton()
    {
        Invoke("LoadGame", 1.5f);
        idx = 0;
        Target = SlideImg[idx];

        
    }
    

    void LoadGame()
    {
        SceneManager.LoadScene("Stage_1");
    }
  
}
