using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menubutton : MonoBehaviour
{
    const int SlideImgNum = 4;
    public GameObject[] SlideImg = new GameObject[SlideImgNum];
    Vector3[] SlideImgPos = new Vector3[SlideImgNum];

    public GameObject[] Popup = new GameObject[3]; //
    public Image SlideBG;


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
            // Slide 이미지 이동시키는 코드
            Target.transform.position = Vector3.SmoothDamp(Target.transform.position, targetPosition, ref velocity, smoothTime);
            //Target.transform.position += Plus;
        }
    }

    public void StartButton()
    {
        Debug.Log("Stage_1");
        idx = 0;
        Target = SlideImg[idx];
        LoadGame();
    }

    void LoadGame()
    {
        Loading.LoadScene("Stage_1");
    }
    
    public void OptionButton()
    {
        idx = 1;
        Target = SlideImg[idx];
        Invoke("FadePopup", 2f);
    }

    public void CreditButton()
    {
        idx = 2;
        Target = SlideImg[idx];
        Invoke("FadePopup", 2f);
    }

    public void ExitButton()
    {
        idx = 3;
        Target = SlideImg[idx];
        Invoke("FadePopup", 2f);
    }

    void FadePopup()
    {
        //이거 SetActive 말고 페이드인 하도록 변경
        Popup[idx-1].SetActive(true);
    }

    public void BackBtn()
    {
        SlideImg[idx].transform.position = SlideImgPos[idx];
        SlideImg[idx].gameObject.SetActive(false);
        SlideBG.color = new Color(SlideBG.color.r, SlideBG.color.g, SlideBG.color.b, 0);
        SlideBG.gameObject.SetActive(false);
    }
}