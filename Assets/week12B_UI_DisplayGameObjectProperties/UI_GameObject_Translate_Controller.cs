using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_GameObject_Translate_Controller : MonoBehaviour
{
    public float AdjustHorizontalAmount = 1f;
    public float AdjustVerticalAmount = 1f;
    bool isSelected = false;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            bool hasClickedOther = CheckIfClickOther();

            if (hasClickedOther)
            {
                isSelected = false;
            }
            print(isSelected);
        }

        if (isSelected)
        {
            TranslateGameObject();
        }
    }

    private void OnMouseDown()
    {
        isSelected = true;
    }

    void TranslateGameObject()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * AdjustHorizontalAmount);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * AdjustHorizontalAmount);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * AdjustVerticalAmount);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.up * AdjustVerticalAmount);
        }
    }

    bool CheckIfClickOther()
    {
        bool hasClickedOther = false;
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out raycastHit, 100f);

        try
        {
            print(raycastHit.transform.gameObject);
            if (raycastHit.transform.gameObject.name == gameObject.name)
            {
                print("clicked this object");                
            }
            else
            {
                print("clicked something else");
                hasClickedOther = true;
            }
        }
        catch
        {
            print("clicked sky");
            hasClickedOther = true;
        }
        return hasClickedOther;
    }
}
