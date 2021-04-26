using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_floor1 : MonoBehaviour
{
    bool m_xPlus = true;
    public int speed = 2;
    public int up = 0;
    public int down = 0;
    public int p= 0;
    public int q= 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_xPlus)
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
            if (transform.position.y >= up + p)
                m_xPlus = false;
        }
        else
        {
            transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
            if (transform.position.y <= down + q)
                m_xPlus = true;
        }
    }
}
