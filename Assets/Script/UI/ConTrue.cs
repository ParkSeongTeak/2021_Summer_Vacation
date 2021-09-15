using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConTrue : MonoBehaviour
{

    GameObject UI;
    GameObject Text;
    GameObject Close;
    bool Onetime = false;
    public int ansType = 0;

    private void Start()
    {
        UI = GameObject.Find("Canvas").transform.Find("BGImg").gameObject;//.transform.Find("Talk").gameObject;
        Text = UI.transform.Find("").transform.Find("Talk").gameObject;
        Close = GameObject.Find("Canvas").transform.Find("BGImg").gameObject.transform.Find("Close").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!this.Onetime)
        {
            UI.SetActive(true);
            Close.SetActive(false);
            Text.GetComponent<TextUse>().SetcanTalkTrue(this.ansType);
            this.Onetime = true;
        }        
    }
}
