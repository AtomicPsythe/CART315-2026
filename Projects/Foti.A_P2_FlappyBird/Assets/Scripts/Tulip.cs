using System.Collections;
using UnityEngine;

// borrows from the Flower.cs script
public class Tulip : Flower 
{
    public Sprite openSprite;
    public Sprite closedSprite;
    // variable for the custom polygoncollider2d
    private PolygonCollider2D polyCollider;

    public float minOpenTime = 1.5f;
    public float maxOpenTime = 3f;

    public float minClosedTime = 0.5f;
    public float maxClosedTime = 2f;

    // flashing color to warn the player before the flower closes
    public float warningDuration = 0.8f; 
    public float pulseSpeed = 7f;
    public Color warningColor = new Color(0.5f, 0.0f, 1.0f, 1.0f); 

    private SpriteRenderer spriteRenderer;
    private Collider2D flowerCollider;

    private bool isClosed = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        flowerCollider = GetComponent<Collider2D>();
        polyCollider = GetComponent<PolygonCollider2D>();
    }

    protected override void Start()
    {
        base.Start();
        OpenFlower();
    }

    private void OpenFlower()
    {
        isClosed = false;

        spriteRenderer.sprite = openSprite;

        // resets flower color to original image
        spriteRenderer.color = Color.white;

        flowerCollider.enabled = true;
        polyCollider.pathCount = 0;

        float randomOpenTime = Random.Range(minOpenTime, maxOpenTime);
        Invoke(nameof(StartWarningSequence), randomOpenTime);
    }

    private void StartWarningSequence()
    {
        StartCoroutine(FlashWarningRoutine());
    }

    private IEnumerator FlashWarningRoutine()
    {
        float elapsed = 0f;

        while (elapsed < warningDuration)
        {
            // pulses the flashing colors at a steady pace
            float t = Mathf.PingPong(elapsed * pulseSpeed, 1f);
            spriteRenderer.color = Color.Lerp(Color.white, warningColor, t);

            elapsed += Time.deltaTime;
            yield return null; 
        }

        CloseFlower(); 
    }

    private void CloseFlower()
    {
        isClosed = true;

        spriteRenderer.sprite = closedSprite;
        spriteRenderer.color = Color.white;
        flowerCollider.enabled = true;
        polyCollider.pathCount = 0;

        float randomClosedTime = Random.Range(minClosedTime, maxClosedTime);
        Invoke(nameof(OpenFlower), randomClosedTime);
    }

    public override bool IsClosed() 
    {
        return isClosed;
    }
}
