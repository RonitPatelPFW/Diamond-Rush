using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplay : MonoBehaviour
{

    public int count;
    public Text scoreText;

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
