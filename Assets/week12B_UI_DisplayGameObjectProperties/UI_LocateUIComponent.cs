using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LocateUIComponent : MonoBehaviour
{
    public Transform PositionReference;
    public float AdjustHorizontalPosition = 0f;
    public float AdjustVerticalPosition = 1f;

    Camera TargetCamera;

    private void Start()
    {
        TargetCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        DisplayAtPosition();
    }

    void DisplayAtPosition()
    {
        if(PositionReference.GetComponent<UI_GameObject_Visible_Controller>().isVisible)
        {
            GetComponent<Text>().enabled = true;
            Vector3 WorldPos = PositionReference.transform.position;
            Vector2 ScreenPos = TargetCamera.WorldToScreenPoint(WorldPos + Vector3.up * AdjustVerticalPosition + Vector3.right * AdjustHorizontalPosition);
            transform.position = ScreenPos;
        }
        else
        {
            GetComponent<Text>().enabled = false;
        }
    }
}

