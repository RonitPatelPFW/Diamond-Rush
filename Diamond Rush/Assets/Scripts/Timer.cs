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

    private float timeLeft;
    private bool timerOn = false;
    public Text startTimerText;

    private int diamondsCount;

    private bool callOnce = false;

    public bool ifGameScene;
    float pb1;
    float pb2;
    float pb3;
    void Start()
    {
        text1.text = PlayerPrefs.GetFloat("Player PB1").ToString("0.###");
        if(text1.text == "0") {
            text1.text = "";
        }
        text2.text = PlayerPrefs.GetFloat("Player PB2").ToString("0.###");
        if(text2.text == "0") {
            text2.text = "";
        }
        text3.text = PlayerPrefs.GetFloat("Player PB3").ToString("0.###");
        if(text3.text == "0") {
            text3.text = "";
        }
        
        if(ifGameScene) {
            StartCoroutine(startEvent());
        }
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
       
        if(ifGameScene) {
            if (diamonds != null) {
                diamondsCount = diamonds.transform.childCount;
            }
            if(timerOn) {
                timeLeft += Time.deltaTime;
                updateTimer(timeLeft);
            }
            if(diamondsCount == 0 && !callOnce) {
                    callOnce = true;
                    timerOn = false;

                if(text1.text != "") {
                    pb1 = float.Parse(text1.text);
                }
                else if(text2.text != "") {
                    pb2 = float.Parse(text2.text);
                }
                else if(text3.text != "") {
                    pb3 = float.Parse(text3.text);

                }

                    if (timeLeft < pb1) {
                        PlayerPrefs.SetFloat("Player PB3", pb2);
                        PlayerPrefs.SetFloat("Player PB2", pb1);
                        PlayerPrefs.SetFloat("Player PB1", timeLeft);
                        
                        text3.text = pb2.ToString("0.###");
                        if(pb2.ToString("0.###") == "0") {
                            text3.text = "";
                        }
                        text2.text = pb1.ToString("0.###");
                        text1.text = timeLeft.ToString("0.###");
                    }
                    else if (timeLeft < pb2) {
                        PlayerPrefs.SetFloat("Player PB3", pb2);
                        PlayerPrefs.SetFloat("Player PB2", timeLeft);
                        text3.text = pb2.ToString("0.###");
                        text2.text = timeLeft.ToString("0.###"); 
                    }
                    else if (timeLeft < pb3) {
                        PlayerPrefs.SetFloat("Player PB3", timeLeft);
                        text3.text = timeLeft.ToString("0.###");
                    }
                    else if (text1.text == "") {
                        PlayerPrefs.SetFloat("Player PB1", timeLeft);
                        text1.text = timeLeft.ToString("0.###");
                    }
                    else if (timeLeft > pb1 && text2.text == "") {
                        PlayerPrefs.SetFloat("Player PB2", timeLeft);
                        text2.text = timeLeft.ToString("0.###");
                    }
                    else if (timeLeft > pb2 && text3.text == "") {
                        PlayerPrefs.SetFloat("Player PB3", timeLeft);
                        text3.text = timeLeft.ToString("0.###");
                    } 

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
