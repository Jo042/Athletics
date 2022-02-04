using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menuPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menuPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
