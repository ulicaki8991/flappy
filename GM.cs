using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public GameObject[] pipePrefabs; // Array of pipe prefabs to choose from
    public float spawnInterval = 5f; // Time interval between spawns
    public Transform pipeSpawnPos;
    private float timer;

    void Start()
    {
        timer = spawnInterval;
        SpawnRandomPipe();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnRandomPipe();
            timer = spawnInterval;
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
}
