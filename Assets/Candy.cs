using UnityEngine;

public class Candy : MonoBehaviour
{
    public GameObject pairedCheese;

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();

        if(collision.CompareTag("Player") && player != null){
            SoundManager.instance.PlayCandyCrunch();
            player.ActivateCandy();
            Debug.Log("Rat can now eat cats");

            if(pairedCheese != null){
                Destroy(pairedCheese); // Destroy the paired cheese if it exists
            }
            
            Destroy(gameObject);
        }
    }
    
}
