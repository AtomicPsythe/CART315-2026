using System.Collections;
using UnityEngine;

public class Level3Spawner : MonoBehaviour
{
    // array for the tulip and sunflower prefabs to be used
    [SerializeField] private Flower[] flowerPrefabs;

    // spawner timing
    public float minSpawnRate = 0.6f;
    public float maxSpawnRate = 1.2f;

    // when the spawner stops spawning flowers before the leaf platform appears
    public float stopSpawningAfterSeconds = 10f;

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
            stopSpawningAfterSeconds = 11.5f;
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
            // checks the spawner manager before doing anything
            if (SpawnManager.Instance != null && SpawnManager.Instance.CanSpawn())
            {
                // makes sure the prefabs are assigned in the inspector when playing the game (since they would dissapear sometimes during playtesting)
                if (flowerPrefabs != null && flowerPrefabs.Length > 0)
                {
                    // chooses one of the two flowers from the array of prefabs to spawn at a time
                    int randomIndex = Random.Range(0, flowerPrefabs.Length);
                    Flower selectedFlowerPrefab = flowerPrefabs[randomIndex];

                    Instantiate(
                        selectedFlowerPrefab,
                        transform.position,
                        Quaternion.identity
                    );
                }
            }

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
