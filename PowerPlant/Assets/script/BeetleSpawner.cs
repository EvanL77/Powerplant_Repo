using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 9f;
    [SerializeField] private float minSpawnRate = 5f;
    [SerializeField] private int maxBeetles = 3; // Max number of Beetles
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;

    private int currentBeetles = 0;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(spawnRate);

            // Check if the current number of spiders is below the maximum
            if (currentBeetles < maxBeetles)
            {
                int rand = Random.Range(0, enemyPrefabs.Length);
                GameObject enemyToSpawn = enemyPrefabs[rand];
                GameObject spawnedEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

                // Increment the counter and add a destroy event to decrement it
                currentBeetles++;
                spawnedEnemy.GetComponent<Beetle>().OnDestroyed += () => currentBeetles--;

                // Adjust spawn rate
                spawnRate = Mathf.Max(spawnRate - 1f, minSpawnRate);
            }
        }
    }
}