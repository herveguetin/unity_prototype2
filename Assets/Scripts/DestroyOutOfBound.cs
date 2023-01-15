using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{

    private float topBound = 30f;
    private float bottomBound = -10f;
    private Ui ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Ui").GetComponent<Ui>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < bottomBound) {
            Destroy(gameObject);
            ui.updateScore(-1);
        }
    }

}
