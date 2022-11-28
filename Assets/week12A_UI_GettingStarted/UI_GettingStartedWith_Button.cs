using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GettingStartedWith_Button : MonoBehaviour
{
    public InputField InputFieldConponemt;
    public Text TextComponent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_SetText()
    {
        TextComponent.text = InputFieldConponemt.text;
    }
}
