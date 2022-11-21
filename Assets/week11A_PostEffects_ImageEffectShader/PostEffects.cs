using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// execute in edit mode
[ExecuteInEditMode] 
public class PostEffects : MonoBehaviour
{
    Shader myShader;        // image effect shader 
    Material myMaterial;    

    void Start()
    {
        myShader = Shader.Find("My/PostEffects/DefaultShader");    // image effect shader file must have been created
        myMaterial = new Material(myShader);                
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
        Graphics.Blit(source, destination, myMaterial, 0);
    }
}

