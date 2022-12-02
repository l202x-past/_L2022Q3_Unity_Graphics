using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffects_Blend_Class : MonoBehaviour
{
    Material myMaterial;
    Shader myShader;
    public Texture2D BlendTexture;
    public float opacity;


    // Start is called before the first frame update
    void Start()
    {
        myShader = Shader.Find("My/PostEffects/Blend_Class");
        myMaterial = new Material(myShader);
    }

    // Update is called once per frame
    void Update()
    {
        opacity = Mathf.Clamp(opacity, 0.0f, 1.0f);
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        myMaterial.SetFloat("_Opacity", opacity);
        myMaterial.SetTexture("_BlendTex", BlendTexture);
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
