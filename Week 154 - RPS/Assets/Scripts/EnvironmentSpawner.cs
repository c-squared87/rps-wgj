﻿using System;
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
        StartSpawners();
    }

    // void OnEnable()
    // {
    //     EventsManager.ADD_OnLevelStartListener(StartSpawners);
    //     EventsManager.ADD_GameEndListener(StopSpawners);
    // }

    // void OnDisable()
    // {
    //     EventsManager.REMOVE_OnLevelStartListener(StartSpawners);
    //     EventsManager.REMOVE_GameEndListener(StopSpawners);
    // }

    private void StopSpawners()
    {
        //TODO: SHOULD WE STOP ALL OR CALL THEM INDIVIDUALLY.
        StopAllCoroutines();
    }

    private void StartSpawners()
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

}
