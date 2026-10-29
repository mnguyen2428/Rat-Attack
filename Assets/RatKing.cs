using UnityEngine;
using UnityEngine.SceneManagement;

public class RatKing : MonoBehaviour
{
    public string sceneToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player wins!!!");
            SceneManager.LoadScene(sceneToLoad);

        }
    }
    
}
