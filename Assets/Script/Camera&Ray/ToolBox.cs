using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBox : MonoBehaviour
{
    public static ToolBox Instance;

    public GameObject[] NowToolImg = new GameObject[4];

    float RotateSpeed = 5f;
    int cnt = 0;
    float dist = 8f;
    Quaternion current;
    GameObject before;

    int Debg = 0;


    GameObject StartObj;

    Vector3 StartPos;
    Vector3 EndPos;
    GameObject Camera;

    RaycastHit hit;
    Ray ray;

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
        before = this.gameObject;
        StartPos = new Vector3 ();
        EndPos = new Vector3();


    }

    public void SetStartPos(Vector3 startpos)
    //ControlColor class에서 클릭시 가져오기
    {
        StartPos = startpos;
    }
    public void SetStart(GameObject start)
    //ControlColor class에서 클릭시 가져오기

    {
        StartObj = start;
    }
    public void SetEnd(Vector3 gameObject)
    //ControlColor class에서 클릭시 가져오기

    {
        EndPos = gameObject;
    }

    private void Update()
    {

        if (keydown)                // ControlColor -> GetMouse -> !savecolor 일때 활성화
        {

            Debg += 1;
            if (Debg > 500)        //무한렉 방지 개발중에만 사용
            {
                Debug.Log("Over400");
                keydown = false;
                Debg = 0;
                return;
            }

           Debug.DrawRay(ray.origin, ray.direction * dist, Color.green);

            //SearchRay 전방주시
            ray.origin = this.transform.position;
            ray.direction = this.transform.forward;

            Physics.Raycast(ray.origin, ray.direction, out hit);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject != before) // 이전꺼면 ㄴㄴ
                {

                    before = hit.collider.gameObject;
                    GameObject game = hit.collider.gameObject;
                    Debug.Log("InSearchRay" + before.name);

                    if (game.gameObject.GetComponent<Renderer>().material.color != StartObj.gameObject.GetComponent<Renderer>().material.color)
                    //만약 경로상 다른 색이 있다면
                    {
                        game.GetComponent<ObjControl>().Search(StartObj, game.gameObject.GetComponent<Renderer>().material.color);
                        keydown = false;        //탈출
                        return;

                    }


                }
            }


            cnt++;
            if (cnt > 3)
            {
                cnt = 0;
                if (this.gameObject.transform.rotation == current)       
                //움직임 확인 웁직임이 멈추면 
                {
                    keydown = false;                                        //SearchRay종료
                    Debug.Log("Debg: " + Debg);
                    Debg = 0;

                }
                else
                {
                    current = this.gameObject.transform.rotation;

                }
            }
            RotatainRay();          //돌려

        }
       
    }


    public void GetKeyDown(Vector3 HitPos)        //카메라와 같은 방향보기
    {
        Vector3 relativePos = HitPos- transform.position;
        Instance.transform.rotation = Quaternion.LookRotation(relativePos);
    }
    void RotatainRay()
        //자연스러운 돌리기
    {
        Vector3 relativePos = EndPos - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Instance.transform.rotation = Quaternion.Slerp(Instance.transform.rotation,rotation,Time.deltaTime *rotSpeed );
    }

    /*
    public void Brush()
    {
        NowToolImg[1]
        GameManager.Instance.UsingTool = 1;
        
        
        NowToolImg[1].SetActive(true);
    }
    public void Paint()
    {
        GameManager.Instance.UsingTool = 2;
    }
    public void Scissors()
    {
        GameManager.Instance.UsingTool = 3;
    }
    */
}
