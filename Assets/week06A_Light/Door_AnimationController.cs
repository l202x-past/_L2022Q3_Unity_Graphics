using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_AnimationController : MonoBehaviour
{
    public GameObject Door;
    Animator Anim;

    private void Start()
    {
        Anim = Door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("TriggerEnter " + other.name);
        if(other.name == "FPSController")
        {
            Anim.SetInteger("DoorStatus", 1);
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        print("TriggerExit " + other.name);
        if (other.name == "FPSController")
        {
            Anim.SetInteger("DoorStatus", 2);
        }
    }

}
