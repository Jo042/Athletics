using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_floor2 : MonoBehaviour
{
    bool m_xPlus = true;
    public float W = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_xPlus)
        {
            transform.position += new Vector3(3f * Time.deltaTime, 0f, 0f);
            if (transform.position.x >= W)
                m_xPlus = false;
        }
        else
        {
            transform.position -= new Vector3(3f * Time.deltaTime, 0f, 0f);
            if(transform.position.x <= -W)
                m_xPlus = true;
        }
    }
}
