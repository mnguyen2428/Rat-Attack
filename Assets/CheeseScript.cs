using UnityEngine;

public class CheeseScript : MonoBehaviour
{
    public GameObject pairedCandy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player collected the cheese!");
            ScoreManager.instance.AddScore(1); // Increase the score by 1

            if(pairedCandy != null){
                Destroy(pairedCandy); // Destroy the paired candy if it exists
            }
            Destroy(gameObject); // Destroy the cheese after collection
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
