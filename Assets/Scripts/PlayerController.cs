using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;

    public float verticalInput;

    public int speed = 10;

    public float currentXPosition;

    public float currentZPosition;

    private float maxSpan = 10;

    private float minPlayerVertical = -1f;

    private float maxPlayerVertical = 4f;

    public GameObject foodPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AssertHorizontal();
        AssertVertital();
        LaunchFood();
    }

    void AssertHorizontal()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        currentXPosition = transform.position.x;

        if (currentXPosition < -maxSpan) {
            transform.position = new Vector3(-maxSpan, transform.position.y, transform.position.z);
        }

        if (currentXPosition > maxSpan) {
            transform.position = new Vector3(maxSpan, transform.position.y, transform.position.z);
        }
    }

    void AssertVertital()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        currentZPosition = transform.position.z;

        if (currentZPosition < minPlayerVertical) {
            transform.position = new Vector3(transform.position.x, transform.position.y, minPlayerVertical);
        }

        if (currentZPosition > maxPlayerVertical) {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxPlayerVertical);
        }
    }

    void LaunchFood()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(foodPrefab, transform.position, foodPrefab.transform.rotation);
        }
    }

}
