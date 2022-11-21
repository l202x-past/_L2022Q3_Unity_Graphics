using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffects_GrayScale : MonoBehaviour
{
    Shader myShader;        // image effect shader 
    Material myMaterial;

    public float grayScaleAmount = 1.0f;

    void Start()
    {
        myShader = Shader.Find("My/PostEffects/GrayScale");    // image effect shader file must have been created
        myMaterial = new Material(myShader);
    }

    private void Update()
    {
        grayScaleAmount = Mathf.Clamp(grayScaleAmount, 0.0f, 1.0f); 
    }

    private void OnDisable()
    {
        if (myMaterial)
        {
            DestroyImmediate(myMaterial);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        myMaterial.SetFloat("_GrayScaleAmount", grayScaleAmount);
        Graphics.Blit(source, destination, myMaterial);
    }
}

