using System;
using System.Collections;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] groundPrefabs;
    [SerializeField] GameObject[] rockPrefabs;
    [SerializeField] GameObject[] airplanePrefabs;

    void Start()
    {
        // Time.timeScale = 4;
        // StartRockSpawn();
        // StartPlaneSpawn(1);
    }

    void OnEnable()
    {
        EventsManager.ADD_OnLevelStartListener(StartRockSpawn);
        EventsManager.ADD_OnScoreChangedListener(StartPlaneSpawn);
        // EventsManager.ADD_GameEndListener(StopSpawners);
    }

    void OnDisable()
    {
        EventsManager.REMOVE_OnLevelStartListener(StartRockSpawn);
        // EventsManager.REMOVE_GameEndListener(StopSpawners);
    }

    // private void StopSpawners()
    // {
    //     StopCoroutine("SpawnPlanes");
    //     StopCoroutine("SpawnRocks");
    // }

    private void StartPlaneSpawn(int _value)
    {
        if (_value <= 1500) return;
        StopCoroutine("SpawnPlanes");
        StartCoroutine("SpawnPlanes");
        EventsManager.REMOVE_OnScoreChangedListener(StartPlaneSpawn);
    }

    private void StartRockSpawn()
    {
        StopCoroutine("SpawnRocks");
        StartCoroutine("SpawnRocks");
    }

    public void SpawnGround(Vector2 _position)
    {
        Instantiate(groundPrefabs[0], _position, Quaternion.identity);
    }

    IEnumerator SpawnRocks()
    {
        while (true)
        {
            float _rand = UnityEngine.Random.Range(1f, 4f);

            yield return new WaitForSeconds(_rand);

            Instantiate(rockPrefabs[0], transform.position, Quaternion.identity);
        }
    }
    IEnumerator SpawnPlanes()
    {
        while (true)
        {
            float _rand = UnityEngine.Random.Range(2f, 5f);

            yield return new WaitForSeconds(_rand);

            Instantiate(airplanePrefabs[0], transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        }
    }

}
