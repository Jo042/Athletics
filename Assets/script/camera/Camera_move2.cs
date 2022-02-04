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
    bool test = false;
    int right_index;
    int left_index;
    private Touch touch_1;
    private Touch touch_2;


    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("player");
        targetPos = targetObj.transform.position;
        offset = transform.position - targetObj.transform.position;
        screenX = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Player_con.instance.ispc)
        {
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
        }
        else
        {

           // Debug.Log(touch_right.position);
            touch_count = Input.touchCount;
            mousePosition = Input.mousePosition;
            transform.position += targetObj.transform.position - targetPos;
            targetPos = targetObj.transform.position;
            



            //Debug.Log(mousePosition.x);
            switch (touch_count)
            {

                case 0:
                    {
                        test = false;
                        break;
                    }
                case 1:
                    {
                        if (screenX < mousePosition.x)
                        {
                            right_index = 0;
                            touch_right = Input.GetTouch(right_index);
                            firstTouch = "right";
                            Debug.Log("case1:right");
                        }
                        else
                        {
                            left_index = 0;
                            touch_left = Input.GetTouch(left_index);
                            firstTouch = "left";
                            Debug.Log("case1:left");
                            mouseInputX = 0;
                            mouseInputY = 0;
                            touch_right.deltaPosition = new Vector3(0, 0, 0);
                        }

                        break;
                    }

                case 2:
                    {
                        touch_left = Input.GetTouch(left_index);
                        touch_right = Input.GetTouch(right_index);
                        if (firstTouch == "right")
                        {
                            right_index = 0;
                            left_index = 1;
                            if (test == true)
                            {
                                left_index = 0;
                                right_index = 1;
                            }

                            if (touch_right.phase == TouchPhase.Ended)
                            {
                                test = true;
                                Debug.Log("end");
                            }
                            Debug.Log("case2:right");

                        }
                        else if (firstTouch == "left")
                        {
                            left_index = 0;
                            right_index = 1;
                            
                           if(test == true)
                            {
                                right_index = 0;
                                left_index = 1;
                            }

                           if (touch_left.phase == TouchPhase.Ended)
                            {
                                test = true;
                            }
                            Debug.Log(Input.GetTouch(1).position);
                            Debug.Log("case2:left");
                        }
                        break;
                    }
            }



            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("s");

            }

            if (Input.GetMouseButton(0))
            {
                mouseInputX = touch_right.deltaPosition.x;
                mouseInputY = touch_right.deltaPosition.y;
                transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 20f);
                transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 20f);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                transform.rotation = Quaternion.identity;
                transform.position = targetObj.transform.position + offset;
            }

        }
        //Debug.Log(mouseInputX);
        //Debug.Log(mouseInputY);

        /*
        
     
        Touch.phase使えばQuartanionのやつもっと変えれる


         touch_count = Input.touchCount;
            if (Input.GetMouseButton(0))
            {

                mousePosition = Input.mousePosition;
                if (screenX < mousePosition.x)
                {
                    mouseFlag = true;
                }
                else
                {
                    mouseFlag = false;
                }

            }
        
                transform.position += targetObj.transform.position - targetPos;
            targetPos = targetObj.transform.position;
            
            switch (touch_count)
            {
                case 1:
                    {
                        if (mouseFlag == true)
                        {
                            Debug.Log(test);
                            touch_right = Input.GetTouch(0);
                            firstTouch = "right";
                            Debug.Log("case1:right");
                            if (touch_right.phase == TouchPhase.Ended)
                            {
                                test = false;
                            }
                        }
                        else if (mouseFlag == false)
                        {
                            Debug.Log(test);
                            touch_left = Input.GetTouch(0);
                            firstTouch = "left";
                            Debug.Log("case1:left");
                            mouseInputX = 0;
                            mouseInputY = 0;
                            touch_right.deltaPosition = new Vector3(0, 0, 0);
                        }
                        break;
                    }

                case 2:
                    {

                        if (firstTouch == "right")
                        {
                            Debug.Log(test);
                            touch_right = Input.GetTouch(0);
                            touch_left = Input.GetTouch(1);
                            if (touch_right.phase == TouchPhase.Ended)
                            {
                                mouseFlag = false;
                                test = true;
                            }
                            Debug.Log("case2:right");

                        }
                        else if (firstTouch == "left")
                        {
                            Debug.Log(test);
                            if (test == true)
                            {
                                touch_right = Input.GetTouch(0);
                                touch_left = Input.GetTouch(1);
                            }
                            else
                            {
                                touch_left = Input.GetTouch(0);
                                touch_right = Input.GetTouch(1);
                            }


                            Debug.Log("case2:left");
                        }
                        break;
                    }

            }
        */


    }
}
