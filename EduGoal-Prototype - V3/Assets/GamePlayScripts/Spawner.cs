// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    public GameObject prefab;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),SpawnRate,SpawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject Obstacles = Instantiate(prefab, transform.position, Quaternion.identity);
        Obstacles.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
