using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{

    public int feedGoal = 1;

    private int feedAchieved = 0;

    private float feedStep;

    public GameObject feedDone;

    // Start is called before the first frame update
    void Start()
    {
        feedStep = feedDone.transform.localScale.x / feedGoal;
    }

    // Update is called once per frame
    void Update()
    {
        var totalSteps = feedAchieved * feedStep;
        feedDone.transform.localScale = new Vector3(totalSteps, feedDone.transform.localScale.y, feedDone.transform.localScale.z);
    }

    public void feed()
    {
        if (feedAchieved < feedGoal) {
            feedAchieved++;
        }
    }

    public bool isFed()
    {
        return (feedAchieved == feedGoal);
    }

}
