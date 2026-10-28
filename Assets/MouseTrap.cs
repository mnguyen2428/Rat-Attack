using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    public float trapDuration = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, trapDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player hit the mouse trap!");
            ScoreManager.instance.RemoveScore(1); // Decrease the score by 1
            Destroy(gameObject); // Destroy the mouse trap object after collision
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
