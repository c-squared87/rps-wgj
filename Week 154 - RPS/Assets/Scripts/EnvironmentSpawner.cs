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

    private void StartPlaneSpawn(float _value)
    {
        if (_value <= 400) return;
        // StopCoroutine("SpawnPlanes");
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
        Instantiate(airplanePrefabs[0], transform.position + new Vector3(0, 2.2f, 0), Quaternion.identity);

        while (true)
        {
            float _randHeight =  UnityEngine.Random.Range(0.1f, 2.4f);
            Debug.Log(_randHeight + " random height");
            float _rand = UnityEngine.Random.Range(4f, 7f);

            yield return new WaitForSeconds(_rand);

            Instantiate(airplanePrefabs[0], transform.position + new Vector3(0, _randHeight, 0), Quaternion.identity);
        }
    }

}
