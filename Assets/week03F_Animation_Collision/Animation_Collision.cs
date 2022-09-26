using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Collision : MonoBehaviour
{
    public GameObject DoorContainer;
    Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = DoorContainer.GetComponent<Animator>();
        Anim.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        Anim.speed = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        print(other.name);
        Anim.speed = 1;
    }

}
