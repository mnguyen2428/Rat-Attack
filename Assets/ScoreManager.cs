using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TMP_Text scoreText;
    
    void Awake(){
        instance = this;
        UpdateScoreText();
    }

    public void AddScore(int amount){
        score += amount;
        UpdateScoreText();
    }

    public void RemoveScore(int amount){
        score -= amount;
        if(score < 0){
            score = 0;
        }
        UpdateScoreText();
    }

    void UpdateScoreText(){
        scoreText.text = "Score: " + score.ToString();
    }

}
