using UnityEngine;

public class RinkHole : MonoBehaviour
{
    public float speedChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();

        if (ball != null)
        {
            ball.ChangeSpeed(speedChange);
        }
    }
}