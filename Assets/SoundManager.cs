using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip CatHiss;
    [SerializeField] private AudioClip CheeseCollect;
    [SerializeField] private AudioClip CandyCrunch;
    [SerializeField] private AudioClip RatTrap;
    [SerializeField] private AudioClip Boost;
    [SerializeField] private AudioSource audioSource;

    public static SoundManager instance;

    private void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void PlayCatHiss(){
        audioSource.PlayOneShot(CatHiss);
    }

    public void PlayCheeseCollect(){
        audioSource.PlayOneShot(CheeseCollect);
    }

    public void PlayCandyCrunch(){
        audioSource.PlayOneShot(CandyCrunch);
    }

    public void PlayRatTrap(){
        audioSource.PlayOneShot(RatTrap, 0.2f);
    }

    public void PlayBoost(){
        audioSource.PlayOneShot(Boost);
    }
}
