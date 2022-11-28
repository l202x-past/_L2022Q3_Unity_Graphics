using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Starter_Button : MonoBehaviour
{
    public InputField InputFieldComponent;
    public Text TextComponent;
 
    public void OnClick_SetText()
    {
        TextComponent.text = InputFieldComponent.text;
    }

}
