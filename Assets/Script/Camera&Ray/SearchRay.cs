using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchRay : MonoBehaviour
{
    public static SearchRay Instance;
    float RotateSpeed = 5f;
    int cnt = 0;
    float dist = 8f;
    Quaternion current;
    GameObject before;

    int Debg = 0;


    GameObject start;
    GameObject End;
    GameObject Camera;

    RaycastHit hit;
    Ray ray;

    List<GameObject> ListObj;
    float rotSpeed = 2.0f;
    public bool keydown = false;
    bool SetRotate = false;
    
    private void Start()
    {
        Instance = this;
        Camera = GameObject.Find("Main Camera");
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;
        current = this.gameObject.transform.rotation;
        ListObj = new List<GameObject>();
        before = this.gameObject;
    }

    public void SetEnd(GameObject gameObject)
    {
        End = gameObject;
    }


    //Quaternion qua = Quaternion.LookRotation(directionVec);
    private void Update()
    {

        if (keydown)                // ControlColor -> GetMouse -> !savecolor 일때 활성화
        {
            Debg += 1;
            if (Debg > 400)
            {
                Debug.Log("Over400");
                keydown = false;
                return;
            }

           Debug.DrawRay(ray.origin, ray.direction * dist, Color.red);

            cnt++;
            
            if (cnt > 3)                                                    //굳이 매 프레임? 4프레임마다 
            {
                cnt = 0;

                Physics.Raycast(ray.origin, ray.direction, out hit);

                if (hit.collider != null)
                {
                    if (hit.collider != before) //SearchRay전방으로 ray
                    {
                        before = hit.collider.gameObject;
                        GameObject game = hit.collider.gameObject;

                        for (int i = 0; i < ListObj.Count + 1; i++)
                        {
                            if (i == ListObj.Count)
                            {
                                ListObj.Add(game);                          //List에 없는 오브젝트면 add;
                                Debug.Log(game.gameObject.name);
                            }
                            else if (ListObj[i] == game)
                            {
                                break;
                            }

                        }
                    }
                }



                if (this.gameObject.transform.rotation == current)           //멈추면
                {
                    keydown = false;                                        //SearchRay종료
                    Debug.Log("Debg: " + Debg);
                    Debg = 0;
                    ListObj.Clear();
                }
                else
                {
                    current = this.gameObject.transform.rotation;

                    

                }
            }
            RotatainRay();          //돌려;

        }
        /*if (hit.collider != null) {
            if (hit.collider != before) //SearchRay전방으로 ray
            {


                before = hit.collider.gameObject;
                GameObject game = hit.collider.gameObject;
                for (int i = 0; i < ListObj.Count + 1; i++)
                {
                    if (i == ListObj.Count)
                    {
                        ListObj.Add(game);                          //List에 없는 오브젝트면 add;
                        Debug.Log(game.gameObject.name);
                    }
                    else if (ListObj[i] == game)
                    {
                        break;
                    }

                }
            }
            cnt++;
            if (cnt > 3)                                                    //굳이 매 프레임? 3프레임마다 
            {
                cnt = 0;

                if (this.gameObject.transform.rotation == current)           //멈추면
                {
                    keydown = false;                                        //SearchRay종료

                    GameObject Start = ListObj[0];                           //첫번째거 가져와서 

                    for (int i = 1; i < ListObj.Count; i++)
                    {

                        if (ListObj[i].GetComponent<Renderer>().material.color != Start.GetComponent<Renderer>().material.color)
                        //List해석
                        {
                            ListObj[i].GetComponent<ObjControl>().Search(Start, ListObj[i].GetComponent<Renderer>().material.color);
                            ListObj.Clear();
                            break;
                        }

                    }



                }
                else
                {
                    current = this.gameObject.transform.rotation;
                }
            }
            RotatainRay();          //돌려;

        }
        
    }
        */

    }


    public void GetKeyDown()
    {
        Instance.transform.rotation = Camera.transform.rotation;
    }
    void RotatainRay()
    {
        Vector3 relativePos = End.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Instance.transform.rotation = Quaternion.Slerp(Instance.transform.rotation,rotation,Time.deltaTime *rotSpeed );
    }

}
