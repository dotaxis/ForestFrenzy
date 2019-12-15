using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler
{
    public bool IsLeftClick()
    {
        if ((Input.touchCount > 0
                 && Input.GetTouch(0).position.x < Screen.width / 2
                 && Input.GetTouch(0).phase == TouchPhase.Began)
                 || Input.GetMouseButtonDown(0))
        {
            Debug.Log("IsLeftClick() returned true");
            return true;
        }
        return false;
    }

    public bool IsRightClick()
    {
        if ((Input.touchCount > 0
                 && Input.GetTouch(0).position.x > Screen.width / 2
                 && Input.GetTouch(0).phase == TouchPhase.Began)
                 || Input.GetMouseButtonDown(1))
        {
            Debug.Log("IsRightClick() returned true");
            return true;
        }
        return false;
    }

}
