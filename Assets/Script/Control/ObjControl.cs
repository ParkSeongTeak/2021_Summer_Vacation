using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjControl : MonoBehaviour
{
    public List<GameObject> neighborObjList = new List<GameObject>();

    public GameObject[] ForcedNeighbor = new GameObject[0];
    public GameObject[] BanNeighbor = new GameObject[0];

    Color VeryFirst;



    private void Start()
    {
       
        //this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        this.Invoke("GetNeighbor", 0.2f);
        this.VeryFirst = this.gameObject.GetComponent<Renderer>().material.color;
        
    }
    public List<GameObject> GetGameObjects()
    {
        return neighborObjList;
    }

    public void Search(GameObject gameObject, Color originalColor)  //gameObject 전 오브젝트 (+바꿔야할 색의) ,originalColor 전 오브젝트의 전 색
    {

        if (this.gameObject.GetComponent<Renderer>().material.color == originalColor && gameObject.GetComponent<Renderer>().material.color != originalColor)
        {
            this.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;// 색 바꾸기
            Debug.Log(this.gameObject.name+": "+ this.neighborObjList.Count);

            for (int i = 0; i < this.neighborObjList.Count; i++)
            {
                Debug.Log(this.gameObject.name+": "+ i);

                this.neighborObjList[i].gameObject.GetComponent<ObjControl>().Search(this.gameObject, originalColor);        //인접 큐브에 전파;
                //Debug.Log("Hello");
            }


        }
    }
   
    //////////////////////////////////////////

    
    
    void GetNeighbor()
    {
        this.neighborObjList = this.gameObject.GetComponent<GetNeighbor>().neighborObj();
        
        for (int i = 0; i < this.ForcedNeighbor.Length; i++)
        {
            if(!this.neighborObjList.Contains(ForcedNeighbor[i]))
                this.neighborObjList.Add(ForcedNeighbor[i]);
        }
        for (int i = 0; i < this.BanNeighbor.Length; i++)
        {
            if (this.neighborObjList.Contains(ForcedNeighbor[i]))
                this.neighborObjList.Remove(ForcedNeighbor[i]);
        }

        if (this.neighborObjList[neighborObjList.Count - 1] ==null)
            this.neighborObjList.RemoveAt(neighborObjList.Count - 1);
        Debug.Log(transform.name +":  "+ neighborObjList.Count );
        Destroy(this.GetComponent<GetNeighbor>());

    }

}

