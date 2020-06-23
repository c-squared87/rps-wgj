using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float SpeedMultiplier = 3.5f;

    GameObject[] activeOnGameOver;

    void Start()
    {
        InitGame();
    }

    void InitGame()
    {
        Time.timeScale = 1;

        activeOnGameOver = GameObject.FindGameObjectsWithTag("ActiveOnGameOver");

        foreach (GameObject _object in activeOnGameOver)
        {
            _object.SetActive(false);
        }

        EventsManager.LevelStart();

        StartCoroutine("LevelUp");
    }

    void EndGame()
    {
        Time.timeScale = 0;

        foreach (GameObject _object in activeOnGameOver)
        {
            _object.SetActive(true);
        }
    }

    // CALLED FROM ELSEWHERES.
    public void LoadNewGame()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator LevelUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(14);
            Time.timeScale += 0.1f;
        }
    }
}
