using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverTextGM;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text startText;
    [SerializeField] private TMP_Text restartText;
    //[SerializeField] private UnityEngine.UI.Text playtext;
    //[SerializeField] private UnityEngine.UI.Text exittext;
    //[SerializeField] private UnityEngine.UI.Text controlstext;
    //[SerializeField] private UnityEngine.UI.Text optionstext;
    public bool isGameOver;

    private int score;

    public bool shield = false;

    private bool pause=true;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    void Awake()
    {
        if(instance == null)
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
        startText.gameObject.SetActive(true);
        ScreenManager.instance.Pause();
        
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isGameOver)
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.P)&& ScreenManager.pause ==false)
        {
            ScreenManager.instance.Pause();
            


        }

        if (Input.GetMouseButtonDown(1) && ScreenManager.pause == true )
        {
            startText.gameObject.SetActive(false);
            ScreenManager.instance.Resume();
            
            print("resume");
        }

        gameOverText.text = LocalitationManager.instance.GetText("gameover");
        restartText.text = LocalitationManager.instance.GetText("restart");
        startText.text = LocalitationManager.instance.GetText("start");
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverTextGM.SetActive(true);
        ScreenManager.instance.Pause();

    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

    }


}
