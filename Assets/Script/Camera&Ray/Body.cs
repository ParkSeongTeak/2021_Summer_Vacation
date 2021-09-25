using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

    /*
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
        
        if(collision.gameObject.layer == 9)
        {
            if (collision.gameObject.tag != "Down")
            {
                V = Vertical;
                H = Horizontal;

                moveSpeed = 0f;
            }
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
        
        if (collision.gameObject.layer == 9)
        {
            if (collision.gameObject.tag != "Down")
            {
                Vector3 move =
                transform.up * (-V) + transform.right * (-H); ;


                transform.position += move * Time.deltaTime;

            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;

            moveSpeed = 4.0f;
        }

        if (collision.gameObject.layer == 9)
        {
            if (collision.gameObject.tag != "Down")

                moveSpeed = 4f;
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


            Vector3 move =
                transform.forward * Vertical +
                transform.right * Horizontal;



            // 이동량을 좌표에 반영
            transform.position += move * moveSpeed * Time.deltaTime;


            //SearchRay.transform.position = this.transform.position;



            Vertical = Input.GetAxis("Vertical");
            Horizontal = Input.GetAxis("Horizontal");




        }
    }

    */

    //playermovement

    public CharacterController controller;

    public float speed = 4f;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    Vector3 velocity;
    bool isGrounded;
    float jumpHeight = .7f; // JH: 4f->.7f
    public Vector3[,] StartLocation = new Vector3[7, 2]; //  [ RoomNum - 1 location, RoomNum - 1 rotation] 
    bool RE = false;

    private void Start()
    {
        StartLocation[0, 0] = new Vector3(20 , 21, 20);
        StartLocation[0, 1] = new Vector3(0, 180, 0);

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

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y< 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward  * z;

        controller.Move(move * speed * Time.deltaTime);
        
        if(Input.GetButton("Jump") && isGrounded)
        {
        
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);
       
    }
    public void BodyResetVec()
    {
        Debug.Log(StartLocation[GameManager.Instance.RoomNum - 1, 0]);
        
        this.gameObject.transform.localEulerAngles = StartLocation[ GameManager.Instance.RoomNum - 1 ,1];

    }

}
