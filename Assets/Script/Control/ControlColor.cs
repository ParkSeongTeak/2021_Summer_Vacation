using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlColor : MonoBehaviour
{
    GameObject Image;
    GameObject CurrentTouch;
    GameObject SaveObj;
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
            Vector3 MousePos = Input.mousePosition;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (hit.collider != null)
            {
                CurrentTouch = hit.transform.gameObject;

                if (!GameManager.Instance.saveColor)
                {
                    //SearchRay Search 시작;
                    SearchRay.Instance.SetEnd(hit.point);
                    SearchRay.Instance.keydown = true;
                    

                    //Color originalColor = CurrentTouch.GetComponent<Renderer>().material.color;

                    //CurrentTouch.GetComponent<ObjControl>().Search(SaveObj, originalColor);

                    //CurrentTouch.GetComponent<Renderer>().material.color = GameManager.Instance.Getcolor();

                    
                    //CurrentTouch.GetComponent<Renderer>().material.color = GameManager.Instance.Getcolor();
                    GameManager.Instance.saveColor = true;
                    Debug.Log("True");
                }
                else
                {
                      
                    SearchRay.Instance.SetStart(CurrentTouch);      //첫번째 Set
                    SearchRay.Instance.GetKeyDown(hit.point);        //SearchRay 첫 오브젝트와 같은방향       
                    
                    GameManager.Instance.Setcolor(CurrentTouch.GetComponent<Renderer>().material.color);
                    Image.GetComponent<Image>().color = GameManager.Instance.Getcolor();
                    //SaveObj = CurrentTouch;
                    GameManager.Instance.saveColor = false;
                    Debug.Log("False");
                    // CurrentTouch  . ->  search (CurrentTouch CurrentTouch.color() ) 

                }

            }
        }



    }
}
