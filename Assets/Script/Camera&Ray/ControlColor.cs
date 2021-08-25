using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlColor : MonoBehaviour
{
    GameObject Image;
    GameObject DownTouch;
    GameObject UpTouch;


    GameObject SaveObj;
    Color Color;
    bool getcolor;
    bool Obj = false;
    bool AdditionalMixing = false;


    int _layerMask;
    Vector3 MousePos;
    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Default");
    }
    private void Start()
    {
        Image = GameObject.Find("Canvas").transform.Find("NowColor").gameObject;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            this.Obj = false;

            this.AdditionalMixing = false;

            MousePos = Input.mousePosition;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit,100f,_layerMask);


            if (hit.collider != null)
            {
                Debug.Log("DownTouch");

                DownTouch = hit.transform.gameObject;
                
                if (DownTouch.gameObject.tag == "Tool")
                {
                    DownTouch.GetComponent<GetTool>().SetTool();
                }

                if(DownTouch.gameObject.tag == "AdditionalMixing")
                {

                    Debug.Log("AdditionalMixing");
                    StartCoroutine(ScreenShotAndSpoid());
                    this.AdditionalMixing = true;
                }

                if (DownTouch.gameObject.tag == "Obj")
                {
                    this.Obj = true;
                    switch (GameManager.Instance.UsingTool)
                    {

                        case 1:


                            break;
                        case 2:

                            //SearchRay Search 시작;

                            ToolBox.Instance.SetStart(DownTouch);      //첫번째 Set
                                                                       //SearchRay.Instance.SetEnd(hit.point);
                                                                       //SearchRay.Instance.keydown = true;


                            //Color originalColor = CurrentTouch.GetComponent<Renderer>().material.color;
                            //CurrentTouch.GetComponent<ObjControl>().Search(SaveObj, originalColor);
                            //CurrentTouch.GetComponent<Renderer>().material.color = GameManager.Instance.Getcolor();
                            //CurrentTouch.GetComponent<Renderer>().material.color = GameManager.Instance.Getcolor();

                            GameManager.Instance.saveColor = true;
                            Debug.Log("True");
                            break;

                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 MousePos = Input.mousePosition;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 100f, _layerMask);


            if (hit.collider != null)
            {

                Debug.Log("UpTouch");
                UpTouch = hit.transform.gameObject;
                if (this.AdditionalMixing)
                {
                    GameObject gameObject = new GameObject();
                    gameObject.AddComponent<Renderer>();
                    gameObject.GetComponent<Renderer>().material.color = Color;
                    UpTouch.GetComponent<ObjControl>().Search(gameObject, Color);

                    Destroy(gameObject);
                    
                }

                if (this.Obj)
                {
                    switch (GameManager.Instance.UsingTool)
                    {
                        case 1:
                            if (DownTouch != UpTouch)
                            {

                                   //Debug.Log("Case1");


                                if (DownTouch.GetComponent<ObjControl>().GetGameObjects().Contains(UpTouch))
                                {
                                    //Debug.Log("DownTouch != UpTouch");
                                    if (DownTouch.GetComponent<Renderer>().material.color != UpTouch.GetComponent<Renderer>().material.color)
                                    {
                                        UpTouch.GetComponent<ObjControl>().Search(DownTouch, UpTouch.GetComponent<Renderer>().material.color);

                                    }
                                }
                                else
                                {
                                    Debug.Log("Not Nei" + UpTouch.gameObject.name);

                                }
                            }
                            else
                            {
                                Debug.Log("Same");
                            }
                            break;
                        case 2:

                            //SearchRay.Instance.SetStart(CurrentTouch);      //첫번째 Set
                            ToolBox.Instance.SetEnd(hit.point);

                            ToolBox.Instance.GetKeyDown(hit.point);        //SearchRay 첫 오브젝트와 같은방향       
                            ToolBox.Instance.keydown = true;

                            GameManager.Instance.Setcolor(UpTouch.GetComponent<Renderer>().material.color);
                            Image.GetComponent<Image>().color = GameManager.Instance.Getcolor();
                            //SaveObj = CurrentTouch;
                            GameManager.Instance.saveColor =  false;
                            Debug.Log("False");
                            // CurrentTouch  . ->  search (CurrentTouch CurrentTouch.color() )
                            // 
                            break;

                    }
                    this.Obj = false;
                }
            }



        }
    
    
    
    }

    IEnumerator ScreenShotAndSpoid()
    {
        //스크린샷을 찍어, 그것을 Texture2D로 반환시키고 그곳에서 색을 추출!!
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        yield return new WaitForEndOfFrame();
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        tex.Apply();

        //추출된 색
        Color = tex.GetPixel((int)MousePos.x, (int)MousePos.y);

        Debug.Log("r: " + Color.r + "g: " + Color.g + "b: " + Color.b);

        //color.GetComponent<Renderer>().material.color = color;
    }

}
