using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDragJH : MonoBehaviour //JH
{

    public bool isDragWorking;
    bool isRenderingWorking;
    [SerializeField]
    Camera mainCam;
    Ray initialRay = new Ray(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
    Ray lastRay = new Ray(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
    Vector2 initialPoint = new Vector2(0, 0);
    Vector2 lastPoint = new Vector2(0, 0);
    RaycastHit initialRayHit;
    RaycastHit lastRayHit;
    public GameObject BrushLineObject;

    Coroutine dragRenderC;

    IEnumerator DragRendering(){
        BrushLineObject.SetActive(true);
        initialRay = new Ray(mainCam.transform.position, new Vector3(0, 0, 0));
        lastRay = new Ray(mainCam.transform.position, new Vector3(0, 0, 0));
        initialRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Vector2 pointDirection;
        if(Physics.Raycast(initialRay,out initialRayHit,1000f)){
            initialPoint = (Vector2)mainCam.WorldToScreenPoint(initialRayHit.point);
        }
        while(Input.GetMouseButton(0)){;
            lastRay = mainCam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(lastRay,out lastRayHit,1000f)){
                lastPoint = (Vector2)mainCam.WorldToScreenPoint(lastRayHit.point);
            }
            if(mainCam.WorldToScreenPoint(initialRayHit.point).z>0f)
                initialPoint = (Vector2)mainCam.WorldToScreenPoint(initialRayHit.point);
            Debug.Log(mainCam.WorldToScreenPoint(initialRayHit.point));
            BrushLineObject.GetComponent<RectTransform>().position = initialPoint;
            BrushLineObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Vector2.Distance((Vector2)initialPoint, (Vector2)lastPoint)*2f+30f, 89f);
            pointDirection = Quaternion.Euler(0, 0, 90f) *((Vector2)lastPoint - (Vector2)initialPoint);
            BrushLineObject.GetComponent<RectTransform>().rotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: pointDirection);
            if(Vector2.Distance((Vector2)initialPoint, (Vector2)lastPoint)<100f)
                BrushLineObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, Vector2.Distance((Vector2)initialPoint, (Vector2)lastPoint) / 100f);
            else
                BrushLineObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            yield return null;
        }
        BrushLineObject.SetActive(false);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(lastRay);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&(isRenderingWorking==false)){
            dragRenderC = StartCoroutine(DragRendering());
        }
    }
}
