using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject diamonds;

    public Text text1;
    public Text text2;
    public Text text3;

    public Text timerText;
    public Text scoreText;

    public float timeLeft;
    public bool timerOn = false;
    public Text startTimerText;

    private int diamondsCount;

    private bool callOnce = false;

    void Start()
    {
        text1.text = PlayerPrefs.GetFloat("Player PB1").ToString();
        text2.text = PlayerPrefs.GetFloat("Player PB2").ToString();
        text3.text = PlayerPrefs.GetFloat("Player PB3").ToString();
        StartCoroutine(startEvent());
        Time.timeScale = 1;
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
            scoreText.text = "Gems: 0/9";
            diamonds.SetActive(true);

        }
    // Update is called once per frame
    void Update()
    {
        if (diamonds != null) {
            diamondsCount = diamonds.transform.childCount;
        }
            if(timerOn) {
                timeLeft += Time.deltaTime;
                updateTimer(timeLeft);
            }
        if(diamondsCount == 0) {
            if(!callOnce) {
                callOnce = true;
                timerOn = false;
                PlayerPrefs.SetFloat("Player Time", timeLeft);
                float playerTime = Mathf.Round(PlayerPrefs.GetFloat("Player Time") * 1000f) / 1000f;
                float pb1 = Mathf.Round(PlayerPrefs.GetFloat("Player PB1") * 1000f) / 1000f;
                float pb2 = Mathf.Round(PlayerPrefs.GetFloat("Player PB2") * 1000f) / 1000f;
                float pb3 = Mathf.Round(PlayerPrefs.GetFloat("Player PB3") * 1000f) / 1000f;

                text1.text = PlayerPrefs.GetFloat("Player PB1").ToString();
                text2.text = PlayerPrefs.GetFloat("Player PB2").ToString();
                text3.text = PlayerPrefs.GetFloat("Player PB3").ToString();
                if (playerTime < pb1) {
                    PlayerPrefs.SetFloat("Player PB3", pb2);
                    PlayerPrefs.SetFloat("Player PB2", pb1);
                    PlayerPrefs.SetFloat("Player PB1", playerTime);
                    text1.text = playerTime.ToString("0.###"); // Round and format the time
                    text2.text = pb2.ToString("0.###");
                    text3.text = pb3.ToString("0.###");
                }
                else if (playerTime < pb2) {
                    PlayerPrefs.SetFloat("Player PB3", pb2);
                    PlayerPrefs.SetFloat("Player PB2", playerTime);
                    text2.text = playerTime.ToString("0.###"); // Round and format the time
                    text3.text = pb3.ToString("0.###");
                }
                else if (playerTime < pb3) {
                    PlayerPrefs.SetFloat("Player PB3", playerTime);
                    text3.text = playerTime.ToString("0.###"); // Round and format the time
                }
                else if (pb1 == 0) {
                    PlayerPrefs.SetFloat("Player PB1", playerTime);
                    text1.text = playerTime.ToString("0.###"); // Round and format the time
                }
                else if (playerTime > pb1 && pb2 == 0) {
                    PlayerPrefs.SetFloat("Player PB2", playerTime);
                    text2.text = playerTime.ToString("0.###"); // Round and format the time
                }
                else if (playerTime > pb2 && pb3 == 0) {
                    PlayerPrefs.SetFloat("Player PB3", playerTime);
                    text3.text = playerTime.ToString("0.###"); // Round and format the time
                } 
                Debug.Log("Time: " + playerTime);
                Debug.Log("1: " + pb1);
                Debug.Log("2: " + pb2);
                Debug.Log("3: " + pb3);

                if(gameOver != null) {
                    gameOver.SetActive(true);
                }
            }
        }
    }
    void updateTimer(float currentTime) {
        // currentTime += 1;

        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60);
        float milli = Mathf.FloorToInt(currentTime * 1000) % 1000; // Calculate milliseconds

        timerText.text = string.Format("{0:00}.{1:000}", sec, milli);
    }
}
