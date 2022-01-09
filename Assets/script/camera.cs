using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 1 * speed);
        if (transform.position.z >=450)
        {
            transform.position = new Vector3(0, 14.2f, -27);
        }

    }
}
