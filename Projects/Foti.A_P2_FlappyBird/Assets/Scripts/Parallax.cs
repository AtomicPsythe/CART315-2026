
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float animationSpeed = 0.1f;

    public bool isScrolling = true;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (!isScrolling)
        {
            return;
        }

        meshRenderer.material.mainTextureOffset +=
            Vector2.right * animationSpeed * Time.deltaTime;
    }

    public void StopScrolling()
    {
        isScrolling = false;
    }
}