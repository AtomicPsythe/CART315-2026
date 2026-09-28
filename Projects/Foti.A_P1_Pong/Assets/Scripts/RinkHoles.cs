using UnityEngine;

public class RinkHole : MonoBehaviour
{
    public float sizeChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();

        if (ball != null)
        {
            ball.ChangeSize(sizeChange);
        }
    }
}