using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjControl : MonoBehaviour
{
    List<GameObject> arrayList = new List<GameObject>();

    private void Start()
    {
        Invoke("GetNeighbor", 0.2f);
           
       
    }
    //Collion

    //전체 gamemanager에 bool processing 변수 추가
    //어떤 obj에 클릭 발생하여 인접 obj 검색 및 색 변경 작업 중인지 여부를 나타냄

    //클릭 이벤트 발생 시 모든 obj의 processed를 0으로 초기화!!! ..?

    ///////////////////////////////////////////

    //이 obj의 인접 obj에 대해 search 실행했는지 여부
    //이 obj의 인접 obj가 search를 실행하면서 true로 변경해줌
    bool processed = false;

    
    public void Search(GameObject gameObject, Color originalColor)
    {


        //이 함수를 돌리면 인접 Obj 태그의 색이 원래 색과(originalColor) 같았는지 검사해 이 스크립트를 가진 오브젝트의 색도 전달받은 오브젝트(gameObject)의 색으로 바꾼다.
        //구현을 위한 가장 단순한 예시로 bool Run = false;
        //Run = true;


        //*****************************************************************************************************************
        //박성택 수정사항
        //this.GetComponent<Renderer>().material.color 에 대하여
        //this는 현재 클래스고 음 객체에 붙어있는 스크립트입니다 
        //이 Script가 붙어있는 GameObject 를 사용하고 싶다면 this.gameObject 
        //이 Script가 붙어있는 GameObject 의 다른 class 예를 들자면 Renderer 내 기능인 material을 사용하고 싶다면 this.GetComponent<Renderer>().material 이런 식으로 접근해야 합니다
        //Google에 "unity 객체의 .... 에 접근하기 " 식으로 찾아보면 잘 나옵니다

        //현재 true 가 된 processed 를 다시 false로 바꿔줄 방법이 없습니다

        //*****************************************************************************************************************

        if (this.GetComponent<Renderer>().material.color == originalColor)
        {
            this.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
        }



        //gameObject.GetComponent<ObjControl>().processed = true;
        // + (추가해야 할 것)
        //현재 search를 실행중인 obj(this)를 클릭했을 때의 event를 호출 ..?  //  그 
        //(this의 인접 obj에 대해 Search()를 호출하는 효과)
    }

    //////////////////////////////////////////

    /*
    public void OnCollisionStay(Collision collision)
    {
        if (!processed)
        {
            Color orgColor;

            //if (칠하려는 색 != 현재 색)
            //  이 obj의 현재 색을 저장
            orgColor = this.GetComponent<Renderer>().material.color;
            //  이 obj를 칠하려는 색으로 변경

            //collision.gameObject(충돌체)에 대해 Search(클릭된 obj, 저장해둔 현재 색) 호출
            collision.gameObject.GetComponent<ObjControl>().Search(this.gameObject, orgColor);
        }
    }
    
*/
    
    void SearchNear(Queue<GameObject> gameObjects, GameObject Start) 
    //SearchNear 함수는 queue에 담긴 Obj를 top부터 확인하며 최초로 start와 다른 색을 지닌 Obj를 Search함수로 보내는 함수입니다 잔여 queue는 clear해줍니다.

    {
        
    }

    void GetNeighbor()
    {
        arrayList = this.GetComponent<Test>().neighborObj();
        Destroy(this.GetComponent<Test>());


        if (arrayList.Count == 0)
            Debug.Log("None");
        Debug.Log(arrayList.Count);

        for (int i = 0; i < arrayList.Count; i++)
        {
            Debug.Log(" In Obj Con "+arrayList[i].name);
        }

    }

}

  