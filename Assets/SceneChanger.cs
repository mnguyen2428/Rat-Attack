using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
    public string sceneToLoad;
    public GameObject goldTunnel;
    

    void Awake(){
        instance = this;
        goldTunnel.SetActive(false);
    }

    public void ShowTunnel(){
        goldTunnel.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
