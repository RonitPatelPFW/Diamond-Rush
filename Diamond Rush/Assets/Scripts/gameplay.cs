using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplay : MonoBehaviour
{
    public GameObject settings;
    private int count;
    public Text scoreText;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
             if(!settings.activeSelf) {
            Time.timeScale = 0;
            settings.SetActive(true);
        }
        else {
            settings.SetActive(false);
            Time.timeScale = 1;
        }
        }
    } 
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Diamond"))
        {
            Destroy(col.gameObject);
            count++;
            scoreText.text = "Gems: " + count.ToString() + "/9";
        }
    }
}
