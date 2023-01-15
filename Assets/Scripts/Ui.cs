using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{

    public int lives = 3;

    private string message = "Lives: ";

    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LIVES: " + lives);
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 1 && !isGameOver) {
            Debug.Log("GAME OVER!");
            isGameOver = true;
        }
    }

    public void updateScore(int changed)
    {
        lives = lives + changed;
        lives = (lives < 0) ? 0 : lives;
        showLives();
    }

    private void showLives()
    {
        Debug.Log(message + lives);
    }

}
