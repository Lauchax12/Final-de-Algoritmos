using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePool : MonoBehaviour, IPausable, IResumable
{
    [SerializeField] GameObject onePrefab;
    [SerializeField] List<GameObject> oneList;
    [SerializeField] int poolsize;




    //singleton, crea una unica instancia de hellpool y nos permite acceder a sus atributos desde otros scripts
    private static OnePool instance;
    public static OnePool Instance { get { return instance; } }

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
        AddOneToPool(poolsize);

    }

    void AddOneToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject One = Instantiate(onePrefab);
            One.SetActive(false);
            oneList.Add(One);
            //hago que este pool sea el padre del las balas
            One.transform.parent = transform;
        }
    }



    public GameObject RequestOne()
    {
        if (ScreenManager.pause == false)
        {
            for (int i = 0; i < oneList.Count; i++)
            {
                if (!oneList[i].activeSelf)
                {
                    oneList[i].SetActive(true);
                    return oneList[i];
                }
            }
            //return null;


        }
        AddOneToPool(1);
        oneList[oneList.Count - 1].SetActive(true);
        return oneList[oneList.Count - 1];
    }



    void IPausable.Pause()
    {

    }

    void IResumable.Resume()
    {

    }
}