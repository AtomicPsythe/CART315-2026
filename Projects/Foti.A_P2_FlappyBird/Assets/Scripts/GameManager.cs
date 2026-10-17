using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private GameObject spawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject nextLevelButton;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI gameOver;
    [SerializeField] private TextMeshProUGUI levelComplete;

    [SerializeField] private Parallax parallax;

    public TextMeshProUGUI countdownText;

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
        if (gameOver != null) gameOver.gameObject.SetActive(false);
        if (levelComplete != null) levelComplete.gameObject.SetActive(false);
        if (nextLevelButton != null) nextLevelButton.SetActive(false);

        Pause();
        StartCoroutine(StartCountdown());
    }

    // countdown code reused from my Prototype 1's main menu script
    private IEnumerator StartCountdown()
    {
        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "2";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "1";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "GO!";
        
        Unpause();

        yield return new WaitForSecondsRealtime(1f);
        countdownText.gameObject.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        if (player != null) player.enabled = true;
        if (spawner != null) spawner.SetActive(true);
    }

    public void Play()
    {
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
            if (spawner.TryGetComponent(out Spawner baseSpawner)) {
                baseSpawner.ResetSpawner();
            } 

            else if (spawner.TryGetComponent(out TulipSpawner tulipSpawner)) {
                tulipSpawner.ResetSpawner();
            }
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
        if (gameOver != null) gameOver.gameObject.SetActive(true);
        Pause();
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
