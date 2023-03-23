using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConTrue : MonoBehaviour
{
    [SerializeField]
    GameObject UI;
    [SerializeField]
    GameObject Text;
    [SerializeField]
    GameObject Close;
    bool Onetime = false;
    public int ansType = 0;

    private void Start()
    {   
        UI = GameObject.Find("Canvas").transform.Find("ConsoleCanvas").gameObject;//.transform.Find("Talk").gameObject;
        Text = UI.GetComponent<ConsoleManager>().talkObj;
        Close = UI.GetComponent<ConsoleManager>().colseButtonObj;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!this.Onetime)
        {
            UI.SetActive(true);
            Close.SetActive(false);
            Text.GetComponent<TextUse>().SetcanTalkTrue(this.ansType);
            UI.GetComponent<ConsoleManager>().CursorScript.CursorTrue();
            this.Onetime = true;
            
        }        
    }
}
