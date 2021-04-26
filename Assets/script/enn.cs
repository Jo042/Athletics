using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enn : MonoBehaviour
{
    Vector3 firstpos;
    public float speed = 1.0f;
    public float R = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        firstpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var x = R * Mathf.Sin(Time.time * speed);
        var z = R * Mathf.Cos(Time.time * speed);
        transform.position = firstpos + new Vector3(x, 0f, z);


        
    }
}
