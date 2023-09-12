using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour, IPausable, IResumable
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] List<GameObject> itemList;
    [SerializeField] int poolsize ;
    

    

    //singleton, crea una unica instancia de hellpool y nos permite acceder a sus atributos desde otros scripts
    private static ItemPool instance;
    public static ItemPool Instance { get { return instance; } }

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
        AdditemToPool(poolsize);
       
    }

    void AdditemToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject item = Instantiate(itemPrefab);
            item.SetActive(false);
            itemList.Add(item);
            //hago que este pool sea el padre del las balas
            item.transform.parent = transform;
        }
    }

   

    public GameObject RequestItem()
    {
        if (ScreenManager.pause == false)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                if (!itemList[i].activeSelf)
                {
                    itemList[i].SetActive(true);
                    return itemList[i];
                }
            }
            //return null;

            
        }
        AdditemToPool(1);
        itemList[itemList.Count - 1].SetActive(true);
        return itemList[itemList.Count - 1];
    }

    

    void IPausable.Pause()
    {
       
    }

    void IResumable.Resume()
    {
       
    }
}
