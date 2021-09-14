using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menubutton : MonoBehaviour
{
    const int SlideImgNum = 1;
    public GameObject[] SlideImg = new GameObject[SlideImgNum];
    Vector3[] SlideImgPos = new Vector3[SlideImgNum];


    public GameObject[] StartImg = new GameObject[2];

    public GameObject Target = null;
    //public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    Vector3 targetPosition = new Vector3(417, 540, 0);    //Canvas(960,540,0)
    int idx;

    //Vector3 Plus = new Vector3(5f, 0, 0);
    private void Start()
    {
        for (int i = 0; i < SlideImgNum; i++)
        {
            SlideImgPos[i] = SlideImg[i].transform.position;
        }
    }
    
    void FixedUpdate()
    {
        if (Target != null)
        {
            //Debug.Log("Update");
            // Define a target position above and behind the target transform
            //Vector3 targetPosition = Target.transform.TransformPoint(new Vector3(0, 5, -10));

            // Smoothly move the camera towards that target position
            Target.transform.position = Vector3.SmoothDamp(Target.transform.position, targetPosition, ref velocity, smoothTime);
            //Target.transform.position += Plus;
        }



    }

    public void StartButton()
    {
        Debug.Log("Stage_1");
        idx = 0;
        Target = SlideImg[idx];
        StartImg[0].SetActive(true);
        StartImg[1].SetActive(true);
        Invoke("LoadGame", 2.5f);

    }

    void LoadGame()
    {
        SceneManager.LoadScene("Stage_1");
    }

}