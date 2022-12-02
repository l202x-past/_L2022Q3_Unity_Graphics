using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShowPostEffect : MonoBehaviour
{
	Shader Shad;
	Material Mat;

	// Start is called before the first frame update
	void Start()
	{
		print("PostEffect script start");
		Shad = Shader.Find("Lecture/week11/PostEffect");
		Mat = new Material(Shad);
	}

	// Update is called once per frame
	// void Update()
	// {

	// }

	/// <summary>
	/// OnRenderImage is called after all rendering is complete to render image.
	/// </summary>
	/// <param name="src">The source RenderTexture.</param>
	/// <param name="dest">The destination RenderTexture.</param>
	public void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, Mat, 0); // 0은 생략해도 됨(셰이더에서 몇 번째 pass를 사용할지 지정)
	}

	/// <summary>
	/// This function is called when the behaviour becomes disabled or inactive.
	/// </summary>
	public void OnDisable()
	{
		if (Mat)
		{
			DestroyImmediate(Mat);
		}
	}
}
