using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public static Heart instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject[] heart;
    public void Destroy(int i)
    {
        heart[i].SetActive(false);
    }
}
