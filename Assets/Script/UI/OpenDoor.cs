using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject[] Door = new GameObject[2];// [0]leftdoor [1]right
    public Material FillMaterial;
    public GameObject[] FillObj = new GameObject[0];


    public GameObject SetFalse = null;
    public GameObject SetTrue = null;
    
    Vector3[] DoorTo = new Vector3[2];
    Vector3[] DoorFrom = new Vector3[2];

    Vector3 Direction;
    public float x, y,z;

    float timer = 0.0f;
    float smoothTime = 0.015f;
    private Vector3 velocity = Vector3.zero;


    bool DoorUse = false;


    bool qualification()
    {
        Color NeedColor = this.FillMaterial.color;
        for (int i=0;i< this.FillObj.Length; i++)
        {

            Color FillObjColor = this.FillObj[i].GetComponent<Renderer>().material.color;
            if (!(Mathf.Approximately(FillObjColor.r, NeedColor.r) && Mathf.Approximately(FillObjColor.g, NeedColor.g) && Mathf.Approximately(FillObjColor.b, NeedColor.b)))
            {
                if (!(Mathf.Approximately(FillObjColor.r, NeedColor.r))) { Debug.Log("R"); }
                if (!(Mathf.Approximately(FillObjColor.g, NeedColor.g))) { Debug.Log("G"); }
                if (!(Mathf.Approximately(FillObjColor.b, NeedColor.b))) { Debug.Log("B"); }

                Debug.Log(this.FillObj[i].gameObject.name + "this.color  " + this.FillObj[i].GetComponent<Renderer>().material.color.r + " " + this.FillObj[i].GetComponent<Renderer>().material.color.g + " " + this.FillObj[i].GetComponent<Renderer>().material.color.b + "  FillMaterial  " + this.FillMaterial.color.r + " " + this.FillMaterial.color.g + " " + this.FillMaterial.color.b);
                return false;
                

            }
        }
        Debug.Log("DoorTrue");

        return true;
    }

    // Start is called before the first frame update
    private void Start()
    {
        DoorFrom[0] = Door[0].transform.position;
        DoorFrom[1] = Door[1].transform.position;
        Direction = new Vector3(x, y, z);
        DoorTo[0] = Door[0].transform.position + Direction;
        DoorTo[1] = Door[1].transform.position - Direction;
        //Debug.Log("DoorVec[0]" + DoorTo[0]);
        //Debug.Log("DoorVec[1]" + DoorTo[1]);



    }
    private void OnTriggerEnter(Collider MainCamera)
    {
     
        if (MainCamera.transform.tag == "MainCamera" && qualification())
        {
            DoorUse = true;
            Debug.Log("Open");

            if (SetFalse != null)
            {
                SetFalse.SetActive(false);
            }

            if (SetTrue != null)
            {
                SetTrue.SetActive(true);
            }

        }

        
    }
    
    void Update()
    {
        if (DoorUse)
        {
            timer += Time.deltaTime;
            if (timer < 2.5f)
            {
                Door[0].transform.position = Vector3.SmoothDamp(Door[0].transform.position, DoorTo[0], ref velocity, smoothTime);
                Door[1].transform.position = Vector3.SmoothDamp(Door[1].transform.position, DoorTo[1], ref velocity, smoothTime);
            }
            else
            {
                Door[0].transform.position = Vector3.SmoothDamp(Door[0].transform.position, DoorFrom[0], ref velocity, smoothTime);
                Door[1].transform.position = Vector3.SmoothDamp(Door[1].transform.position, DoorFrom[1], ref velocity, smoothTime);

            }
            if(timer >= 3.5f)
            {
                timer = 0f;
                DoorUse = false;
            }

        }

    }
}
