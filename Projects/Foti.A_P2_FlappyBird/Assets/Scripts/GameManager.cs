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
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject tryAgainButton;
    [SerializeField] private GameObject nextLevelButton;

    // narrative scenes
    [SerializeField] private GameObject prologueButton;
    [SerializeField] private GameObject epilogueButton;

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
        if (tryAgainButton != null) tryAgainButton.SetActive(false);
        if (prologueButton != null) prologueButton.SetActive(false);
        if (epilogueButton != null) epilogueButton.SetActive(false);

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
        if (nextLevelButton != null) nextLevelButton.SetActive(false);
        if (gameOver != null) gameOver.gameObject.SetActive(false);
        if (levelComplete != null) levelComplete.gameObject.SetActive(false);
        if (titleText != null) titleText.gameObject.SetActive(false);
        if (tryAgainButton != null) tryAgainButton.SetActive(false); 

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
            else if (spawner.TryGetComponent(out Level3Spawner level3Spawner)) {
                level3Spawner.ResetSpawner();
            }
        }

        // resets the level completely (parallax, flowers, player, leaf platform)
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.ResetPlayer();

        Time.timeScale = 1f;
        player.enabled = true;
        Flower[] flowers = FindObjectsByType<Flower>(FindObjectsSortMode.None);

        for (int i = 0; i < flowers.Length; i++)
        {
            Destroy(flowers[i].gameObject);
        }

        StopAllCoroutines();
        Pause();
        StartCoroutine(StartCountdown());
    }

    public void GameOver()
    {
        if (gameOver != null) gameOver.gameObject.SetActive(true);
        if (tryAgainButton != null) tryAgainButton.SetActive(true); 
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

        // checks if there is a next level after the last one (level 3)
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // if there is a level that comes after, shows the next level button
            if (nextLevelButton != null) nextLevelButton.SetActive(true);
        }
        else
        {
            // if the epilogue is next, shows the epilogue button
            if (epilogueButton != null) epilogueButton.SetActive(true);
        }

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

    public void LoadPrologue()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Prologue");
    }

    public void LoadEpilogue()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Epilogue"); 
    }
}
