using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Court : MonoBehaviour
{
    public GameManager gameManager;
    public int courtId = 0;

    public EventTrigger.TriggerEvent courtTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball == null) return;

        gameManager.BallExited(ball);
    }
}