using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public float speed = 140.0f;
    public float speedIncrease = 20.0f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void ResetBall()
    {
        _rigidBody.linearVelocity = Vector2.zero;
        _rigidBody.angularVelocity = 0;
        transform.position = Vector3.zero;
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.8f ? -1.0f : 1.0f;
        float y = (Random.value < 0.8f ? -1.0f : 1.0f) * Random.Range(0.8f, 0.9f);

        Vector2 direction = new Vector2(x, y);

        _rigidBody.AddForce(direction * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Paddle>() != null)
        {
            speed += speedIncrease;
            AddStartingForce();

            GameManager gameManager = FindFirstObjectByType<GameManager>();
            gameManager.RegisterPaddleHit();
        }
    }
}