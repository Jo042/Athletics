using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
   
    
    public float rotateSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
        offset = transform.position - player.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        
    }

    
}
