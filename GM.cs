using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public GameObject[] pipePrefabs; // Array of pipe prefabs to choose from
    public float spawnInterval = 5f; // Time interval between spawns
    public Transform pipeSpawnPos;
    private float timer;

    public bool GameStarted = false;
    bool GameEndedBool = false;

    [Header("Points")]
    [SerializeField] public int Points;
    [SerializeField] Text ScorePointsText;
    [SerializeField] Text HighScorePointsText;

    void Start()
    {
        timer = spawnInterval;

        if(PlayerPrefs.HasKey("MaxScore"))
        {
            HighScorePointsText.text = "Highscore: " + PlayerPrefs.GetInt("MaxScore");
        }
        else
        {
            PlayerPrefs.SetInt("MaxScore", 0);
            HighScorePointsText.text = "Highscore: " + 0;
        }
    
    }

    public void AddScore ()
    {
        Points++;
        ScorePointsText.text = "Score: " + Points;
    }

    void Update()
    {
        if (GameStarted == true && GameEndedBool == false)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                if(GameEndedBool == false)
                SpawnRandomPipe();
                timer = spawnInterval;
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(GameStarted == false)
             SpawnRandomPipe();
            GameStarted = true;
   
        }

    }

    void SpawnRandomPipe()
    {
        // Randomly select a pipe prefab from the array
        int randomIndex = Random.Range(0, pipePrefabs.Length);
        GameObject pipePrefab = pipePrefabs[randomIndex];

        // Spawn the selected pipe prefab
        Instantiate(pipePrefab, pipeSpawnPos.position, Quaternion.identity);
    }


    public void GameEnd ()
    {
        GameEndedBool = true;

        if(PlayerPrefs.GetInt("MaxScore") < Points)
        {
            PlayerPrefs.SetInt("MaxScore", Points);
            HighScorePointsText.text = "Highscore: " + Points;
        }
    }
}
