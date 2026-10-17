using UnityEngine;

public class Flower : MonoBehaviour
{
    public float speed = 5f;

    private float leftEdge;

    protected virtual void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;

        if (transform.position.x < leftEdge)
        {
            StopAllCoroutines();
            CancelInvoke();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    protected virtual void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
    }

    public virtual bool IsClosed()
    {
        return false;
    }
}