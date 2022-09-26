using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimelineController : MonoBehaviour
{
    Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 0f;
    }

    void Update()
    {
        /*****************************************************************
         * Unity KeyCode
         * https://docs.unity3d.com/kr/2020.3/ScriptReference/KeyCode.html
         *****************************************************************/
        if (Input.GetKeyDown(KeyCode.P))
        {
            Anim.speed = 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Anim.speed = 0;
        }
    }

    public void TimelineEvent_Print()
    {
        print("the GameObject is at the starting frame. Press [P] to Play, [S] to Stop.");
    }

    public void EndOfTimelineEvent()
    {
        print("the GameObject is at the last frame.");
        Anim.speed = 0f;
    }
}
