using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Misil : MonoBehaviour, IPausable, IResumable
{
    bool Objetivelocated=false;
    [SerializeField] Transform player;
    [SerializeField] Transform launch;
    Vector3 Objetive;

    public advise_anim animationformisil;

    float time = 0f;
    public float finaltime;
    

    private void Start()
    {
        
        time = finaltime;
        ScreenManager.instance.AddPausable(this);
        ScreenManager.instance.AddResume(this);
    }

    void Update()
    {

        if (ScreenManager.pause == false&&Objetivelocated==false&&ScreenManager.pause==false)
        {
            transform.position = new Vector3(8.44f, player.transform.position.y, 0);
            Objetive = transform.position;
            time -= Time.deltaTime;
            animationformisil.NoAttack();
            if (time <= 0)
            {
                animationformisil.Attack();
                
                time = finaltime;
                Objetivelocated = true;

            }
        }

        if (ScreenManager.pause == false && Objetivelocated == true && ScreenManager.pause == false)
        {
            Shootmisil();
            Objetivelocated = false;
        }


    }

   

    void Shootmisil()
    {

        GameObject misil = misilpool.Instance.Requestmisil();
        misil.transform.position = transform.position;
        misil.transform.rotation = transform.rotation;

    }

    void IPausable.Pause()
    {
        
    }

    void IResumable.Resume()
    {
       
    }
}
