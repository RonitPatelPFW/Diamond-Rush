using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject howto;
    public GameObject pb;
    public GameObject gameOver;

    public void playGame() {
        SceneManager.LoadScene("Game");
    }

    public void mainMenu() {
        SceneManager.LoadScene("Main Menu");

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

    public void closePB() {
        pb.SetActive(false);
        gameOver.SetActive(true);

    }
}
