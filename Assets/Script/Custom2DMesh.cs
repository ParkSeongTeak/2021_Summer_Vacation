using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Custom2DMesh : MonoBehaviour
{
    public Transform[] vertexs;

    [Header("Vertexs에 따라 만든 Mesh로 업데이트시킬 컴포넌트들")]
    public MeshFilter meshFilter;
    public MeshCollider meshCollider;
    public LineRenderer meshLine;

    private Mesh mesh;
    private List<int> triangleList;

    // Use this for initialization
    void Start()
    {
        mesh = new Mesh();
        triangleList = new List<int>();

        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;

        MeshCreate();
        StartCoroutine(LowUpdate(0.015f));

    }

    IEnumerator LowUpdate(float timeInterval)
    {
        while (Application.isPlaying)
        {
            MeshCreate();
            RecalculateCollider();
            ResettingLinePos();
            yield return new WaitForSeconds(timeInterval);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < vertexs.Length; i++)
            Gizmos.DrawSphere(vertexs[i].position, 0.3f);

    }
    void ResettingLinePos()
    {
        //메쉬 외곽선 그리기
        meshLine.positionCount = vertexs.Length;
        Vector3[] positions = new Vector3[vertexs.Length];
        for (int i = 0; i < vertexs.Length; i++)
            positions[i] = vertexs[i].position;

        //실제 삼각면 외곽선 그리기
        //meshLine.positionCount = triangleList.Count;
        //Vector3[] positions = new Vector3[triangleList.Count];
        //for (int i = 0; i < triangleList.Count; i++)
        //    positions[i] = vertexs[triangleList[i]].position;

        meshLine.SetPositions(positions);
    }
    void RecalculateCollider()
    {
        //quickhull 알고리즘 오류 판정
        if (meshCollider.sharedMesh != null && mesh.triangles.Length >= 3 &&
            transform.position.magnitude > 0 && mesh.triangles.Length < 255)
        {
            meshCollider.convex = true;
        }
    }
    void MeshCreate()
    {
        mesh.Clear();

        Vector3[] vertexPos = new Vector3[vertexs.Length];
        for (int i = 0; i < vertexs.Length; i++)
            vertexPos[i] = vertexs[i].position;

        mesh.vertices = vertexPos;

        #region triangles를 List기반으로 설정한다. 요소 내용을 new int[] { 0, 2, 1, 0, 3, 2 , 0, 1, 2, 0, 2, 3}; 이 형태로 초기화한다.
        triangleList.Clear();
        int triangleStack = 0;

        //안에서 보는 면 연결
        //꼭짓점이 3개라면 삼각형은 1개가 나온다. 4개라면 2개가 나와야한다.
        for (int i = 0; i < (vertexPos.Length - 2) * 3; i += 3)
        {
            triangleList.Add(0);
            triangleList.Add(++triangleStack + 1);
            triangleList.Add(triangleStack);
        }

        triangleStack = 0;
        //바깥에서 보는 면 연결
        for (int i = (vertexPos.Length - 2) * 3; i < (vertexPos.Length - 2) * 3 * 2; i += 3)
        {
            triangleList.Add(0);
            triangleList.Add(++triangleStack);
            triangleList.Add(triangleStack + 1);
        }
        mesh.triangles = triangleList.ToArray();
        #endregion

        //mesh.RecalculateBounds();
        //mesh.RecalculateTangents();
        mesh.RecalculateNormals();
        //mesh.Optimize(); //이후의 메쉬 연산을 최적화한다
    }
}