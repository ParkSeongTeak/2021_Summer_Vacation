using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjControl : MonoBehaviour
{
    
    public void Search(GameObject gameObject, Color originalColor)
    {
        //이 함수를 돌리면 인접 Obj 태그의 색이 원래 색과(originalColor) 같았는지 검사해 이 스크립트를 가진 오브젝트의 색도 전달받은 오브젝트(gameObject)의 색으로 바꾼다.
        //구현을 위한 가장 단순한 예시로 bool Run = false;
        //Run = true;

    }
    //아래는 충돌 이벤트
    //private void OnCollisionEnter(Collision collision)
    //{
        //if(Run){.... Run = false}
    //}
    
}
