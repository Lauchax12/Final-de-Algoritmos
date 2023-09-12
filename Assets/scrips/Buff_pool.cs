using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_pool : MonoBehaviour, IPausable, IResumable
{
    [SerializeField] GameObject buffPrefab;
    [SerializeField] List<GameObject> buffList;
    [SerializeField] int poolsize;
    public bool pause = true;



    //singleton, crea una unica instancia de hellpool y nos permite acceder a sus atributos desde otros scripts
    private static Buff_pool instance;
    public static Buff_pool Instance { get { return instance; } }

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
        AddbuffToPool(poolsize);

    }

    void AddbuffToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject buff = Instantiate(buffPrefab);
            buff.SetActive(false);
            buffList.Add(buff);
            //hago que este pool sea el padre del las balas
            buff.transform.parent = transform;
        }
    }



    public GameObject RequestBuff()
    {
        if (pause == false)
        {
            for (int i = 0; i < buffList.Count; i++)
            {
                if (!buffList[i].activeSelf)
                {
                    buffList[i].SetActive(true);
                    return buffList[i];
                }
            }
            //return null;


        }
        AddbuffToPool(1);
        buffList[buffList.Count - 1].SetActive(true);
        return buffList[buffList.Count - 1];
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
