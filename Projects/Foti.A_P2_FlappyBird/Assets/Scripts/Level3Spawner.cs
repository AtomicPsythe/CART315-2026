using System.Collections;
using UnityEngine;

public class Level3FlowerSpawner : MonoBehaviour
{
    // array for the tulip and sunflower prefabs to be used
    public GameObject[] flowerPrefabs; 

    // spawner timing
    public float minSpawnRate = 1.5f;
    public float maxSpawnRate = 3f;

    [SerializeField] private float clearBufferTime = 1f; 

    // when the spawner(s) stop spawning flowers before the leaf platform appears
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
            if (flowerPrefabs != null && flowerPrefabs.Length > 0)
            {
                // picks one flower at a time to spawn
                int randomIndex = Random.Range(0, flowerPrefabs.Length);
                GameObject selectedFlowerPrefab = flowerPrefabs[randomIndex];

                Instantiate(
                    selectedFlowerPrefab,
                    transform.position,
                    Quaternion.identity
                );
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
