using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float moveSpeed = 100;
    private Vector2 input;
    public float boostMultiplier = 2f;
    public float boostDuration = 0.5f;
    private float boostTimer;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public Color boostColor = Color.yellow;

    public bool canEatCats = false;

    public float candyDuration = 5f; // Duration for which the player can eat cats
    private float candyTimer;

    public void ActivateCandy(){
        canEatCats = true;
        candyTimer = candyDuration;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // Start with original color
    }

    void FixedUpdate(){
        float currentMoveSpeed = moveSpeed;

        if(boostTimer > 0){
            currentMoveSpeed *= boostMultiplier;
            boostTimer -= Time.fixedDeltaTime;
        }
        else{
            spriteRenderer.color = originalColor;
        }

        if (input.x != 0){
            input.y = 0;
        } 

        rb.linearVelocity = input * currentMoveSpeed * Time.fixedDeltaTime;
        if(rb.linearVelocity != Vector2.zero){
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        // Press space for boost
        if(Input.GetKeyDown(KeyCode.Space) && input != Vector2.zero){
            SoundManager.instance.PlayBoost();
            boostTimer = boostDuration;
            spriteRenderer.color = boostColor;
        }

        // Countdown timer for candy effect
        if(canEatCats){
            candyTimer -= Time.deltaTime;
            if(candyTimer <= 0){
                canEatCats = false;
            }
        }
    }

    
}
