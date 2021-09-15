using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUse : MonoBehaviour
{
    //public static TextUse Instance;
    // Start is called before the first frame update
    public Text pfClone;
    public GameObject TextBoard;
    public GameObject[] GameButton = new GameObject[2];
    public GameObject Close;
    Vector3 SomeOne = new Vector3(-220, 0, 0);
    //Vector3 Me = new Vector3(400, 0, 0);
    Vector3 UP = new Vector3(0, 70, 0);
    Vector3 LineUP = new Vector3(0, 35, 0);
    Vector3 Down = new Vector3(0, -70, 0);

    KeyValuePair<int, string>[] Data;
    float timer = 0.0f;
    bool canTalk = false;
    string branch = "0" ;
    int cnt = 0;
    int Key;
    int line = 0;
    int ButtonType;
    public void SetcanTalkTrue(int num)//num 0: 버튼없음; num 1 : 네; 2: 아니오 3 네&아니오; 
    {
        canTalk = true;
        ButtonType = num;
        ButtonNum();
    }
    void ButtonNum()
    {
        if ( ButtonType == 0)
        {
            SetYes();
        }
        else if (ButtonType == 1)
        {
            GameButton[0].SetActive(true);
        }
        else if (ButtonType == 2)
        {
            GameButton[1].SetActive(true);
        }
        else
        {
            GameButton[0].SetActive(true);
            GameButton[1].SetActive(true);
        }
    }



    public void SetYes()
    {
        SetBranch("예");
    }
    public void SetNo()
    {
        SetBranch("노");
    }
    void SetBranch(string ans)
    {
        if (canTalk)
        {

            if (branch != "0")
                branch += ans;
            else
                branch = ans;

            TextSave.Instance.talkData.TryGetValue(branch, out KeyValuePair<int, string>[] data);
            Data = data;
            canTalk = false;

            GameButton[0].SetActive(false);            
            
            GameButton[1].SetActive(false);

        }


    }

    private void Start()
    {
        //Instance = this;
        cnt = 0;
        if (branch == "0")
        {
            TextSave.Instance.talkData.TryGetValue(branch, out KeyValuePair<int, string>[] data);
            Data = data;
            canTalk = false;
            GameButton[0].SetActive(false);
            GameButton[1].SetActive(false);

        }
        Close.SetActive(false);
    }

    private void Update()
    {
        if (!canTalk)
        {

            if (cnt == Data.Length)
            {
                canTalk = true;
                //GameButton[0].SetActive(true);
                //GameButton[1].SetActive(true);
                Close.SetActive(true);

                cnt = 0;
                return;
            }
            timer += Time.deltaTime;
            if (timer > 1.3f)
            {
                timer = 0f;

                if (Data[cnt].Key == 1)
                {
                    pfClone.text = Data[cnt].Value;
                    line = pfClone.text.Length / 17; 
                }
                else
                {
                    pfClone.text = ">" + Data[cnt].Value;
                    line = pfClone.text.Length / 17;

                }
                Key = Data[cnt].Key;
                PrintText();
                cnt++;
            }

        }
    }

    //IEnumerable PrintText()
    void PrintText()
    {
        /*
        GameObject goTemp = Instantiate(pfClone.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
        goTemp.transform.parent = TextBoard.transform;
        */
        int key = Key;
        GameObject Tmp = pfClone.gameObject;
        //yield return new WaitForSeconds(0.4f);
        GameObject goTemp = Instantiate(Tmp, Vector3.zero, Quaternion.identity) as GameObject; ;

        goTemp.transform.parent = TextBoard.transform;
        goTemp.transform.localPosition = SomeOne;

        SomeOne += Down;
        for (int i = 0; i < line; i++)
        {
            SomeOne -= LineUP;
            TextBoard.transform.position += LineUP;
        }
        TextBoard.transform.position += UP;

    }

}
