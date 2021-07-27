using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchRay : MonoBehaviour
{
    float RotateSpeed = 5f;
    GameObject start;
    GameObject End;
    GameObject Camera;
    public bool keydown = false;
    public bool keyup = true;


    public void GetKeyDown()
    {
        this.transform.rotation = Camera.transform.rotation;
    }

    /*
    public Queue<GameObject> SearchObjRay(GameObject start, GameObject End, GameObject Camera)
    {
        List<GameObject> obj = new List<GameObject>();
        Queue<GameObject> gameObjects = new Queue<GameObject>();
        RaycastHit hit;

        if(Physics.Raycast(Camera, start - Camera, out hit))
        {
            for (int i = 0; i < obj.Count; i++)
            {

            }
        }
        


        return gameObjects;
    }
    */

    private void Update()
    {
        
    }
}
