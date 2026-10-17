using System.Collections;
using UnityEngine;

public class TulipSpawner : MonoBehaviour
{
    public Tulip prefab;

    public float minSpawnRate = 1.5f;
    public float maxSpawnRate = 3f;

    // amount of time before the flowers stop spawning in relation to the background
    [SerializeField] private float clearBufferTime = 1f; 

    // stopping 2 seconds earlier so that there are no flowers near the end platform
    public float stopSpawningAfterSeconds = 11f;

    private Parallax parallaxReference;
    private Coroutine spawnCoroutine;

    private float timer = 0f;
    private bool isSpawnerActive = true;

    private void Awake()
    {
        parallaxReference = FindFirstObjectByType<Parallax>();
        CalculateSpawnDuration();
    }

    private void OnEnable()
    {
        ResetSpawner();
    }

    private void OnDisable()
    {
        StopSpawnLoop();
    }

    private void CalculateSpawnDuration()
    {
        if (parallaxReference != null)
        {
            stopSpawningAfterSeconds = parallaxReference.scrollDuration - clearBufferTime;
        }
        else
        {
            stopSpawningAfterSeconds = 11f; 
        }
    }

    private void Update()
    {
        if (!isSpawnerActive) return;

        timer += Time.deltaTime;
        if (timer >= stopSpawningAfterSeconds)
        {
            StopSpawnLoop();
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (isSpawnerActive)
        {
            Instantiate(
                prefab,
                transform.position,
                Quaternion.identity
            );

            float nextSpawnTime = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(nextSpawnTime);
        }
    }

    private void StopSpawnLoop()
    {
        isSpawnerActive = false;
        
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    public void ResetSpawner()
    {
        StopSpawnLoop();
        CalculateSpawnDuration();
        timer = 0f;
        isSpawnerActive = true;
        gameObject.SetActive(true);
        spawnCoroutine = StartCoroutine(SpawnLoop());
    }
}
