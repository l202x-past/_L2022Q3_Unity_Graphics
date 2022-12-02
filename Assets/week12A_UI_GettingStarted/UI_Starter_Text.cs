using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// UI 오브젝트의 컴포넌트를 가져오려면  using UnityEngine.UI 적어야 함. 

public class UI_Starter_Text : MonoBehaviour
{
    public GameObject MyGameObject;
    // Start is called before the first frame update
    void Start()
    {
        string name = MyGameObject.name;
        name += " made by hwang";
        GetComponent<Text>().text = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
