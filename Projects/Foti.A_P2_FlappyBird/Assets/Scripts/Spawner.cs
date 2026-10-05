using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Sunflower prefab;

    public float minSpawnRate = 1.5f;
    public float maxSpawnRate = 3f;

    private void OnEnable()
    {
        Spawn();
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        Instantiate(
            prefab,
            transform.position,
            Quaternion.identity
        );

        float nextSpawnTime = Random.Range(minSpawnRate, maxSpawnRate);

        Invoke(nameof(Spawn), nextSpawnTime);
    }
}