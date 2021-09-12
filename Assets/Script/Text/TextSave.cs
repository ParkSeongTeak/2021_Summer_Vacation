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
            new KeyValuePair<int, string>( 1,"이용자의 뇌에 직접 연결하는 BCI 프로그램의 특성상,백신작업 또한 과도하게 이루어질 경우 뇌에 심각한 부담이 가해질 수 있습니다.") ,
            new KeyValuePair<int, string>( 1,"이에 따라, 이용자에게 가해지는 스트레스 수치를 최소화하는 기술들을 이용하여백신 작업을 진행해야 합니다.") ,
            new KeyValuePair<int, string>( 1,"첫 번째 알려드릴 기술은 ‘색 전이’ 기술입니다. 인접한 색을 전이시킬 수 있는 매우 기본적인 기술이며, 스트레스 수치를 10 증가시킵니다.") ,
            new KeyValuePair<int, string>( 1,"해당 기술을 이용하여 현재 방의 모든 벽면을 백색으로 변경하십시오.") ,
            new KeyValuePair<int, string>( 1,"Objective: 모든 벽면을 백색으로 변경.") 

        });
        ///////////////////////////////////////////////////////////////////
        talkData.Add("예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"기본적인 응용 기술을 습득합니다.") ,
            new KeyValuePair<int, string>( 1,"'색 전이' 기술을 이용하여 스트세스 수치가 20을 넘지 않게하여모든 벽면을 백색으로 변경하십시오.") ,
            new KeyValuePair<int, string>( 1,"Objective: 모든 벽면을 백색으로 변경.")

        });
        /*
        talkData.Add("노", new KeyValuePair<int, string>[] {
        });
        */

        ///////////////////////////////////////////////////////////////////

        
        talkData.Add("예예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"‘색 전이’ 기술을 이용하여 스트세스 수치가 20을 넘지 않게하여모든 벽면을 백색으로 변경하십시오.") ,
            new KeyValuePair<int, string>( 1,"Objective: 모든 벽면을 백색으로 변경.") ,
            
        });
        
        /*
        talkData.Add("노예", new KeyValuePair<int, string>[] {});
        talkData.Add("예노", new KeyValuePair<int, string>[] {});
        talkData.Add("노노", new KeyValuePair<int, string>[] {});
        */

        ///////////////////////////////////////////////////////////////////


        talkData.Add("예예예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"복잡한 구조물입니다.") ,
            new KeyValuePair<int, string>( 1,"‘색 전이’ 기술을 이용하여 스트세스 수치가 50을 넘지 않게하여 모든 벽면을 백색으로 변경하십시오.") ,
            new KeyValuePair<int, string>( 1,"Objective: 모든 벽면을 백색으로 변경.") 

        });
        /*
        talkData.Add("노예예", new KeyValuePair<int, string>[] {});
        talkData.Add("예노예", new KeyValuePair<int, string>[] {});
        talkData.Add("노노예", new KeyValuePair<int, string>[] {});
        talkData.Add("예예노", new KeyValuePair<int, string>[] {});
        talkData.Add("노예노", new KeyValuePair<int, string>[] {});
        talkData.Add("예노노", new KeyValuePair<int, string>[] {});
        talkData.Add("노노노", new KeyValuePair<int, string>[] {});
        */
        talkData.Add("예예예예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"작업자가 변경할 수 없는 중요한 기반시스템코드는 검은색으로 표기되며, 검은색은 어떠한 경우에도 그 색을 변경시킬 수 없습니다.") ,
            new KeyValuePair<int, string>( 1,"추후 별도의 설명이 없더라도 검은색을 제외한 벽면만이 테스트 대상이 됩니다.") ,
            new KeyValuePair<int, string>( 1,"‘색 전이’ 기술을 이용하여 스트세스 수치가 30을 넘지 않게하여 모든 벽면을 백색으로 변경하십시오."),
            new KeyValuePair<int, string>( 1,"Objective: (검은 벽면을 제외한) 모든 벽면을 백색으로 변경")
        });
        talkData.Add("예예예예예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"복잡한 구조물입니다."),
            new KeyValuePair<int, string>( 1,"‘색 전이’ 기술을 이용하여 스트세스 수치가 50을 넘지 않게하여 모든 벽면을 백색으로 변경하십시오."),
            new KeyValuePair<int, string>( 1,"Objective: 모든 벽면을 백색으로 변경.")

        });
        talkData.Add("예예예예예예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"복잡한 구조물입니다."),
            new KeyValuePair<int, string>( 1,"‘색 전이’ 기술을 이용하여 스트세스 수치가 40을 넘지 않게하여 모든 벽면을 백색으로 변경하십시오."),
            new KeyValuePair<int, string>( 1,"Objective: 모든 벽면을 백색으로 변경.")

        });
        talkData.Add("예예예예예예예", new KeyValuePair<int, string>[] {
            new KeyValuePair<int, string>( 1,"1 Stage의 모든 시험을 통과하셨습니다. 다음 단계로 넘어가기 위해 콘솔로 진입하여 다음 단계를 로드하여주시기 바랍니다."),
            new KeyValuePair<int, string>( 1,"다음 단계로 진입하시겠습니까?")

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
