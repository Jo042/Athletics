using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_floor4 : MonoBehaviour
{
    Vector3 firstpos;
    public float speed = 1.0f;
    public float R = 1.0f;
    bool m_xPlus = true;
   
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


        if (m_xPlus)
        {
            transform.position += new Vector3(0f, 2 * Time.deltaTime, 0f);
            if (transform.position.y >= 5)
                m_xPlus = false;
        }
        else
        {
            transform.position -= new Vector3(0f, 2 * Time.deltaTime, 0f);
            if (transform.position.y <= -5)
                m_xPlus = true;
        }
    }
}
