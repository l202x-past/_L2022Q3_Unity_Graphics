using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveShader_Controller : MonoBehaviour
{
    int brightness;
    Renderer MyRenderer;

    private void Start()
    {
        MyRenderer = gameObject.GetComponent<Renderer>();
        brightness = 1;
        MyRenderer.material.SetInt("_Brightness", 1);
    }

    private void OnMouseDown()
    {        
        brightness = -1 * brightness;
        MyRenderer.material.SetInt("_Brightness", brightness);
        print(gameObject.name + "," + brightness);
    }
}
