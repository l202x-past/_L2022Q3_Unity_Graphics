using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffects_Depth_Class : MonoBehaviour
{
    Shader myShader;
    Material myMaterial;
    public float depth;

    // Start is called before the first frame update
    void Start()
    {
        myShader = Shader.Find("My/PostEffects/Depth_Class");
        myMaterial = new Material(myShader);
    }

    // Update is called once per frame
    void Update()
    {
        depth = Mathf.Clamp(depth, 0.0f, 1.0f);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        myMaterial.SetFloat("_Depth", depth);
        Graphics.Blit(source, destination, myMaterial, 0);
    }

    private void OnDisable()
    {
        if (myMaterial)
        {
            DestroyImmediate(myMaterial);
        }
    }

}
