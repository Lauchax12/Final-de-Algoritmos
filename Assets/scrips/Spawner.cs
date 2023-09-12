using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IPausable, IResumable
{
    
    float time = 0f;
    public float finaltime;
    public bool pause;

    private void Start()
    {
        time = finaltime;
        ScreenManager.instance.AddPausable(this);
        ScreenManager.instance.AddResume(this);
    }
    //tiempo por disparo
    private void Update()
    {
        if (pause==false)
        {
            time += Time.deltaTime;
            if (time >= finaltime)
            {
                time = 0;
                Shoot();

            }
        }
        



    }

    void Shoot()
    {
        int random = Random.Range(0, 4);
        GameObject item;
        switch (random)
        {
            case 0:
                item = Camera_item_pool.Instance.RequestTwist();
                break;
            case 1:
                item = ItemPool.Instance.RequestItem();
                break;
            case 2:
                item = OnePool.Instance.RequestOne();
                break;

            default:
                item = Buff_pool.Instance.RequestBuff();
                break;
        }
       
        item.transform.position = transform.position;
        item.transform.rotation = transform.rotation;
    }

    void IPausable.Pause()
    {
        pause = true;
    }

    void IResumable.Resume()
    {
        pause = false;
    }
}
