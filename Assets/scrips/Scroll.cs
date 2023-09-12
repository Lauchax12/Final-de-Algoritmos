using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour, IPausable, IResumable
{

    [SerializeField] private float speed = 2.5f;
    private Rigidbody2D rb;
    

    void IPausable.Pause()
    {
        Pause();
    }

    void IResumable.Resume()
    {
        Resume();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScreenManager.instance.AddPausable(this);
        ScreenManager.instance.AddResume(this);
        Resume();
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            Pause();


        }
        
    }

    void Pause()
    {
        
        rb.velocity = Vector2.zero;
    }

    void Resume()
    {
        
        rb.velocity = Vector2.left * speed;
    }

    private void OnEnable()
    {
        
        rb.velocity = Vector2.left * speed;
    }


    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "limit")
        {
            gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "player" || GameManager.Instance.shield == true)
        {
            gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "limit")
        {
            gameObject.SetActive(false);
        }
    }
}
