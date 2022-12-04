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

		Vector3 Up = Vector3.up;
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

		/*
		Vector3 N0 = Vector3.back + Vector3.left;
		Vector3 N1 = Vector3.forward + Vector3.left;
		Vector3 N2 = Vector3.forward + Vector3.right;
		Vector3 N3 = Vector3.back + Vector3.right;
		Vector3 N4 = Vector3.up;

		normals = new Vector3[]
		{
			// Bottom
			N0, N1, N2, N3,
 
			// Front
			N2, N4, N1,
 
			// Left
			N3, N4, N2,			
 
			// Right
			N1, N4, N0,

			// Back
			N0, N4, N3
		};
		*/

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
