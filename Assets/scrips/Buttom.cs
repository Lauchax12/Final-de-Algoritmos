using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttom : MonoBehaviour
{
    [SerializeField] private GameObject laserwall;

    [SerializeField] Transform[] positions;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            laserwall.SetActive(false);
            StartCoroutine(SetActive());
        }

        
    }

    

    IEnumerator SetActive()
    {
        yield return new WaitForSeconds(5);
        laserwall.SetActive(true);
    }

    private void OnEnable()
    {
        switch (random)
        {
            case 1:
                transform.position = positions[1].transform.position;
                break;

            case 2:
                transform.position = positions[2].transform.position;
                break;

            case 3:
                transform.position = positions[3].transform.position;
                break;

            default:
                transform.position = positions[4].transform.position;
                break;
        }
    }
    int random;
    private void OnDisable()
    {
        random = Random.Range(0,5);

    }

}
