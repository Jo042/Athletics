using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move2 : MonoBehaviour
{
    GameObject targetObj;
    Vector3 targetPos;
    private Vector3 offset;
    float mouseInputX;
    float mouseInputY;
    Vector3 mousePosition;
    private int screenX;
    private bool mouseFlag;
    private int touch_count;
    private Touch touch_right;
    private Touch touch_left;
    string firstTouch;

    private Touch touch_1;
    private Touch touch_2;
    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("player");
        targetPos = targetObj.transform.position;
        offset = transform.position - targetObj.transform.position;
        screenX = Screen.width/2;
    }

    // Update is called once per frame
    void Update()
    {
        touch_count = Input.touchCount;
        mousePosition = Input.mousePosition;
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        if(touch_count == 1)
        {
            touch_1 = Input.GetTouch(0);
            if(touch_1.position.x > screenX)
            {

            }
        }






        switch (touch_count)
        {
            case 1:
                {
                    if(screenX < mousePosition.x)
                    {
                        touch_right = Input.GetTouch(0);
                        firstTouch = "right";
                    }
                    else
                    {
                        touch_left = Input.GetTouch(0);
                        firstTouch = "left";
                    }
                    break;
                }

            case 2:
                {

                    if (firstTouch == "right")
                    {
                        touch_right = Input.GetTouch(0);
                        touch_left = Input.GetTouch(1);
                        
                        
                    }
                    else if (firstTouch == "left")
                    {
                        touch_left = Input.GetTouch(0);
                        touch_right = Input.GetTouch(1);
                    }
                    break;
                }
        }
     
        
        if (Input.GetMouseButton(0) )
        {
            mouseInputX = touch_right.deltaPosition.x;
            mouseInputY = touch_right.deltaPosition.y;
            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
            transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 200f);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            transform.rotation = Quaternion.identity;
            transform.position = targetObj.transform.position + offset;
        }


        /*
        mousePosition = Input.mousePosition;
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            mouseFlag = (screenX < mousePosition.x);
        }

        if (Input.GetMouseButton(0) && mouseFlag == true)
        {
            mouseInputX = Input.GetAxis("Mouse X");
            mouseInputY = Input.GetAxis("Mouse Y");
            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
            transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 200f);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            transform.rotation = Quaternion.identity;
            transform.position = targetObj.transform.position + offset;

        }
        */


    }
}
