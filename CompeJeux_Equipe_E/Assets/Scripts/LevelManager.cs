using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public string time;
    public int flowersPlanted;
    public int weedsKilled;

    float seconds;
    int minutes;
    int hours;

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0;
        minutes = 0;
        hours = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    public void UpdateTime()
    {
        seconds += Time.deltaTime;
        time = (hours == 0 ? "" : hours + "h:") + (minutes == 0 ? "" : minutes + "m:") + (int)seconds + "s";
        if (seconds >= 60) {
            minutes++;
            seconds = 0;
        }
        else if (minutes >= 60) {
            hours++;
            minutes = 0;
        }
    }
}
