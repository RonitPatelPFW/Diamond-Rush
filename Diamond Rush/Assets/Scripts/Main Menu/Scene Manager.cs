using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject howto;
    public GameObject pb;
    public GameObject settings;
    public GameObject gameOver;
    public GameObject gameInfo;
    public GameObject options;

    public void playGame() {
        SceneManager.LoadScene("Game");        
    }

    public void mainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void exitGame() {
        Application.Quit();
    }

    public void gameInfoControl() {
         if(!gameInfo.activeSelf) {
            gameInfo.SetActive(true);
        }
        else {
            gameInfo.SetActive(false);
        }
    }
    public void howToPlay() {
        if(!howto.activeSelf) {
            howto.SetActive(true);
        }
        else {
            howto.SetActive(false);
        }

    }

    public void closePB() {
        if(!pb.activeSelf) {
            pb.SetActive(true);  
        }
        else {
            pb.SetActive(false);  
        }
    }

    public void openSetting() {

        if(!settings.activeSelf) {
            Time.timeScale = 0;
            settings.SetActive(true);
        }
        else {
            settings.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void optionsControl() {

        if(!options.activeSelf) {
            options.SetActive(true);
        }
        else {
            options.SetActive(false);
        }
    }

}
