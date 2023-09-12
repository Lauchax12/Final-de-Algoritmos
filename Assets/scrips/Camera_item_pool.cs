using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_item_pool: MonoBehaviour , IPausable, IResumable
{
    [SerializeField] GameObject twitprefab;
    [SerializeField] List<GameObject> twistlist;
    [SerializeField] int poolsize;
    public bool pause = true;



//singleton, crea una unica instancia de hellpool y nos permite acceder a sus atributos desde otros scripts
private static Camera_item_pool instance;
public static Camera_item_pool Instance { get { return instance; } }

private void Awake()
{
    if (instance == null)
    {
        instance = this;
    }
    else
    {
        Destroy(gameObject);
    }
}

void Start()
{
    Addtwisttopool(poolsize);

}

void Addtwisttopool(int amount)
{
    for (int i = 0; i < amount; i++)
    {
        GameObject twist = Instantiate(twitprefab);
        twist.SetActive(false);
        twistlist.Add(twist);
        //hago que este pool sea el padre del las balas
        twist.transform.parent = transform;
    }
}



public GameObject RequestTwist()
{
    if (pause == false)
    {
        for (int i = 0; i < twistlist.Count; i++)
        {
            if (!twistlist[i].activeSelf)
            {
                twistlist[i].SetActive(true);
                return twistlist[i];
            }
        }
        //return null;


    }
    Addtwisttopool(1);
    twistlist[twistlist.Count - 1].SetActive(true);
    return twistlist[twistlist.Count - 1];
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
