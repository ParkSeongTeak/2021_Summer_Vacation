using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUse : MonoBehaviour
{
    // Start is called before the first frame update
    public Text pfClone;
    public GameObject TextBoard;
    Vector3 SomeOne = new Vector3(-220, 0, 0);
    Vector3 Me = new Vector3(400, 0, 0);
    Vector3 UP = new Vector3(0, 70, 0);
    Vector3 Down = new Vector3(0, -70, 0);
    string branch = "0" ;
    int Key;
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
        if (branch != "0")
            branch += ans;
        else
            branch = ans;


        TextSave.Instance.talkData.TryGetValue(branch, out KeyValuePair<int, string>[] data);
        for (int i = 0; i < data.Length; i++)
        {
            pfClone.text = data[i].Value;
            Key = data[i].Key;
            PrintText();     //Key 1: SomeOne 2: Me
        }

    }
    
    private void Start()
    {
        
        if (branch == "0")
        {
            TextSave.Instance.talkData.TryGetValue(branch, out KeyValuePair<int, string>[] data);
            for(int i = 0; i < data.Length; i++)
            {
                pfClone.text = data[i].Value;
                Key = data[i].Key;
                PrintText();
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

        if (key == 1) {
            goTemp.transform.localPosition = SomeOne;
        }
        else{
            goTemp.transform.localPosition = Me;
        }
        SomeOne += Down;
        Me += Down;
        TextBoard.transform.position += UP;

    }

}
