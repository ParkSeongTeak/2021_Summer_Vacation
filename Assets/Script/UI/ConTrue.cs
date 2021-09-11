using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConTrue : MonoBehaviour
{

    GameObject UI;
    GameObject Text;

    private void Start()
    {
        UI = GameObject.Find("Canvas").transform.Find("BGImg").gameObject;//.transform.Find("Talk").gameObject;
        Text = UI.transform.Find("").transform.Find("Talk").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        UI.SetActive(true);
        Text.GetComponent<TextUse>().SetcanTalkTrue();
    }
}
