using UnityEngine;

public class Sunflower : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closedSprite;

    public float openTime = 3f;
    public float closedTime = 2f;

    private SpriteRenderer spriteRenderer;
    private Collider2D flowerCollider;

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
        spriteRenderer.sprite = openSprite;
        flowerCollider.enabled = true;

        Invoke(nameof(CloseFlower), openTime);
    }

    private void CloseFlower()
    {
        spriteRenderer.sprite = closedSprite;
        flowerCollider.enabled = false;

        Invoke(nameof(OpenFlower), closedTime);
    }
}