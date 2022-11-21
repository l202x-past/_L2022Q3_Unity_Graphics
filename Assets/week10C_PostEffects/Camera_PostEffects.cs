using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_PostEffects : MonoBehaviour
{
    [ExecuteInEditMode]
    public Shader myShader;
    Material myMaterial;

    Material material
    {
        get
        {
            if (myMaterial == null)
            {
                myMaterial = new Material(myShader);
                myMaterial.hideFlags = HideFlags.HideAndDontSave;
            }
            return myMaterial;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myShader = Shader.Find("My/PostEffects/DefaultShader");
        GetComponent<Camera>().allowHDR = true;
        GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Camera>().enabled)
        {
            return;
        }
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
        if(myShader != null)
        {
            Graphics.Blit(source, destination, material, 0);
        }
    }
}
