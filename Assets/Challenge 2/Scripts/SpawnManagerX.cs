using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = 9;
    private float spawnLimitXRight = 30;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(0, spawnPosY, Random.Range(spawnLimitXLeft, spawnLimitXRight));
        int indexToSpawn = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[indexToSpawn], spawnPos, ballPrefabs[indexToSpawn].transform.rotation);

        float randomTime = Random.Range(3,5);
        Invoke("SpawnRandomBall", randomTime);
    }

}
