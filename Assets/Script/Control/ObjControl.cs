using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjControl : MonoBehaviour
{



    List<GameObject> neighborObjList = new List<GameObject>();

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

        Debug.Log("Hello");
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

        // 현재 true 가 된 processed 를 다시 false로 바꿔줄 방법이 없습니다
        // dfs의 visit기능을 만들어 주려는 의도로 파악했습니다만 한번만 Search하고 끝나는 것이 아니므로 이런 방식으로는 무리가 있습니다.
        // 단순히 gameObject.color != originalColor  &&  this.color == originalColor 정도만 확인해도 문제 없을겁니다  (전자는 혹시 같은 색이 들어갔을 때 와리가리 방지)
        // gameObject.color 같은 표현은 이 정도로 충분히 이해할 수 있을 거라고 생각해서 쓴겁니다 실제 적용하려면 this.GetComponent<Renderer>().material.color 표현이 옳습니다
        // OnCollision기능보다 효율적인 방법을 생각해 보았습니다 어떤식으로 작용하는지 생각해보고 왜 invoke로 굳이 지연을 시켰는지 알아봅시다.
        //*****************************************************************************************************************

        //Debug.Log("this r g b" + this.GetComponent<Renderer>().material.color.r+ " "+ this.GetComponent<Renderer>().material.color.g +" "+ this.GetComponent<Renderer>().material.color.b);
        //Debug.Log("Org r g b" + originalColor.r + " " + originalColor.g + " " + originalColor.b);
        //Debug.Log("gameObject r g b" + gameObject.GetComponent<Renderer>().material.color.r + " " + gameObject.GetComponent<Renderer>().material.color.g + " " + gameObject.GetComponent<Renderer>().material.color.b);


        if (this.GetComponent<Renderer>().material.color == originalColor && gameObject.GetComponent<Renderer>().material.color != originalColor)
        {
            this.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;// 색 바꾸기
            //Debug.Log("Hello");
            for (int i = 0 ; i < neighborObjList.Count; i++)
            {
                neighborObjList[i].GetComponent<ObjControl>().Search(this.gameObject,originalColor);        //인접 큐브에 전파;
               // Debug.Log("Hello");
            }


        }

        //processed = true;




        //gameObject.GetComponent<ObjControl>().processed = true;
        // + (추가해야 할 것)
        //현재 search를 실행중인 obj(this)를 클릭했을 때의 event를 호출 ..?  //  그 
        //(this의 인접 obj에 대해 Search()를 호출하는 효과)
    }

    //////////////////////////////////////////

  

    void SearchNear(Queue<GameObject> gameObjects, GameObject Start)
    //SearchNear 함수는 queue에 담긴 Obj를 top부터 확인하며 최초로 start와 다른 색을 지닌 Obj를 Search함수로 보내는 함수입니다 잔여 queue는 clear해줍니다.
    //아마? gameObjects[0] ==start일 것 같긴 한데 버그 방지 (당연히 gameObjects[0] 는 이해를 위한 표현입니다)
    {

    }

    void GetNeighbor()
    {
        neighborObjList = this.GetComponent<Test>().neighborObj();
        Destroy(this.GetComponent<Test>());


        if (neighborObjList.Count == 0)
            Debug.Log("None");
        Debug.Log(neighborObjList.Count);

        for (int i = 0; i < neighborObjList.Count; i++)
        {
            Debug.Log(" In Obj Con "+neighborObjList[i].name);
        }

    }

}

  