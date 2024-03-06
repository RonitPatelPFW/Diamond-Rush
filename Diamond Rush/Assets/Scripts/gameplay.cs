using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameplay : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    int count;
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Diamond")
        {
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            col.gameObject.GetComponent<Collider2D>().enabled = false;
            count++;
            scoreText.text = "Score: " + count.ToString();
        }
    }
}
