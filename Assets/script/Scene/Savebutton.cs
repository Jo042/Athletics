using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Savebutton : MonoBehaviour
{
    [SerializeField] GameObject resultPanel = default;
    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Savegame);
        owner = GameObject.Find("player");

        // Update is called once per frame
      
    }
    void Savegame()
    {
        resultPanel.SetActive(false);
        owner.GetComponent<Player_con>().Restart();

    }


}
