﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Titlebutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<Button>().onClick.AddListener(Title);
    }

    // Update is called once per frame
   public void Title()
    {
       SceneManager.LoadScene("StartScene");
        
    }
}
