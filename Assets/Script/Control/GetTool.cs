using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTool : MonoBehaviour
{
    public int num;
    public int OtherPiecenum =1;
    public GameObject[] OtherPiece;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.Tool[num] >= 1)
        {
            this.gameObject.SetActive(false);
        }


        else
        {
            OtherPiece = new GameObject[OtherPiecenum];
        }
    }
    public void SetTool() {
        GameManager.Instance.SetTool(this.num);
        for(int i= OtherPiecenum - 1; i>=0 ; i--)
        {
            OtherPiece[i].SetActive(false);
        }
        this.gameObject.SetActive(false);

    }


    
}
