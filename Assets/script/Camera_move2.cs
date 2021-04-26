using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move2 : MonoBehaviour
{
    GameObject targetObj;
    Vector3 targetPos;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("player");
        targetPos = targetObj.transform.position;
        offset = transform.position - targetObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        if (Input.GetMouseButton(1))
        {
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");

            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
            transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 200f);

        }
        else if (Input.GetMouseButtonUp(1))
        {
            transform.rotation = Quaternion.identity;
            transform.position = targetObj.transform.position + offset;
            
        } 
    }
}
