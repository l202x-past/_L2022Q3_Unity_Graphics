using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashScripting_UV_Quad2 : MonoBehaviour
{
    Vector3 V0, V1, V2, V3;
    Vector3[] newVertices;
    int[] newTriangles;

    Vector2 UV0, UV1, UV2, UV3;
    Vector2[] newUVs;

    public Texture newTexture;

    // Start is called before the first frame update
    void Start()
    {
        V0 = new Vector3(0, 0, 0);
        V1 = new Vector3(0, 1, 0);
        V2 = new Vector3(1, 1, 0);
        V3 = new Vector3(1, 0, 0);

        newVertices = new Vector3[]
        {
            V0, V1, V2, V3
        };

        newTriangles = new int[]
        {
            0, 1, 2,
            0, 2, 3
        };

        //UV0 = new Vector2(0, 0);
        //UV1 = new Vector2(0, 1);
        //UV2 = new Vector2(1, 1);
        //UV3 = new Vector2(1, 0);

        UV0 = new Vector2(0, 0.333f);
        UV1 = new Vector2(0, 0.666f);
        UV2 = new Vector2(0.25f, 0.666f);
        UV3 = new Vector2(0.25f, 0.333f);

        newUVs = new Vector2[]
        {
            UV0, UV1, UV2, UV3
        };

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;
        mesh.uv = newUVs;

        Shader DefaultShader = Shader.Find("Standard");
        Material DefaultMaterial = new Material(DefaultShader);
        DefaultMaterial.mainTexture = newTexture;
        gameObject.GetComponent<Renderer>().material = DefaultMaterial;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
