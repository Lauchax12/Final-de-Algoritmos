using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IPausable, IResumable
{
    [SerializeField] private float upForce = 350f;

    private Rigidbody2D playerRb;
    private bool isDead;

    Animator animator;

    bool pause;

    [SerializeField] GameObject Camera;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        ScreenManager.instance.AddPausable(this);
        ScreenManager.instance.AddResume(this);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isDead)
        {
            playerRb.velocity = Vector2.zero;

            playerRb.AddForce(Vector2.up * upForce);

            
        }

        if (gravitydebuff == true)
        {
            GravityDebuff();
        }

        if (twistdebuff == true)
        {
            TwistDebuff();
        }

        if (speedbuff == true&&Input.GetKey(KeyCode.F))
        {
            Speed_Zero();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "danger")
        {
            if (GameManager.Instance.shield == true)
            {
                GameManager.Instance.shield = false;
            }
            else
            {
                isDead = true;
                animator.speed = 0;
                GameManager.Instance.GameOver();
            }
            
        }
           
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "danger":
                
                    GameManager.Instance.IncreaseScore();
                    print("sas");
                    
                
                break;


            case "yunke":
                gravitydebuff = true;
                time = 5;
                break;
            case "twist":
                twistdebuff = true;
                time = 5;
                break;

            case "speed0":                
                speedbuff = true;
                time = 5;
                break;

            case "onelife":
                GameManager.Instance.shield = true;
                break;
        }
        //if (collision.gameObject.tag == "danger")
        //{
        //    GameManager.Instance.IncreaseScore();
        //    print("sas");
        //}
        //if (collision.gameObject.tag == "yunke")
        //{
        //    gravitydebuff = true;
        //    time = 5;
        //}

        //if (collision.gameObject.tag == "twist")
        //{
        //    twistdebuff = true;
        //    time = 5;
        //}

        //if (collision.gameObject.tag == "speed0")
        //{
        //    speedbuff = true;
        //    time = 5;
        //}

    }
    void IPausable.Pause()
    {
        Pause();
    }

    void IResumable.Resume()
    {
        Resume();
        
    }

    void Pause()
    {
        pause = true;
        playerRb.gravityScale = 0;
        playerRb.velocity = Vector3.zero;
        upForce = 0;
        animator.speed = 0;
    }

    void Resume()
    {
        pause = false;
        playerRb.gravityScale = 2;
        upForce = 350;
        animator.speed = 1;
    }

    void GravityDebuff()
    {
        upForce = 150;
        
        if (ScreenManager.pause == false)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            upForce = 350f;
            gravitydebuff = false;
        }
        
    }

    void TwistDebuff()
    {
        
        float speed=10;
        Camera.transform.rotation= Quaternion.LookRotation(transform.forward, Vector3.down);
        if (twist == 180)
        {
            Camera.transform.rotation = new Quaternion(0, 0, 180, 0);
        }
        if (ScreenManager.pause == false)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            Camera.transform.rotation = new Quaternion(0, 0, 0, 0);
            twistdebuff = false;
            twist = 0;
        }
    }

    void Speed_Zero()
    {
        float speed = 10;
        ScreenManager.instance.PauseAllExept(this);

        StartCoroutine(BuffTime());
       
    }

    IEnumerator BuffTime()
    {
        yield return new WaitForSeconds(5);
        speedbuff = false;
        ScreenManager.instance.Resume();
    }

    

    bool speedbuff;
    bool gravitydebuff;
    bool twistdebuff;
    bool onemorelife;
    float twist = 0;
    [SerializeField] float time;
}
