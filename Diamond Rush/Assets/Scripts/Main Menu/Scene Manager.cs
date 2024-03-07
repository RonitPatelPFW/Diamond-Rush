using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject howto;
    public void playGame() {
        SceneManager.LoadScene("Game");
    }

    public void exitGame() {
        Application.Quit();
    }

    public void howToPlay() {
        howto.SetActive(true);

    }

    public void exitHowToPlay() {
        howto.SetActive(false);

    }
}
