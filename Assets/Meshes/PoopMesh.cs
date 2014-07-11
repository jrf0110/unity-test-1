using UnityEngine;
using System.Collections;

public class PoopMesh : MonoBehaviour {
  public Vector3[] newVertices;
  public Vector2[] newUV;
  public int[] newTriangles;

  void Start() {
    Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    if (mesh==null){
        Debug.LogError("MeshFilter not found!");
        return;
    }
     
    Vector3 p0 = new Vector3(0,0,0);
    Vector3 p1 = new Vector3(1,0,0);
    Vector3 p2 = new Vector3(0.5f,0,Mathf.Sqrt(0.75f));
    Vector3 p3 = new Vector3(0.5f,Mathf.Sqrt(0.75f),Mathf.Sqrt(0.75f)/3);

    mesh.Clear();
     
    mesh.vertices = new Vector3[]{
        p0,p1,p2,
        p0,p2,p3,
        p2,p1,p3,
        p0,p3,p1
    };
    mesh.triangles = new int[]{
        0,1,2,
        3,4,5,
        6,7,8,
        9,10,11
    };
     
    mesh.RecalculateNormals();
    mesh.RecalculateBounds();
    mesh.Optimize();
  }
}