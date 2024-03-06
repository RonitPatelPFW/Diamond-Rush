using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timerOn = false;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn) {
            if(timeLeft > 0) {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else {
                Debug.Log("Time is up");
                timeLeft = 0;
                timerOn = false;
                timerText.text = string.Format("00:00:000");
            }
        }
    }
    void updateTimer(float currentTime) {
        currentTime += 1;

        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60);
        float milli = Mathf.FloorToInt(currentTime * 1000) % 1000; // Calculate milliseconds

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", min, sec, milli);
    }
}
