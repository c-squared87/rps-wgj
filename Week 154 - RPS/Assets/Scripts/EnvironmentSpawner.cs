using System;
using System.Collections;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{

    [SerializeField] Transform rockSpawnPoint;
    [SerializeField] Transform airplaneSpawnPoint;

    [SerializeField] GameObject[] groundPrefabs;
    [SerializeField] GameObject[] rockPrefabs;
    [SerializeField] GameObject[] airplanePrefabs;

    void Start()
    {
        StartCoroutine(SpawnRocks());
        StartCoroutine(SpawnPlanes());
    }

    void OnEnable()
    {
        EventsManager.ADD_OnLevelStartListener(StartRockSpawn);
        EventsManager.ADD_OnScoreChangedListener(StartPlaneSpawn);
        EventsManager.ADD_GameEndListener(StopSpawners);
    }

    void OnDisable()
    {
        EventsManager.REMOVE_OnLevelStartListener(StartRockSpawn);
        EventsManager.REMOVE_OnScoreChangedListener(StartPlaneSpawn);
        EventsManager.REMOVE_GameEndListener(StopSpawners);
    }

    private void StopSpawners()
    {
        //TODO: SHOULD WE STOP ALL OR CALL THEM INDIVIDUALLY.
        StopAllCoroutines();
    }

    private void StartPlaneSpawn(int _value)
    {
        if (_value < 100) return;
        StartCoroutine(SpawnPlanes());
        EventsManager.REMOVE_OnScoreChangedListener(StartPlaneSpawn);
    }

    private void StartRockSpawn()
    {
        StartCoroutine(SpawnRocks());
    }

    public void SpawnGround(Vector2 _position)
    {
        Instantiate(groundPrefabs[0], _position, Quaternion.identity);
    }

    IEnumerator SpawnRocks()
    {
        while (true)
        {
            float _rand = UnityEngine.Random.Range(0.25f, 2f);

            yield return new WaitForSeconds(_rand);

            Instantiate(rockPrefabs[0], transform.position, Quaternion.identity);
        }
    }
    IEnumerator SpawnPlanes()
    {
        while (true)
        {
            float _rand = UnityEngine.Random.Range(0.25f, 2f);

            yield return new WaitForSeconds(_rand);

            Instantiate(airplanePrefabs[0], transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        }
    }

}
