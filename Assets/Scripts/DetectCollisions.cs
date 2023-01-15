using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    private Ui ui;

    private ProgressBar progressBar;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Ui").GetComponent<Ui>();
        progressBar = transform.Find("FeedProgress").gameObject.GetComponent<ProgressBar>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (!isEnemy()) {
            feed();
            Destroy(other.gameObject);
        }
    }

    private bool isEnemy()
    {
        return gameObject.GetComponent<AnimalController>().isEnemy;
    }

    private void feed()
    {
        progressBar.feed();
        if (progressBar.isFed()) {
            ui.updateScore(1);
            Destroy(gameObject);
        }
    }

}
