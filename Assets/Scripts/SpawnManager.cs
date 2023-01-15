using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] animalPrefabs;

    private float spawnRange = 10f;

    private float spawnPos = 20f;

    private float spawnDelay = 2f;

    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAninal", spawnDelay, spawnInterval);
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnAninal()
    {
        Vector3 position = new Vector3(Random.Range(-spawnRange, spawnRange), 0, spawnPos);

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], position, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnEnemy()
    {
        bool isRight = (Random.Range(0, 2) == 1) ? false : true;

        Vector3 position = new Vector3(-25, 0, Random.Range(-1, 5));

        if (isRight) {
            position = new Vector3(25, 0, Random.Range(-1, 5));
        }

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        var enemy = Instantiate(animalPrefabs[animalIndex], position, animalPrefabs[animalIndex].transform.rotation);

        if (isRight) {
            enemy.transform.Rotate(0, 90f, 0);
        }
        else {
            enemy.transform.Rotate(0, -90f, 0);
        }

        enemy.GetComponent<AnimalController>().makeEnemy();

        var progressBar = enemy.transform.Find("FeedProgress");

        Destroy(progressBar.gameObject);

    }

}
