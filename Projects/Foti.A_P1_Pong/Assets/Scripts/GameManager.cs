using System;
using TMPro;
using UnityEngine;
using System.Collections;

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
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI gameOverHighScoreText; 
    private int activeBalls = 1;
    private bool gameOver = false;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(0.5f);

        countdownText.gameObject.SetActive(false);

        StartRound();
    }

    public void StartRound()
    {
        activeBalls = 1;
        ball.ResetBall();
        ball.AddStartingForce();
        score.UpdatePuckCount(activeBalls);
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
        score.UpdatePuckCount(activeBalls);
    }

    public void BallExited(Ball ball)
    {
        activeBalls--;
        score.UpdatePuckCount(activeBalls);
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

        if (gameOverHighScoreText != null && score != null)
        {
            gameOverHighScoreText.text = "Highest Puck Count: " + score.highestPuckCount.ToString();
        }
        
        gameOverScreen.SetActive(true);
    }
}