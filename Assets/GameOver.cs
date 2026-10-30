using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public GameObject gameOverPanel;
    public string sceneToLoad;
    public string mainMenuScene;

    void Awake(){
        instance = this;
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver(){
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void PlayAgain(){
        Time.timeScale = 1f; // Resume game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayWholeGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToLoad);
    }

    public void MainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }
}
