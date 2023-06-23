using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    [SerializeField]
    Image progressBar;

    static string nextScene;
    

    public static void LoadScene(string SceneName)
    {
        nextScene = SceneName;
        SceneManager.LoadScene("LoadGameScene");
    }


    // Start is called before the first frame update
    void Start()
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

            if (oper.progress < 0.9f)
            {
                progressBar.fillAmount = oper.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (progressBar.fillAmount >= 1f)
                {
                    oper.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
