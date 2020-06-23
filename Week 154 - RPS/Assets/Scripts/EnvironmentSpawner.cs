using System;
using System.Collections;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] groundPrefabs;
    [SerializeField] GameObject[] rockPrefabs;
    [SerializeField] GameObject[] airplanePrefabs;

    void OnEnable()
    {
        EventsManager.ADD_OnLevelStartListener(StartRockSpawn);
        EventsManager.ADD_OnScoreChangedListener(StartPlaneSpawn);
    }

    void OnDisable()
    {
        EventsManager.REMOVE_OnLevelStartListener(StartRockSpawn);
    }

    private void StartPlaneSpawn(int _value)
    {
        if (_value <= 1000) return;
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
        int _randObj = UnityEngine.Random.Range(0, groundPrefabs.Length);
        Instantiate(groundPrefabs[_randObj], _position, Quaternion.identity);
    }

    IEnumerator SpawnRocks()
    {
        while (true)
        {
            int _randObj = UnityEngine.Random.Range(0, rockPrefabs.Length);
            float _rand = UnityEngine.Random.Range(1f, 4f);

            yield return new WaitForSeconds(_rand);

            Instantiate(rockPrefabs[_randObj], transform.position, Quaternion.identity);
        }
    }
    IEnumerator SpawnPlanes()
    {
        while (true)
        {
            float _rand = UnityEngine.Random.Range(4f, 7f);

            yield return new WaitForSeconds(_rand);

            Instantiate(airplanePrefabs[0], transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        }
    }

}
