using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GettingStartedWith_Slider : MonoBehaviour
{
    public GameObject MyGameObject;
    Material MyMaterial;

    void Start()
    {
        MyMaterial = MyGameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnValueChanged_SetColor()
    {
        float sliderValue = GetComponent<Slider>().value;
        print(sliderValue);
        Color c = new Color(sliderValue, sliderValue, sliderValue, 1);
        MyMaterial.SetColor("_Color", c);
    }
}
