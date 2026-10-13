using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float animationSpeed = 0.1f;
    public bool isScrolling = true;
    
    public float scrollDuration = 12f;
    public GameObject leafPlatform;

    private MeshRenderer meshRenderer;
    private float timer = 0f;
    private Vector3 leafPlatformStartPosition;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (leafPlatform != null)
        {
            leafPlatformStartPosition = leafPlatform.transform.position;
        }

        ResetParallax();
    }

    private void Update()
    {
        if (!isScrolling) return;

        meshRenderer.material.mainTextureOffset +=
            Vector2.right * animationSpeed * Time.deltaTime;

        timer += Time.deltaTime;
        if (timer >= scrollDuration)
        {
            StopScrolling();
        }
    }

    public void StopScrolling()
    {
        isScrolling = false;

        if (leafPlatform != null)
        {
            leafPlatform.SetActive(true);
        }
    }

    public void ResetParallax()
    {
        timer = 0f;
        isScrolling = true;
        meshRenderer.material.mainTextureOffset = Vector2.zero;

        if (leafPlatform != null)
        {
            leafPlatform.transform.position = leafPlatformStartPosition;
            leafPlatform.SetActive(false);
        }
    }
}