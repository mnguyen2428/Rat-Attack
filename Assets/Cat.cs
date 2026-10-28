using UnityEngine;

public class Cat : MonoBehaviour
{
    public float speed = 4f;
    public Vector2 direction;
    private Animator animator;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color eatColor = Color.blue;

    private PlayerControl player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponentInParent<PlayerControl>();
        if (player != null)
        {
            if (player.canEatCats)
            {
                Debug.Log("Player ate the cat!");
                ScoreManager.instance.AddScore(2); // Increase the score by 2
                player.canEatCats = false; // Reset the ability to eat cats
                Destroy(gameObject); // Destroy the cat after being eaten
            }
            else
            {
                Debug.Log("Cat eat rat. Game over");
                GameOver.instance.ShowGameOver(); // Call the GameOver method from GameManager
            }
        }
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        animator = GetComponent<Animator>();

        player = FindAnyObjectByType<PlayerControl>();
        if(player != null){
            player = player.GetComponent<PlayerControl>();
        }

        Destroy(gameObject, 10f); // Destroy the cat after 10 seconds
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        if (direction.x != 0 || direction.y != 0)
        {
            animator.SetFloat("moveX", direction.x);
            animator.SetFloat("moveY", direction.y);
        }
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate(){
        if(player != null && player.canEatCats){
            //Debug.Log("Cat blue!!");
            spriteRenderer.color = eatColor;
        }
        else{
            spriteRenderer.color = originalColor;
        }
    }
}
