using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_travel : MonoBehaviour, IPausable, IResumable
{
    public Transform[] waypoints;
    int _actualWaypoint;
    public float speed;

    [Range(0.5f, 3)]
    public float minDetectWaypoint;

    bool pause=false;

    private void Start()
    {
        ScreenManager.instance.AddPausable(this);
        ScreenManager.instance.AddResume(this);
    }

    private void Update()
    {
        if (pause == false)
        {
            var dir = waypoints[_actualWaypoint].position - transform.position;
            transform.position += dir.normalized * speed * Time.deltaTime;

            if (dir.magnitude <= minDetectWaypoint)
            {
                _actualWaypoint++;

                if (_actualWaypoint >= waypoints.Length)
                    _actualWaypoint = 0;
            }
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
}
