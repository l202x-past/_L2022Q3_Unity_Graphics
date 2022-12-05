using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshScripting_Pyramid_Normals : MonoBehaviour
{
	Vector3 V0, V1, V2, V3, V4;
	Vector3[] newVertices;
	int[] newTriangles;
	Vector3[] normals;

	void Start()
	{
		V0 = new Vector3(-0.5f, 0, -0.5f);
		V1 = new Vector3(-0.5f, 0, 0.5f);
		V2 = new Vector3(0.5f, 0, 0.5f);
		V3 = new Vector3(0.5f, 0, -0.5f);
		V4 = new Vector3(0, 1, 0);

		newVertices = new Vector3[]
		{
			// Bottom
			V0, V1, V2, V3,

			// Front
			V2, V4, V1,

			// Left
			V3, V4, V2,

			// Right
			V1, V4, V0,

			// Back
			V0, V4, V3				
		};

		newTriangles = new int[]
		{
			// Bottom
			0, 2, 1,
			0, 3, 2,

			// Front
			4, 5, 6,

			// Left
			7, 8, 9,

			// Right
			10, 11,12,

			// Back
			13, 14, 15
		};

		Vector3 Down = Vector3.down;
		Vector3 Front = Vector3.forward;
		Vector3 Left = Vector3.left;
		Vector3 Right = Vector3.right;
		Vector3 Back = Vector3.back;

		normals = new Vector3[]
		{
			// Bottom
			Down, Down, Down, Down,
 
			// Front
			Front, Front, Front,
 
			// Left
			Left, Left, Left,			
 
			// Right
			Right, Right, Right,

			// Back
			Back, Back, Back
		};

		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();

		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		mesh.vertices = newVertices;
		mesh.triangles = newTriangles;
		mesh.normals = normals;

		Shader DefaultShader = Shader.Find("Standard");
		Material DefaultMaterial = new Material(DefaultShader);
		gameObject.GetComponent<Renderer>().material = DefaultMaterial;
	}
}
