using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image FadeObj;
    public float fadeTime = 0.3f;
    bool first = true;


    void Start()
    {
        //FadeObj = this.gameObject.GetComponent<Image>();
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeProgress(FadeObj));
    }

    public void InvokeFadeIn()
    {
        if (first)
        {
            first = false;
            Invoke("StartFadeIn", 2.5f);
        }
        // else
        // {
        //     Invoke("StartFadeIn", 5f);
        //     )
        // }
    }

    IEnumerator FadeProgress(Image fadeObj)
    {
        float time = 0f;
        while (time < fadeTime)
        {
            Color tmpColor = new Color(fadeObj.color.r, fadeObj.color.g, fadeObj.color.b, fadeObj.color.a + (Time.deltaTime / fadeTime));
            fadeObj.color = tmpColor;
            yield return 0;
            time += Time.deltaTime;
        }
    }
}
