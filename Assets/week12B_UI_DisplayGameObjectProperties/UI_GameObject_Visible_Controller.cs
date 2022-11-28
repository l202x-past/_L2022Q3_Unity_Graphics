using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameObject_Visible_Controller : MonoBehaviour
{
    Camera TargetCamera;
    public bool isVisible = true;

    // Start is called before the first frame update
    void Start()
    {
        TargetCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBecameVisible()
    {
        isVisible = true;
        //enabled = true;
        //GetComponent<Renderer>().enabled = true;
        print("became visible");
    }

    private void OnBecameInvisible()
    {
        isVisible = false;
        //enabled = false;
        //GetComponent<Renderer>().enabled = false;
        print("became invisible");
    }
}
