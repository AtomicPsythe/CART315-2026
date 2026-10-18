using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    // variables to make sure the flowers being spawned don't overlap
    public float globalSpawnCooldown = 1.0f;
    private float lastSpawnTime = -999f;

    private void Awake()
    {
        Instance = this;
    }

    public bool CanSpawn()
    {
        if (Time.time - lastSpawnTime >= globalSpawnCooldown)
        {
            lastSpawnTime = Time.time;
            return true;
        }
        return false;
    }
}
