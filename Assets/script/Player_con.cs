using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_con : MonoBehaviour
{
    private Animator anim;
    private bool isjump = false;
    Rigidbody rb;
    private bool gimmick4 = false;
    public float speed_w = 10;
    public float speed_s = 10;
    public float speed_d = 10;
    public float speed_a = 10;
    private int speed;                //オブジェクトのスピード
    private int radius;               //円を描く半径
    private Vector3 defPosition;      //defPositionをVector3で定義する。
    float x;
    float z;
    GameObject parent;
    public GameObject slope;
    private float X = 0;
    private float Y = 1.6f;
    private float Z = 0;
    private int R;
    [SerializeField] GameObject resultPanel;
    [SerializeField] GameObject clearPanel;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        speed = 1;
        radius = 1;
       
         
    }

    // Update is called once per frame
    void Update()
    {
        defPosition = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk", true);
            Vector3 force = new Vector3(0, 0, speed_w);
            if (rb.velocity.magnitude < 10.0f)
            {
                rb.AddForce(force); 
            }
        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("back_walk", true);
            Vector3 force = new Vector3(0, 0, speed_s);
            if (rb.velocity.magnitude < 10.0f)
            {
                rb.AddForce(force); 
            }
        }
        else
        {
            anim.SetBool("back_walk", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("right_waik", true);
            Vector3 force = new Vector3(speed_d, 0, 0);
            if (rb.velocity.magnitude < 10.0f)
            {
                rb.AddForce(force);
            }
        }
        else
        {
            anim.SetBool("right_waik", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("left_walk", true);
            Vector3 force = new Vector3(speed_a, 0, 0);
            if (rb.velocity.magnitude < 10.0f)
            {
                rb.AddForce(force); 
            }
        }
        else
        {
            anim.SetBool("left_walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isjump == true)
        {
            anim.SetTrigger("jumpp");
            //rb.velocity = new Vector3(0, 10, 0);
            isjump = false;
        }
        else
        {
            anim.SetBool("jump", false);

        }

        if (gimmick4 == true)
        {
            gimmick();
        }

        if (resultPanel.activeSelf)
        {
            Time.timeScale = 0f;
            //　ポーズUIが表示されてなければ通常通り進行
        }
        else
        {
            Time.timeScale = 1f;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isjump = true;
        }

        if (collision.gameObject.tag == "Ground")
        {
           
            transform.SetParent(collision.transform);
        }

        if (collision.gameObject.CompareTag("Ground2"))
        {
            isjump = true;
        }
       
        if (collision.gameObject.tag == "A")
        {
            R = Random.Range(1, 3);
            if (R == 1)
            {
                Vector3 force = new Vector3(Random.Range(30, 40), 20, 0);
                rb.AddForce(force, ForceMode.Impulse);
            }
            if(R == 2)
            {
                Vector3 force = new Vector3(Random.Range(-30, -40), 20, 0);
                rb.AddForce(force, ForceMode.Impulse);
            }
        }

        if (collision.gameObject.tag == "save1")
        {
            Y = 2.5f;
            Z = 63;
        }

        if (collision.gameObject.tag == "save2")
        {
            Y = 3;
            Z = 125;
        }
        
        if (collision.gameObject.tag == "save3")
        {
            Y = 3;
            Z = 198;
        }

        if (collision.gameObject.tag == "Finish")
        {

            resultPanel.SetActive(true);
        }

        if (collision.gameObject.tag == "Goal")
        {
            clearPanel.SetActive(true);
        }

       
    }

    void jump()
    {
        rb.velocity = new Vector3(0, 16, 0);
    }

    

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            transform.SetParent(null);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.rotation = Quaternion.Euler(transform.position.x, 0, transform.position.y);

        }

        if(collision.gameObject == slope)
        {
            speed_w = 14;
            speed_a = -8;
            speed_s = -13;
            speed_d = 8;
        }
    }

    void gimmick()
    {
        x = radius * Mathf.Sin(Time.time * speed);
        z = radius * Mathf.Cos(Time.time * speed);

        transform.position = new Vector3(x + defPosition.x, defPosition.y, z + defPosition.z);
    }

    public void Restart()
    {

        transform.position = new Vector3(X, Y, Z);

    }


}
