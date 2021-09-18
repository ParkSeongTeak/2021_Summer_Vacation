using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    static string nextScene;
    float tmp;

    public static void LoadScene(string SceneName)
    {
        nextScene = SceneName;
        SceneManager.LoadScene("LoadGameScene");
    }


    // Start is called before the first frame update
    void Start()
    {
        Invoke("InvokeLoading", 3f);
    }

    void InvokeLoading()
    {
        StartCoroutine(LoadSceneProgress());
    }

    IEnumerator LoadSceneProgress()
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(nextScene);
        oper.allowSceneActivation = false;

        float timer = 0f;
        while(!oper.isDone)
        {
            yield return null;

            if (oper.progress >= 0.9f)
            {
                timer += Time.unscaledDeltaTime;
                tmp = Mathf.Lerp(0.9f, 1f, timer);
                if(tmp >= 1f)
                {
                    oper.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
