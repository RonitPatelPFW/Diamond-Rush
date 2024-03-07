using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplay : MonoBehaviour
{
    public GameObject diamonds;
    public Text scoreText;
    public Text startTimerText;
    int count;

    public float timeLeft;
    public bool timerOn = false;
    public Text timerText;

    void Start()
    {
        count = 0;
        StartCoroutine(startEvent());
    }
    IEnumerator startEvent()
        {
            yield return new WaitForSeconds(0);
            startTimerText.text = "3";
            yield return new WaitForSeconds(1);
            startTimerText.text = "2";
            yield return new WaitForSeconds(1);
            startTimerText.text = "1";
            yield return new WaitForSeconds(1);
            startTimerText.text = "GO";
            yield return new WaitForSeconds(1);
            startTimerText.text = "";
            timerOn = true;
            //enable gems
            scoreText.text = "Gem: 0/9";
            diamonds.SetActive(true);

        }

    // Update is called once per frame
    void Update()
    {
            if(timerOn) {
                // if(timeLeft < 0) {
                //     timeLeft += Time.deltaTime;
                //     updateTimer(timeLeft);
                // }
                // else {
                //     timeLeft = 0;
                //     timerOn = false;
                //     timerText.text = string.Format("00:00:000");
                // }
                timeLeft += Time.deltaTime;
                updateTimer(timeLeft);
            }
        if(count == 9) {
            timerOn = false;
        }
    }
    void updateTimer(float currentTime) {
        // currentTime += 1;

        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60);
        float milli = Mathf.FloorToInt(currentTime * 1000) % 1000; // Calculate milliseconds

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", min, sec, milli);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Diamond")
        {
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            col.gameObject.GetComponent<Collider2D>().enabled = false;
            count++;
            scoreText.text = "Gems: " + count.ToString() + "/9";
        }
    }
}
