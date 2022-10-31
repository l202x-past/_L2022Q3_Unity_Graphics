using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingedDoor_Controller : MonoBehaviour
{
    public GameObject DoorPivot;

    private void OnTriggerEnter(Collider other)
    {
        DoorPivot.GetComponent<Animator>().SetInteger("State", 1);
    }

    private void OnTriggerExit(Collider other)
    {
        DoorPivot.GetComponent<Animator>().SetInteger("State", 2);
    }
}
