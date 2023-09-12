using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPausable, IResumable
{
    public int speed;
    [SerializeField] private float xSpawnPosition = 12f;
    [SerializeField] private float minYPosition = -2f;
    [SerializeField] private float maxYPosition = 3f;
    bool pause=false;

    private void Start()
    {
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        transform.position = spawnPosition;
        ScreenManager.instance.AddPausable(this);
        ScreenManager.instance.AddResume(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "limit")
        {
            gameObject.SetActive(false);
        }

        if(collision.gameObject.tag == "player")
        {
            //poner lo que le hara al jugador
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "limit")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "player")
        {
            //poner lo que le hara al jugador
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (pause == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
    }

    void IPausable.Pause()
    {
        pause = true;
    }

    void IResumable.Resume()
    {
        pause = false;
    }

    private void OnDisable()
    {
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        transform.position = spawnPosition;
    }
}
