using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjControl : MonoBehaviour
{
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

        if (this.material.color == originalColor)
        {
            this.material.color = gameObject.material.color;
        }
        gameObject.processed = true;
        // + (추가해야 할 것)
        //현재 search를 실행중인 obj(this)를 클릭했을 때의 event를 호출 ..?
        //(this의 인접 obj에 대해 Search()를 호출하는 효과)
    }

    //////////////////////////////////////////

    public void OnCollisionStay(Collision collision)
    {
        if (!processed)
        {
            Color orgColor;

            //if (칠하려는 색 != 현재 색)
            //  이 obj의 현재 색을 저장
            orgColor = this.material.color;
            //  이 obj를 칠하려는 색으로 변경

            //collision.gameObject(충돌체)에 대해 Search(클릭된 obj, 저장해둔 현재 색) 호출
            collision.gameObject.Search(this, orgColor);
        }
    }
}

    //////////////////////////////////////////

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
