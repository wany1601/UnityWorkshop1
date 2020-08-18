using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public float spawnSpeed;
    public float timeToLive;
    private float nextSpawnTime = 0;
    private float xRange = 10;

    private float xOri;


    // Start is called before the first frame update
    void Start()
    {
        // TODO: Obtain relevant information from GameSettings
        // get the position of the boulder spawner 
        xOri = GameObject.Find("BoulderSpawner").transform.position[0];
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Spawn boulders with fixed time interval (0.5 second)
        if (Time.time > nextSpawnTime)
        {
            GameObject obj = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
            nextSpawnTime += 1 / spawnSpeed;
        }

        // TODO: Randomize the position so that the boulder does not always spawn at the same location
        //       HINT: Use UnityEngine.Random.Range()
        float xDelta = UnityEngine.Random.Range(-xRange, xRange);
        transform.position = new Vector3(xOri + xDelta, transform.position.y, transform.position.z);
    }
}
