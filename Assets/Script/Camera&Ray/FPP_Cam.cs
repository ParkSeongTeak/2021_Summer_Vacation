﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPP_Cam : MonoBehaviour
{
    public static FPP_Cam Instance;
    public float turnSpeed = 4.0f; // 마우스 회전 속도    
    private float xRotate = 0.0f;
    //public GameObject SearchRay;
    public GameObject Body;
    GameObject Controller;

    public GameObject[] TileReset = new GameObject[0];//


    //public GameObject Lag;

    public float moveSpeed = 4.0f;
    public bool jump = false;

    float Vertical = 0f;
    float Horizontal = 0f;
    public float YPos;
    float YFirst;
    public bool InAir = false;
    public float YFix =20f;
    float V;
    float H;

    public float yRotate;

    bool trg = false;
    public bool Latter = false;
    float DTime = 0.0f;
    Vector3 Pos;



    float JumpForce = 200f;
    // Start is called before the first frame update
    void Start()
    {
        Controller = GameObject.Find("controller");
        //SearchRay = GameObject.Find("SearchRay");
        Instance = this;
    }

  
    public void TileRe()
    {
        GameManager.InGameData.nowPoint = 0;
        Controller.GetComponent<ControlColor>().Point.text = GameManager.InGameData.nowPoint+"";
        TileReset[GameManager.InGameData.RoomNum-1].GetComponent<OpenDoor>().TileReset();
        this.gameObject.transform.localPosition = new Vector3(0, 0.389f, 0);
        Body.GetComponent<Body>().BodyResetVec();

    }

   
    // Update is called once per frame
    void Update()
    {
        if(moveSpeed < 4.0f)
        {
            moveSpeed *= 2;
            if (moveSpeed >= 4.0f)
                moveSpeed = 4.0f;

        }
        if (Time.timeScale != 0f)
        {

            // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
            float XRotateSize = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
            // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
            float YRotateSize = Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;

            xRotate -= YRotateSize;
            // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
            xRotate = Mathf.Clamp(xRotate, -70, 80);

            transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
            Body.transform.Rotate(Vector3.up * XRotateSize);

            // 현재 y축 회전값에 더한 새로운 회전각도 계산
            //Instance.yRotate = transform.eulerAngles.y + yRotateSize;

            
            
            // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
            //transform.eulerAngles = new Vector3(xRotate, Instance.yRotate, 0);
            //transform.eulerAngles = new Vector3(xRotate, 0, 0);


            //SearchRay.transform.position = this.transform.position;
            

        }
    }
    
}
