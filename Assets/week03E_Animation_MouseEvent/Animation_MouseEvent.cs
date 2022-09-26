using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_MouseEvent : MonoBehaviour
{
    Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 0;
    }

    void Update()
    {
        
    }

    /************************************************
     * MonoBehavior
     * https://docs.unity3d.com/2020.3/Documentation/ScriptReference/MonoBehaviour.html
     ************************************************/
    private void OnMouseDown()
    {
        Anim.speed = 1;
    }
}
