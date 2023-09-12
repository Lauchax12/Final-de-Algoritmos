using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static bool pause;
    public static ScreenManager instance;

    private void Awake()
    {
        pause = false;
        instance = this;
    }

    HashSet<IPausable> pausables = new HashSet<IPausable>();
    HashSet<IResumable> resumables = new HashSet<IResumable>();

    public void AddPausable(IPausable pausable)
    {
        pausables.Add(pausable);
    }

    public void RemPausable(IPausable pausable)
    {
        pausables.Remove(pausable);
    }

    public void AddResume(IResumable resume)
    {
        resumables.Add(resume);
    }

    public void RemResume(IResumable resume)
    {
        resumables.Remove(resume);
    }

    public void Pause()
    {
        pause = true;
        //recorremos todos los pausables
        foreach(var item in pausables)
        {
            item.Pause();
        }
    }

    public void Resume()
    {
        pause = false;
        //recorremos todos los resumables
        foreach (var item in resumables)
        {
            item.Resume();
        }
    }

   

    public void PauseAllExept(IPausable notpause)
    {
        
        pause = true;
        foreach (var item in pausables)
        {
            if (item==notpause)
            {
                continue;
            }
            item.Pause();
        }
    } 

    
}
