using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjControl : MonoBehaviour
{
    /*
    public GameObject[] GameObj = new GameObject[5];

    public void Search(GameObject gameObject, Color originalColor)
    {

        //GameObj[0].color == this.color -> GameObj[0].search()
    }
    */

    public void OnCollisionStay(Collision collision)
    {
        Debug.Log("Hello!!");
    }
    /*
    //아래는 충돌 이벤트
    //private void OnCollisionEnter(Collision collision)
    //{
    //if(Run){
    // Color. color() =  본인 색 
    //this.Color = Obj.Color
    //collision.color == Color. color

    //true -> 색 바꾸고 -> search()

    //false -> 끝내고


    //Run = false}
    //}
    */
}
