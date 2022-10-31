using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controller : MonoBehaviour
{
    public GameObject Pivot;


    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        Pivot.GetComponent<Animator>().SetInteger("State", 1);
    }
    private void OnTriggerExit(Collider other)
    {
        print("exit"+other.name);
        Pivot.GetComponent<Animator>().SetInteger("State", 2);

    }
}
