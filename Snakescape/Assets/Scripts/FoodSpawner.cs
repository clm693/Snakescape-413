using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;

    void Start()
    {
        SpawnFood();
    }

    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            0.5f,
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }
}