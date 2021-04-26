using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Copy", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Copy()
    {
        int number = Random.Range(-1,2);
        Instantiate(ball, new Vector3(number * 8, 91, 425), Quaternion.identity);
       

    }
}
