using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private DateTime lastSpawn;

    private float delayBeforeRespawn = 2f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var diffInSeconds = (System.DateTime.Now - lastSpawn).TotalSeconds;

            if (diffInSeconds > delayBeforeRespawn) {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                lastSpawn = System.DateTime.Now;
            }

        }
    }
}
