using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public bool IsLeftClick()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x < Screen.width / 2 && Input.GetTouch(0).phase == TouchPhase.Ended) {
                return true;
            }
        } else {
            if (Input.GetMouseButtonUp(0))
            {
                return true;
            }
        }
        return false;
    }

    public bool IsRightClick()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                return true;
            }
        } else {
            if (Input.GetMouseButtonUp(1))
            {
                return true;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
