using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeControls : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider mainSlider;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = mainSlider.value;
    }
}
