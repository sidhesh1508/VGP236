using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pickupPrefab = null;
    [SerializeField]
    private Transform minSpawArea = null;
    [SerializeField]
    private Transform maxSpawnArea = null;
    [SerializeField]
    private float minSpawnRate = 1.0f;
    [SerializeField]
    private float maxSpawnRate = 10.0f;
    private float nextSpawnTime = 0.0f;

    private void Awake()
    {
        nextSpawnTime = 5.0f;
    }


    // Update is called once per frame
    void Update()


    {
        nextSpawnTime -= Time.deltaTime;
        if (nextSpawnTime < 0.0f)
        {
            SpawnPickup();
            nextSpawnTime = Random.Range(minSpawnRate, maxSpawnRate);
        }
    }
    private void SpawnPickup()
    {
        Vector3 spawnPosition = Vector3.zero;
        spawnPosition.x = Random.Range(minSpawArea.position.x, maxSpawnArea.position.x);
        spawnPosition.y = Random.Range(minSpawArea.position.y, maxSpawnArea.position.y);
        spawnPosition.z = minSpawArea.position.z;
        Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
    }
    
}