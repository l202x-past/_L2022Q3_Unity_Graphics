using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Starter_Slider : MonoBehaviour
{
    public GameObject MyGameObject;
    Material MyMaterial;
    // Start is called before the first frame update
    void Start()
    {
        MyMaterial = MyGameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // 내장메서드 아님. 새로 만든 것. 
    public void OnValueChanged_SetColor()
    {
        float val = GetComponent<Slider>().value;
        print(val);
        Color c = new Color(val, val, val, 1);
        MyMaterial.SetColor("_Color", c);

    }
}
