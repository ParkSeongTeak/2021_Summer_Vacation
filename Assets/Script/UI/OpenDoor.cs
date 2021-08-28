using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject[] Door = new GameObject[2];// [0]leftdoor [1]right
    public Material FillMaterial = null;
    public GameObject[] FillObj = new GameObject[0];
    public GameObject SetFalse = null;
    public GameObject SetTrue = null;
    public GameObject Blocker = null;
    GameObject Controller;

    


    Vector3[] DoorTo = new Vector3[2];
    Vector3[] DoorFrom = new Vector3[2];

    Vector3 Direction;
    public float x, y,z;

    float timer = 0.0f;
    float smoothTime = 0.015f;
    private Vector3 velocity1 = Vector3.zero;
    private Vector3 velocity2 = Vector3.zero;



    bool DoorUse = false;
    public bool PointZero = false;
    public int RoomNum = 0;

    public bool doorOpen = false;
    public bool doorClose = false;



    bool qualification()
    {
        
        if (this.FillMaterial != null && this.doorOpen) {
            Color NeedColor = this.FillMaterial.color;
            for (int i = 0; i < this.FillObj.Length; i++)
            {

                Color FillObjColor = this.FillObj[i].GetComponent<Renderer>().material.color;
                if( !((FillObjColor.r > NeedColor.r - 0.0039f) && (FillObjColor.r < NeedColor.r + 0.0039f) && (FillObjColor.g > NeedColor.g - 0.0039f) &&  (FillObjColor.g < NeedColor.g + 0.0039f) && (FillObjColor.b > NeedColor.b - 0.0039f) && (FillObjColor.b < NeedColor.b + 0.0039f)))
                {
                    if (!(Mathf.Approximately(FillObjColor.r, NeedColor.r))) { Debug.Log("R"); }
                    if (!(Mathf.Approximately(FillObjColor.g, NeedColor.g))) { Debug.Log("G"); }
                    if (!(Mathf.Approximately(FillObjColor.b, NeedColor.b))) { Debug.Log("B"); }

                    Debug.Log(this.FillObj[i].gameObject.name + "this.color  " + this.FillObj[i].GetComponent<Renderer>().material.color.r + " " + this.FillObj[i].GetComponent<Renderer>().material.color.g + " " + this.FillObj[i].GetComponent<Renderer>().material.color.b + "  FillMaterial  " + this.FillMaterial.color.r + " " + this.FillMaterial.color.g + " " + this.FillMaterial.color.b);
                    return false;


                }
            }
            Debug.Log("DoorTrue");
        }
        return true;
    }

    // Start is called before the first frame update
    private void Start()
    {
        Controller = GameObject.Find("controller");
        this.DoorFrom[0] = this.Door[0].transform.position;
        this.DoorFrom[1] = this.Door[1].transform.position;
        this.Direction = new Vector3(x, y, z);
        this.DoorTo[0] = this.Door[0].transform.position + this.Direction;
        this.DoorTo[1] = this.Door[1].transform.position - this.Direction;
        //Debug.Log("DoorVec[0]" + DoorTo[0]);
        //Debug.Log("DoorVec[1]" + DoorTo[1]);



    }
    private void OnTriggerEnter(Collider MainCamera)
    {
        if (this.doorOpen)
        {

            if (MainCamera.transform.tag == "MainCamera" && qualification())
            {
                if (this.RoomNum != 0)
                    GameManager.Instance.RoomNum = RoomNum;
                if (this.PointZero)
                {
                    GameManager.Instance.nowPoint = 0;
                    Controller.GetComponent<ControlColor>().Point.text = "  " + GameManager.Instance.nowPoint;

                }
                this.DoorUse = true;

                /*
                if (this.SetFalse != null)
                {
                    this.SetFalse.SetActive(false);
                }

                if (this.SetTrue != null)
                {
                    this.SetTrue.SetActive(true);
                }
                */
            }
        }
        if (this.doorClose)
        {
            this.DoorUse = true;
            if (this.Blocker != null)
            {
                this.Blocker.SetActive(true);
            }
        }


    }
    
    void Update()
    {
        if (this.DoorUse)
        {
            if (this.doorOpen)
            {
                this.timer += Time.deltaTime;
                if (this.timer < 2.5f)
                {
                    this.Door[0].transform.position = Vector3.SmoothDamp(this.Door[0].transform.position, this.DoorTo[0], ref this.velocity1, this.smoothTime);
                    this.Door[1].transform.position = Vector3.SmoothDamp(this.Door[1].transform.position, this.DoorTo[1], ref this.velocity2, this.smoothTime);
                }
                if (this.timer >= 3.5f)
                {
                    this.timer = 0f;
                    this.DoorUse = false;
                }

            }

            if (this.doorClose)
            {
                this.timer += Time.deltaTime;
                if (this.timer < 2.5f)
                {
                    this.Door[0].transform.position = Vector3.SmoothDamp(this.Door[0].transform.position, this.DoorFrom[0], ref this.velocity1, this.smoothTime);
                    this.Door[1].transform.position = Vector3.SmoothDamp(this.Door[1].transform.position, this.DoorFrom[1], ref this.velocity2, this.smoothTime);
                }
                if (this.timer >= 3.5f)
                {
                    this.timer = 0f;
                    this.DoorUse = false;
                }
            }

        }
        

    }


    public void TileReset()
    {
        for(int i = 0 ; i <  FillObj.Length ; i++)
        {
            FillObj[i].GetComponent<Renderer>().material.color = FillObj[i].GetComponent<ObjControl>().VeryFirst;
        }
    }
}
