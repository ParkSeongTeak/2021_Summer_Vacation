using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockHide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //W키를 누르면 마우스 커서를 게임 중앙 좌표에 고정 시키고 마우스 커서가 보임
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.lockState = CursorLockMode.None;
            // 마우스 커서 보이게 함
            Cursor.visible = true;
        }
        //Q키를 누르면 마우스 커서를 게임 중앙 좌표에 고정시키고 마우스 커서 안보임
        if (Input.GetKeyDown(KeyCode.W))
        {
            Cursor.lockState = CursorLockMode.Locked;
            //마우스 커서 보이지 않게함
            Cursor.visible = false;
        }

    }
}
