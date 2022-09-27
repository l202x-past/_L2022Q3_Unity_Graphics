using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMultiplierController_start : MonoBehaviour
{
    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.SetFloat("Dir", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Anim.SetFloat("Dir", 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Anim.SetFloat("Dir", -1.0f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Anim.SetFloat("Dir", 0.0f);
        }
    }
}
