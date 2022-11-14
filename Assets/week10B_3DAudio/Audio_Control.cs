using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Control : MonoBehaviour
{
    AudioSource Audio;
    bool isPlay = true;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        if (isPlay)
        {
            Audio.Play();
        }
        else
        {
            Audio.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPlay = !isPlay;
            if (isPlay)
            {
                Audio.Play();
            }
            else
            {
                Audio.Stop();
            }
        }
    }
}
