using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Score score;
    public Ball ball;
    public GameStates gameState;
    private int paddleHits = 0;
    public int hitsPerSpawn = 4;
    public Player1Controller player1Controller;
    public Player2Controller player2Controller;
    public GameObject gameOverScreen;
    private int activeBalls = 1;
    private bool gameOver = false;

    private void Start()
    {
        StartRound();
    }

    public void StartRound()
    {
        ball.ResetBall();
        ball.AddStartingForce();
    }

    public void RegisterPaddleHit()
    {
        paddleHits++;
        if (paddleHits % hitsPerSpawn == 0)
        {
            SpawnNewBall();
        }
    }

    private void SpawnNewBall()
    {
        //instantiate = duplicates object, quaternion.identity = zero rotation
        Ball newBall = Instantiate(ball, Vector3.zero, Quaternion.identity);

        newBall.ResetBall();
        newBall.AddStartingForce();
        BallSpawned();
    }
    
    public void BallSpawned()
    {
        activeBalls++;
    }

    public void BallExited(Ball ball)
    {
        activeBalls--;
        Destroy(ball.gameObject);

        if (activeBalls <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver = true;
        player1Controller.enabled = false;
        player2Controller.enabled = false;
        gameOverScreen.SetActive(true);
    }
}