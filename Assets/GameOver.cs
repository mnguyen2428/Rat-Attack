using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public GameObject gameOverPanel;

    void Awake(){
        instance = this;
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver(){
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void PlayAgain(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
