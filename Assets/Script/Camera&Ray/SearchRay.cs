using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchRay : MonoBehaviour
{
    public static SearchRay Instance;
    float RotateSpeed = 5f;
    GameObject start;
    GameObject End;
    GameObject Camera;
    float rotSpeed = 2.0f;
    public bool keydown = false;
    bool SetRotate = false;
    
    private void Start()
    {
        Instance = this;
    }

    public void SetEnd(GameObject gameObject)
    {
        End = gameObject;
    }


    //Quaternion qua = Quaternion.LookRotation(directionVec);
    private void Update()
    {
        if (keydown)
        {
            if (!SetRotate)
            {
                SetRotate = true;
                GetKeyDown();
            }

            RotatainRay();


        }

        
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
