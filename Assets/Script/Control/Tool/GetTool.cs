using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTool : MonoBehaviour
{
    public int num;
    public int OtherPiecenum =1;
    public GameObject[] OtherPiece;
    public GameObject button;
    public GameObject ToolBox;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.Tool[num] >= 1)
        {
            this.gameObject.SetActive(false);
        }


        
    }
    public void SetTool() {
        Debug.Log("SetTool");
        GameManager.Instance.SetTool(this.num);
        for(int i= this.OtherPiecenum - 1; i>=0 ; i--)
        {
            this.OtherPiece[i].SetActive(false);

        }
        this.gameObject.SetActive(false);

        ToolBox.GetComponent<Tool>().ToolStateSet(this.num, 1);
    }


    
}
