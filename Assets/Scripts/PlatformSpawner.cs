using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platforms;
    public float spawnRate = 1;
    //private float _currentTimer;
    public float _spawnTimer = 2;
    private float lastSpawnTime = 0;
    public float spawnWidth = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawnTime + 1 / spawnRate < Time.time)
        {
            lastSpawnTime = Time.time;
            Vector3 spawnPosition = transform.position;
            Vector3 spawnPosition2 = transform.position;
            spawnPosition += new Vector3(Random.Range(-10,10), 0, 0); // Random.Range(-spawnWidth, spawnWidth)
            spawnPosition2 += new Vector3(Random.Range(-10, 10), 0, 0); // Random.Range(-spawnWidth, spawnWidth)
            // the Instatiate function creates a new GameObject copy (clone) from a Prefab at a specific location and orientation.
            Instantiate(platforms, spawnPosition, Quaternion.identity);
            Instantiate(platforms, spawnPosition2, Quaternion.identity);
        }
    }


}
