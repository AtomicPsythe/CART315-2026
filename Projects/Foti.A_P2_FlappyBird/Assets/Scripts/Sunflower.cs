using UnityEngine;

public class Sunflower : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closedSprite;

    public float minOpenTime = 2f;
    public float maxOpenTime = 5f;

    public float minClosedTime = 1f;
    public float maxClosedTime = 3f;

    private SpriteRenderer spriteRenderer;
    private Collider2D flowerCollider;

    private bool isClosed = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        flowerCollider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        OpenFlower();
    }

    private void OpenFlower()
    {
        isClosed = false;

        spriteRenderer.sprite = openSprite;
        flowerCollider.enabled = true;

        float randomOpenTime = Random.Range(minOpenTime, maxOpenTime);
        Invoke(nameof(CloseFlower), randomOpenTime);
    }

    private void CloseFlower()
    {
        isClosed = true;

        spriteRenderer.sprite = closedSprite;
        flowerCollider.enabled = true;

        float randomClosedTime = Random.Range(minClosedTime, maxClosedTime);
        Invoke(nameof(OpenFlower), randomClosedTime);
    }

    public bool IsClosed()
    {
        return isClosed;
    }
}