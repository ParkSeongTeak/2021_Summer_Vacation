using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetColor : MonoBehaviour
{
    GameObject CurrentTouch;
    GameObject Image;

    // Start is called before the first frame update
    void Start()
    {
        Image = GameObject.Find("Canvas").transform.Find("NowColor").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.saveColor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);

                if (hit.collider != null)
                {
                    CurrentTouch = hit.transform.gameObject;
                    GameManager.Instance.Setcolor(CurrentTouch.GetComponent<Renderer>().material.color);
                    Image.GetComponent<Image>().color = GameManager.Instance.Getcolor();
                    GameManager.Instance.saveColor = false;
                    Debug.Log("False");

                }
            }
        }
    }
}
