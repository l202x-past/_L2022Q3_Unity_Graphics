using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GettingStartedWith_Text : MonoBehaviour
{
    public GameObject MyGameObject;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = MyGameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
