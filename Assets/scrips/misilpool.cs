using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misilpool : MonoBehaviour, IPausable, IResumable
{
    [SerializeField] GameObject misilPrefab;
    [SerializeField] List<GameObject> misilList;
    [SerializeField] int poolsize;
    



    //singleton, crea una unica instancia de hellpool y nos permite acceder a sus atributos desde otros scripts
    private static misilpool instance;
    public static misilpool Instance { get { return instance; } }

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
        Addmisiltopool(poolsize);

    }

    void Addmisiltopool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject misil = Instantiate(misilPrefab);
            misil.SetActive(false);
            misilList.Add(misil);
            //hago que este pool sea el padre del las balas
            misil.transform.parent = transform;
        }
    }



    public GameObject Requestmisil()
    {
        if (ScreenManager.pause == false)
        {
            for (int i = 0; i < misilList.Count; i++)
            {
                if (!misilList[i].activeSelf)
                {
                    misilList[i].SetActive(true);
                    return misilList[i];
                }
            }
            //return null;


        }
        Addmisiltopool(1);
        misilList[misilList.Count - 1].SetActive(true);
        return misilList[misilList.Count - 1];
    }



    void IPausable.Pause()
    {
        
    }

    void IResumable.Resume()
    {
        
    }
}
