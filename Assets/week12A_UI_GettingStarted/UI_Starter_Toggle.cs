using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Starter_Toggle : MonoBehaviour
{
    Material MyMaterial;
    public GameObject MyGameObject; // 인스펙터로 받아야하므로 public으로
    bool isOn;
    Color c1, c2;
    // Start is called before the first frame update
    void Start()
    {
        MyMaterial = MyGameObject.GetComponent<Renderer>().material;

        c1 = new Color(1, 1, 1, 1);
        c2 = new Color(1, 0, 0, 1);
    }

    // Update is called once per frame
   public void OnValueChanged_SetColor()
    {
        isOn = GetComponent<Toggle>().isOn;
        if (isOn)
        {
            MyMaterial.SetColor("_Color", c1); 
        }
        else
        {
            MyMaterial.SetColor("_Color", c2);
        }
    }

}
