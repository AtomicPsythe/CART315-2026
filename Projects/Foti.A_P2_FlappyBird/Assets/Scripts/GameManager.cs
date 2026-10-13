using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject nextLevelButton;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI gameOver;
    [SerializeField] private TextMeshProUGUI levelComplete;

    [SerializeField] private Parallax parallax;


    public int score { get; private set; } = 0;

    private void Awake()
    {
        if (Instance != null) 
        {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) 
        {
            Instance = null;
        }
    }

    private void Start()
    {
        if (titleText != null) titleText.gameObject.SetActive(true);
        if (gameOver != null) gameOver.gameObject.SetActive(false);
        if (levelComplete != null) levelComplete.gameObject.SetActive(false);
        if (nextLevelButton != null) nextLevelButton.SetActive(false);
        playButton.SetActive(true);
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        if (nextLevelButton != null) nextLevelButton.SetActive(false);
        if (gameOver != null) gameOver.gameObject.SetActive(false);
        if (levelComplete != null) levelComplete.gameObject.SetActive(false);
        if (titleText != null) titleText.gameObject.SetActive(false);

        if (parallax != null)
        {
            parallax.ResetParallax();
        }

        if (spawner != null)
        {
            spawner.ResetSpawner();
        }

        player.ResetPlayer();

        Time.timeScale = 1f;
        player.enabled = true;

        Flower[] flowers = FindObjectsByType<Flower>(FindObjectsSortMode.None);

        for (int i = 0; i < flowers.Length; i++)
        {
            Destroy(flowers[i].gameObject);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        if (gameOver != null) gameOver.gameObject.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void LevelComplete()
    {
        if (parallax != null) 
        {
            parallax.StopScrolling();
        }

        if (levelComplete != null) 
        {
            levelComplete.gameObject.SetActive(true);
        }

        if (nextLevelButton != null) nextLevelButton.SetActive(true); 

        Pause();
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
