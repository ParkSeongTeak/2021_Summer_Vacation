using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

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
        
        //this.gameObject.transform.localEulerAngles = StartLocation[ GameManager.Instance.RoomNum - 1 ,1]; //JH

    }

}
