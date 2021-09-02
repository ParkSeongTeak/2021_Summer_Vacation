using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public float turnSpeed = 4.0f; // 마우스 회전 속도    
    private float xRotate = 0.0f;
    //public GameObject SearchRay;
    public GameObject Camera;

    public float moveSpeed = 4.0f;
    public bool jump = false;

    float Vertical = 0f;
    float Horizontal = 0f;
    public float YPos;
    float YFirst;
    float V;
    float H;

    public bool Latter = false;
    

    float JumpForce = 200f;

    Vector3[,] StartLocation = new Vector3[7, 2]; //  [ RoomNum - 1 location, RoomNum - 1 rotation] 


    private void Start()
    {
        StartLocation[0, 0] = new Vector3(20, 21, 20);
        StartLocation[0, 1] = new Vector3(0, 180 , 0);

        StartLocation[1, 0] = new Vector3(20, 21, 10);
        StartLocation[1, 1] = new Vector3(0, 180, 0);

        StartLocation[2, 0] = new Vector3(20, 21, 0);
        StartLocation[2, 1] = new Vector3(0, 180, 0);

        StartLocation[3, 0] = new Vector3(6, 21, -8);
        StartLocation[3, 1] = new Vector3(0, -90, 0);

        StartLocation[4, 0] = new Vector3(-4, 21, -8);
        StartLocation[4, 1] = new Vector3(0, -90, 0);

        StartLocation[5, 0] = new Vector3(-18, 21, -8);
        StartLocation[5, 1] = new Vector3(0, -90, 0);

        StartLocation[6, 0] = new Vector3(-26, 21, 5);
        StartLocation[6, 1] = new Vector3(0, 0, 0);


        transform.position = StartLocation[GameManager.Instance.RoomNum - 1, 0];
        transform.eulerAngles = StartLocation[GameManager.Instance.RoomNum - 1, 1];

        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.layer == 9 && collision.gameObject.tag == "Down")
        {
            jump = false;
        }

        if(collision.gameObject.tag == "Ladder")
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            moveSpeed = 0f;

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            Vertical = Input.GetAxis("Vertical");
            Horizontal = Input.GetAxis("Horizontal");

            Vector3 move =
                transform.up * Vertical + transform.right * Horizontal; ;


            Debug.Log("Ladder");
            // 이동량을 좌표에 반영
            transform.position += move * 4f * Time.deltaTime;


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;

            moveSpeed = 4.0f;
        }
    }




        // Update is called once per frame
    void Update()
    {
       
        if (Time.timeScale != 0f)
        {
            transform.eulerAngles = new Vector3(0, FPP_Cam.Instance.yRotate, 0);
            Camera.transform.position = transform.position;



            if (Input.GetKeyDown("space"))
            {
                if (!jump)
                {
                    Debug.Log("Jump");
                    this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * JumpForce * 30f);
                    jump = true;
                }
            }


            //SearchRay.transform.position = this.transform.position;



            Vertical = Input.GetAxis("Vertical");
            Horizontal = Input.GetAxis("Horizontal");



            Vector3 move =
                transform.forward * Vertical +
                transform.right * Horizontal;



            // 이동량을 좌표에 반영
            transform.position += move * moveSpeed * Time.deltaTime;



        }
    }
}
