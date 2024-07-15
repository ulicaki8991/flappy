using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public GameObject[] pipePrefabs; // Array of pipe prefabs to choose from
    public float spawnInterval = 5f; // Time interval between spawns
    public Transform pipeSpawnPos;
    private float timer;

    public bool GameStarted = false;
    bool GameEndedBool = false;

    void Start()
    {
        timer = spawnInterval;
    
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

            GameStarted = true;
            SpawnRandomPipe();
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
    }
}
