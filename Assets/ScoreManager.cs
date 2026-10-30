using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text endScore;
    
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
        endScore.text = "Score: " + score.ToString(); // To display end score
        if(score >= 14){
            SceneChanger.instance.ShowTunnel();
        }
    }

}
