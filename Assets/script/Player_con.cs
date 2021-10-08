using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_con : MonoBehaviour
{
    public bool ispc = false;
    private Animator anim;
    public bool isjump = false;
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
    [SerializeField] GameObject up_button;
    [SerializeField] GameObject down_button;
    [SerializeField] GameObject left_button;
    [SerializeField] GameObject right_button;
    [SerializeField] GameObject jump_button;
    bool right_flag = false;
    bool left_flag = false;
    bool walk_flag = false;
    bool back_flag = false;
    bool buttonpushing = false;
    public static Player_con instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        speed = 1;
        radius = 1;

        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        defPosition = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            iswalk();
        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            isbackwalk();
        }
        else
        {
            anim.SetBool("back_walk", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            isrightwalk();
        }
        else
        {
            anim.SetBool("right_waik", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            isleftwalk();
        }
        else
        {
            anim.SetBool("left_walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isjumping();
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

        }
        else
        {
            Time.timeScale = 1f;

        }

        if (right_flag)
        {

            isrightwalk();
        }

        if (left_flag)
        {
            anim.SetBool("left_walk", true);
            isleftwalk();
        }

        if (walk_flag)
        {
            anim.SetBool("walk", true);
            iswalk();
        }

        if (back_flag)
        {
            anim.SetBool("back_walk", true);
            isbackwalk();
        }

    }
    public void right_change(bool flag)
    {
        right_flag = flag;
    }

    public void walk_change(bool flag)
    {
        walk_flag = flag;
    }

    public void left_change(bool flag)
    {
        left_flag = flag;
    }

    public void back_change(bool flag)
    {
        back_flag = flag;
    }

    public void buttonpush()
    {
        buttonpushing = true;
    }

    public void iswalk()
    {
        anim.SetBool("walk", true);
        Vector3 force = new Vector3(0, 0, speed_w);
        if (rb.velocity.magnitude < 10.0f)
        {
            rb.AddForce(force);
        }
    }

    public void isbackwalk()
    {
        anim.SetBool("back_walk", true);
        Vector3 force = new Vector3(0, 0, speed_s);
        if (rb.velocity.magnitude < 10.0f)
        {
            rb.AddForce(force);
        }
    }

    public void isrightwalk()
    {
        anim.SetBool("right_waik", true);
        Vector3 force = new Vector3(speed_d, 0, 0);
        if (rb.velocity.magnitude < 10.0f)
        {
            rb.AddForce(force);
        }
    }

    public void isleftwalk()
    {
        anim.SetBool("left_walk", true);
        Vector3 force = new Vector3(speed_a, 0, 0);
        if (rb.velocity.magnitude < 10.0f)
        {
            rb.AddForce(force);
        }
    }

    public void isjumping()
    {
        if (isjump)
        {
            anim.SetTrigger("jumpp");
            isjump = false;
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
            if (R == 2)
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
            up_button.SetActive(false);
            down_button.SetActive(false);
            right_button.SetActive(false);
            left_button.SetActive(false);
            jump_button.SetActive(false);
            resultPanel.SetActive(true);
        }

        if (collision.gameObject.tag == "Goal")
        {
            clearPanel.SetActive(true);
            up_button.SetActive(false);
            down_button.SetActive(false);
            right_button.SetActive(false);
            left_button.SetActive(false);
            jump_button.SetActive(false);
        }


    }
   


    
    public void Restart()
    {
        if (!ispc)
        {
            up_button.SetActive(true);
            down_button.SetActive(true);
            right_button.SetActive(true);
            left_button.SetActive(true);
            jump_button.SetActive(true);
        }
       
        transform.position = new Vector3(X, Y, Z);
        right_flag = false;
        left_flag = false;
        walk_flag = false;
        back_flag = false;
    }

    public void jump()
    {
        rb.velocity = new Vector3(0, 20, 0);
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

   


}
