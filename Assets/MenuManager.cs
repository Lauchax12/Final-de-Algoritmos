using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject play;
    
    [SerializeField] GameObject controls;
    [SerializeField] GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        Back();
    }
    public void Back()
    {
        play.SetActive(true);
        
        controls.SetActive(false);
        exit.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        play.SetActive(false);

        controls.SetActive(true);
        exit.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
