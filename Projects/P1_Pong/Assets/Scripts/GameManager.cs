using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Score score;
    public Ball ball;
    public GameStates gameState;
    private int paddleHits = 0;
    public int hitsPerSpawn = 4;

    private void Start()
    {
        StartRound();
    }

    public void StartRound()
    {
        ball.ResetBall();
        ball.AddStartingForce();
    }

    public void CourtTriggered(int courtId)
    {
        score.IncreaseScore((courtId == 0 ? 1 : 0)); //If left court was triggered, right player scores & vice versa
        StartRound();
    }

    public void RegisterPaddleHit()
    {
        paddleHits++;

        Debug.Log("Paddle hits: " + paddleHits);

        if (paddleHits % hitsPerSpawn == 0)
        {
            SpawnNewBall();
        }
    }

    private void SpawnNewBall()
    {
        Ball newBall = Instantiate(ball, Vector3.zero, Quaternion.identity);

        newBall.ResetBall();
        newBall.AddStartingForce();
    }
}