using UnityEngine;

public class HeartObject : MonoBehaviour
{
    // speed at which the heart moves up and down
    [SerializeField] private float floatSpeed = 3f;
    // rate at which the heart moves up and down
    [SerializeField] private float floatAmplitude = 0.15f;

    private Vector3 startRelativePosition;

    private void Start()
    {
        startRelativePosition = transform.localPosition;
    }

    private void Update()
    {
        // code that dictates it floating
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.localPosition = new Vector3(startRelativePosition.x, startRelativePosition.y + newY, startRelativePosition.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

