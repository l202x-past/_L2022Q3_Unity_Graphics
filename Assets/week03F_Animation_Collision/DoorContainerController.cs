using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorContainerController : MonoBehaviour
{
    Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopAnimation()
    {
        Anim.speed = 0;
    }
}
