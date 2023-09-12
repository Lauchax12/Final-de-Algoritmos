using UnityEngine;

public class ObstaclesPool : MonoBehaviour, IPausable, IResumable
{

    [SerializeField] private GameObject obstaclesPrefab;
    [SerializeField] private GameObject obstacleslaserPrefab;
    [SerializeField] private GameObject ObstaclesballPrefab;

    [SerializeField] private int poolSize = 5;
    [SerializeField] private float spawntime = 2.5f;
    [SerializeField] private float xSpawnPosition = 12f;
    [SerializeField] private float minYPosition = -2f;
    [SerializeField] private float maxYPosition = 3f;

   
    float pausedtime;

    private float timElapsed;
    private int obstacleCount;
    private GameObject[] obstacles;
    private GameObject[] laserobstacle;
    private GameObject[] ballobstacle;
    void Start()
    {
        SetObstaclesinactive();
        SetBallObjectsinactive();
        SetLaserObjectsinactive();
        ScreenManager.instance.AddPausable(this);
        ScreenManager.instance.AddResume(this);
    }

    void SetObstaclesinactive()
    {
        obstacles = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obstaclesPrefab);
            obstacles[i].SetActive(false);

        }
    }

    void SetLaserObjectsinactive()
    {
        laserobstacle = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            laserobstacle[i] = Instantiate(obstacleslaserPrefab);
            laserobstacle[i].SetActive(false);

        }
    }

    void SetBallObjectsinactive()
    {
        ballobstacle = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            ballobstacle[i] = Instantiate(ObstaclesballPrefab);
            ballobstacle[i].SetActive(false);

        }
    }

    void Update()
    {
        timElapsed += Time.deltaTime;
        if(timElapsed > spawntime && !GameManager.Instance.isGameOver && ScreenManager.pause == false)
        {
            int random = Random.Range(0, 4);
            
            switch (random)
            {
                case 1:
                    SpawnObstacle();
                    break;

                case 2:
                    SpawnLaserObsacles();
                    break;
                case 3:
                    SpawnBallObstacle();
                    break;

            }
        }    
        
    }
    private void SpawnObstacle()
    {
        timElapsed = 0f;

        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        obstacles[obstacleCount].transform.position = spawnPosition;

        if(!obstacles[obstacleCount].activeSelf)
        {
            obstacles[obstacleCount].SetActive(true);
            

        }

        obstacleCount++;

        if(obstacleCount == poolSize)
        {

            obstacleCount = 0;

        }

    }

    void SpawnLaserObsacles()
    {
        timElapsed = 0f;

        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        laserobstacle[obstacleCount].transform.position = spawnPosition;

        if (!laserobstacle[obstacleCount].activeSelf)
        {
            laserobstacle[obstacleCount].SetActive(true);


        }

        obstacleCount++;

        if (obstacleCount == poolSize)
        {

            obstacleCount = 0;

        }
    }

    private void SpawnBallObstacle()
    {
        timElapsed = 0f;

        Vector2 spawnPosition = new Vector2(xSpawnPosition, 2.7f);
        ballobstacle[obstacleCount].transform.position = spawnPosition;
        if (!ballobstacle[obstacleCount].activeSelf)
        {
            ballobstacle[obstacleCount].SetActive(true);


        }

        obstacleCount++;

        if (obstacleCount == poolSize)
        {

            obstacleCount = 0;

        }

    }

    void IPausable.Pause()
    {
        
        pausedtime = timElapsed;
        
    }

    void IResumable.Resume()
    {
        
        timElapsed = pausedtime;
    }
}
