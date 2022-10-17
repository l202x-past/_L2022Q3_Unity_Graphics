using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_SwitchController : MonoBehaviour
{
    public GameObject DomeLightCover;
    public GameObject DomeLight;
    bool isActive = false;
    public Material MatOn, MatOff;
    Material[] Materials;

    private void Start()
    {
        DomeLight.SetActive(false);
        Materials = DomeLightCover.GetComponent<Renderer>().materials;
        print(Materials.Length);
        Materials[1] = MatOff;
        DomeLightCover.GetComponent<Renderer>().materials = Materials;
    }
    private void OnMouseDown()
    {
        isActive = !isActive;
        DomeLight.SetActive(isActive);
        if (isActive)
        {
            //DomeLightCover.GetComponent<Renderer>().materials[1] = MatOn;
            Materials[1] = MatOn;
            DomeLightCover.GetComponent<Renderer>().materials = Materials;
        }
        else
        {
            //DomeLightCover.GetComponent<Renderer>().material[1] = MatOff;
            Materials[1] = MatOff;
            DomeLightCover.GetComponent<Renderer>().materials = Materials;
        }
    }
}
