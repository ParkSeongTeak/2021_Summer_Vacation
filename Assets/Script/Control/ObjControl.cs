using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjControl : MonoBehaviour
{
    List<GameObject> neighborObjList = new List<GameObject>();
    Color VeryFirst;

    private void Start()
    {
        //this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Invoke("GetNeighbor", 0.2f);
        VeryFirst = this.gameObject.GetComponent<Renderer>().material.color;

    }
    public List<GameObject> GetGameObjects()
    {
        return neighborObjList;
    }

    public void Search(GameObject gameObject, Color originalColor)  //gameObject 전 오브젝트 (+바꿔야할 색의) ,originalColor 전 오브젝트의 전 색
    {

        if (this.GetComponent<Renderer>().material.color == originalColor && gameObject.GetComponent<Renderer>().material.color != originalColor)
        {
            this.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;// 색 바꾸기
            //Debug.Log("Hello");
            for (int i = 0; i < neighborObjList.Count; i++)
            {
                neighborObjList[i].GetComponent<ObjControl>().Search(this.gameObject, originalColor);        //인접 큐브에 전파;
                // Debug.Log("Hello");
            }


        }
    }

    //////////////////////////////////////////

    
    
    void GetNeighbor()
    {
        neighborObjList = this.GetComponent<GetNeighbor>().neighborObj();

        Debug.Log(transform.name +":  "+ neighborObjList.Count);
        Destroy(this.GetComponent<GetNeighbor>());

    }

}

