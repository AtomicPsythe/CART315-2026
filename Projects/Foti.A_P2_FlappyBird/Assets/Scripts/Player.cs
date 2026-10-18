using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Sprite stuff
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    // Player movement
    public float moveSpeed = 5f;
    public float flutterForce = 7f;

    // Player stamina (code done with the assistance of my friend Alissia Bocarro)
    public Image StaminaBar;
    public float MaxStamina = 100f;
    public float Stamina;
    public float flutterCost = 15f;
    public float chargeRate = 35f;

    private Vector3 startingPosition;
    private Rigidbody2D rb;
    private Coroutine rechargeCoroutine;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        startingPosition = transform.position;
        
        // stamina values at game start (code done with the assistance of my friend Alissia Bocarro)
        Stamina = MaxStamina;
        UpdateStaminaUI();
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length) spriteIndex = 0;

        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private void Update()
    {
        // horizontal movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // vertical movement (only if player has enough stamina, code done with the assistance of my friend Alissia Bocarro)
        if (Input.GetKeyDown(KeyCode.Space) && Stamina >= flutterCost)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, flutterForce);

            // using stamina (code done with the assistance of my friend Alissia Bocarro)
            Stamina -= flutterCost;
            if (Stamina < 0) Stamina = 0;
            UpdateStaminaUI();

            if (rechargeCoroutine != null)
            {
                StopCoroutine(rechargeCoroutine);
            }
            rechargeCoroutine = StartCoroutine(RechargeStaminaRoutine());
        }
    }

    // (code done with the assistance of my friend Alissia Bocarro)
    private IEnumerator RechargeStaminaRoutine()
    {
        yield return new WaitForSeconds(1.0f);

        while (Stamina < MaxStamina)
        {
            Stamina += chargeRate * Time.deltaTime;
            if (Stamina > MaxStamina) Stamina = MaxStamina;
            
            UpdateStaminaUI();
            yield return null;
        }
    }

    // (code done with the assistance of my friend Alissia Bocarro)
    private void UpdateStaminaUI()
    {
        if (StaminaBar != null)
        {
            StaminaBar.fillAmount = Stamina / MaxStamina;
        }
    }

    public void ResetPlayer()
    {
        transform.position = startingPosition;
        rb.linearVelocity = Vector2.zero;
        
        Stamina = MaxStamina;
        UpdateStaminaUI();
        if (rechargeCoroutine != null)
        {
            StopCoroutine(rechargeCoroutine);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EndPlatform"))
        {
            GameManager.Instance.LevelComplete();
            return;
        }
        
        if (collision.gameObject.CompareTag("Flower"))
        {
            Flower flower = collision.gameObject.GetComponent<Flower>();

            if (flower != null && flower.IsClosed())
            {
                GameManager.Instance.GameOver();
            }

            return;
        }

        GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Flower flower = other.GetComponent<Flower>(); 
        if (flower != null)
        {
            if (flower.IsClosed())
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
