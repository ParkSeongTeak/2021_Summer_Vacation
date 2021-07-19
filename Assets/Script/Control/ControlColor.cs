using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlColor : MonoBehaviour
{
    GameObject Image;
    GameObject CurrentTouch;
    Color Color;
    bool getcolor;

    private void Start()
    {
        Image = GameObject.Find("Canvas").transform.Find("NowColor").gameObject;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (hit.collider != null)
            {
                CurrentTouch = hit.transform.gameObject;
                if (!GameManager.Instance.saveColor)
                {
                    CurrentTouch.GetComponent<Renderer>().material.color = GameManager.Instance.Getcolor();
                    GameManager.Instance.saveColor = true;
                    Debug.Log("True");
                }
                else
                {
                    GameManager.Instance.Setcolor(CurrentTouch.GetComponent<Renderer>().material.color);
                    Image.GetComponent<Image>().color = GameManager.Instance.Getcolor();
                    GameManager.Instance.saveColor = false;
                    Debug.Log("False");
                    // CurrentTouch  . ->  search (CurrentTouch CurrentTouch.color() ) 

                }

            }
        }



    }
}
