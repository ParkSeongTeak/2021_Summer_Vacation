using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsolText : MonoBehaviour
{
    //int stageNum = 0;
    
    public GameObject consolText;
    bool isPrinted = false;

    public float fadeTime;
    public List<Text> TextList;
    int txtNum = 0;
    public Image background;

    private void OnTriggerEnter(Collider collision)
    {
        if(!isPrinted) {
            if (collision.tag == "MainCamera")
            {
                StartCoroutine(FirstFadeIn(TextList[txtNum], background)); //이걸 스테이지의 각 방마다 if-else문으로 구분지어 실행하기
                isPrinted = true;
            }
        }

    }

    IEnumerator FirstFadeIn(Text fadeIn, Image background)
    {
        float time = 0f;
        while (time < fadeTime)
        {
            Color tmpColor = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, fadeIn.color.a + (Time.deltaTime / fadeTime));
            fadeIn.color = tmpColor;
            background.color = tmpColor;
            yield return 0;
            time += Time.deltaTime;
        }
        Invoke("FadeProgress", 4f);
    }

    IEnumerator FadeText(Text fadeIn, Text fadeOut)
    {
        float time = 0f;
        while (time < fadeTime)
        {
            Color tmpColor = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, fadeIn.color.a + (Time.deltaTime / fadeTime));
            fadeIn.color = tmpColor;
            tmpColor = new Color(fadeOut.color.r, fadeOut.color.g, fadeOut.color.b, fadeOut.color.a - (Time.deltaTime / fadeTime));
            fadeOut.color = tmpColor;
            yield return 0;
            time += Time.deltaTime;
        }
        Invoke("FadeProgress", 4f);
    }

    IEnumerator LastFadeOut(Text fadeOut, Image background)
    {
        float time = 0f;
        while (time < fadeTime)
        {
            Color tmpColor = new Color(fadeOut.color.r, fadeOut.color.g, fadeOut.color.b, fadeOut.color.a - (Time.deltaTime / fadeTime));
            fadeOut.color = tmpColor;
            background.color = tmpColor;
            yield return 0;
            time += Time.deltaTime;
        }
    }

    void FadeProgress()
    {
        if (txtNum == 2)
        {
            StartCoroutine(LastFadeOut(TextList[txtNum], background));
        }
        else
        {
            StartCoroutine(FadeText(TextList[txtNum+1], TextList[txtNum]));
            txtNum++;
        }

    }

    void Start()
    {
        //StartCoroutine(FirstFadeIn(TextList[0], background));
    }

    void Update()
    {
        
    }
}
