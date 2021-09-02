using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSave : MonoBehaviour
{

    public static TextSave Instance;
    public Dictionary<string, KeyValuePair<int, string>[]> talkData;

    private void Awake()
    {
        //Debug.Log("Helloi");
        Instance =this;
        talkData = new Dictionary<string, KeyValuePair<int , string>[] >();
        GenerateData();
    }
    void GenerateData()
    {
        talkData.Add("0", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"안녕하세요") ,
            new KeyValuePair<int, string>( 1,"새로운 대화시스템을 고안중입니다") ,
            new KeyValuePair<int, string>( 2,"그러시군요") ,
            new KeyValuePair<int, string>( 1,"세상 쉬운일이 없네요") ,
            new KeyValuePair<int, string>( 1,"네 또는 아니요를 골라주세요") 

        });
        ///////////////////////////////////////////////////////////////////
        talkData.Add("예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"네 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"네 흠 ") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"아 참고로 저는 이번에 기숙사에 붙었답니다") ,
            new KeyValuePair<int, string>( 1,"오 정말 알고싶었던 정보였어요~~")

        });

        talkData.Add("노", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"아니요 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"아니요") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"아 참고로 저는 이번에 기숙사에 붙었답니다") ,
            new KeyValuePair<int, string>( 1,"오 정말 알고싶었던 정보였어요~~")

        });


        ///////////////////////////////////////////////////////////////////


        talkData.Add("예예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"네 네 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"네 네 흠 ") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"여러상황에 대충 대응 가능하도록 만들다는 뜻입니다") ,
            new KeyValuePair<int, string>( 1,"오 정말 알고싶었던 정보였어요~~")

        });

        talkData.Add("노예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"아니요 네 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"아니요 네") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"여러상황에 대충 대응 가능하도록 만들다는 뜻입니다") ,
            new KeyValuePair<int, string>( 1,"오 정말 알고싶었던 정보였어요~~")

        });
        talkData.Add("예노", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"네 아니요 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"네 아니요 흠 ") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"여러상황에 대충 대응 가능하도록 만들다는 뜻입니다") ,
            new KeyValuePair<int, string>( 1,"오 정말 알고싶었던 정보였어요~~")

        });

        talkData.Add("노노", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"아니요 아니요 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"아니요 아니요") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"여러상황에 대충 대응 가능하도록 만들다는 뜻입니다") ,
            new KeyValuePair<int, string>( 1,"오 정말 알고싶었던 정보였어요~~")

        });


        ///////////////////////////////////////////////////////////////////


        talkData.Add("예예예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"네네네 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"네네네 흠 ") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"모든 경우의 수를 따로따로 만드는건 귀찮군요") ,
            new KeyValuePair<int, string>( 1,"하지만 텍스트를 쓰는건 제가 아니니 상관이 없겠지요? ㅋㅋ")

        });

        talkData.Add("노예예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"아니오 네 네 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"아니오 네 네") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"모든 경우의 수를 따로따로 만드는건 귀찮군요") ,
            new KeyValuePair<int, string>( 1,"하지만 텍스트를 쓰는건 제가 아니니 상관이 없겠지요? ㅋㅋ")

        });
        talkData.Add("예노예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"네 아니요 네 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"네 아니요 네 흠 ") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"모든 경우의 수를 따로따로 만드는건 귀찮군요") ,
            new KeyValuePair<int, string>( 1,"하지만 텍스트를 쓰는건 제가 아니니 상관이 없겠지요? ㅋㅋ")

        });

        talkData.Add("노노예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"아니오 아니요 네를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"아니오 아니요 네") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"모든 경우의 수를 따로따로 만드는건 귀찮군요") ,
            new KeyValuePair<int, string>( 1,"하지만 텍스트를 쓰는건 제가 아니니 상관이 없겠지요? ㅋㅋ")

        });





        talkData.Add("예예노", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"네 네 아니요 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"네 네 아니요 흠 ") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"모든 경우의 수를 따로따로 만드는건 귀찮군요") ,
            new KeyValuePair<int, string>( 1,"하지만 텍스트를 쓰는건 제가 아니니 상관이 없겠지요? ㅋㅋ")

        });

        talkData.Add("노예노", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"아니요 네 아니요 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"아니요 네 아니요 ") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"모든 경우의 수를 따로따로 만드는건 귀찮군요") ,
            new KeyValuePair<int, string>( 1,"하지만 텍스트를 쓰는건 제가 아니니 상관이 없겠지요? ㅋㅋ")

        });
        talkData.Add("예노노", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"네 아니요 아니요 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"네 아니요 아니요 흠 ") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"모든 경우의 수를 따로따로 만드는건 귀찮군요") ,
            new KeyValuePair<int, string>( 1,"하지만 텍스트를 쓰는건 제가 아니니 상관이 없겠지요? ㅋㅋ")

        });

        talkData.Add("노노노", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"아니요 아니요 아니요 를 누르셨군요") ,
            new KeyValuePair<int, string>( 2,"아니요 아니요 아니요 ") ,
            new KeyValuePair<int, string>( 1,"그러시군요") ,
            new KeyValuePair<int, string>( 2,"모든 경우의 수를 따로따로 만드는건 귀찮군요") ,
            new KeyValuePair<int, string>( 1,"하지만 텍스트를 쓰는건 제가 아니니 상관이 없겠지요? ㅋㅋ")

        });



    }
/*
    private void Start()
    {
        Debug.Log("DataSave");
        talkData.TryGetValue("0", out KeyValuePair<int,string>[] data);
        for(int i = 0; i < data.Length; i++)
        {
            Debug.Log(data[i].Value);
            //PrintText();

        }
    }
*/
}
