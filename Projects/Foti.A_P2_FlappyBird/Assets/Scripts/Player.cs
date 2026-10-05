using UnityEngine;

public class Player : MonoBehaviour
{
    // Sprite Stuff
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    public float moveSpeed = 5f;
    public float flutterForce = 7f;

    private Vector3 startingPosition;

    private Rigidbody2D rb;

    private void Awake()
    {
        // For animating the sprites
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        // Remember where the butterfly starts
        startingPosition = transform.position;
    }

    private void Start()
    {
        // Repeats the sprite animation
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);

        startingPosition = transform.position;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private void Update()
    {
        // Horizontal Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(
            horizontalInput * moveSpeed,
            rb.linearVelocity.y
        );

        // Vertical Movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                flutterForce
            );
        }
    }

    public void ResetPlayer()
    {
        transform.position = startingPosition;
        rb.linearVelocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Scoring"))
        {
            GameManager.Instance.IncreaseScore();
        }
    }
}
