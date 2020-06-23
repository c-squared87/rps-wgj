using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float SpeedMultiplier = 3.6f;

    GameObject[] activeOnGameOver;

    void Start()
    {
        InitGame();
    }

    void OnEnable()
    {
        EventsManager.ADD_GameEndListener(EndGame);
    }

    void OnDisable()
    {
        EventsManager.REMOVE_GameEndListener(EndGame);
    }

    void InitGame()
    {
        ScoreManager.CurrentScore = 0;
        Time.timeScale = 1;
        activeOnGameOver = GameObject.FindGameObjectsWithTag("ActiveOnGameOver");
        foreach (GameObject _object in activeOnGameOver) { _object.SetActive(false); }
        EventsManager.LevelStart();
        StartCoroutine("LevelUp");
    }

    void EndGame()
    {
        Time.timeScale = 0;

        // GameObject.Find("FinalScoreDisplay").GetComponent<Text>().text = "SCORE : " + ScoreManager.CurrentScore.ToString();

        var _hide = GameObject.FindGameObjectsWithTag("HideOnGameOver");
        foreach (GameObject _object in _hide) { _object.SetActive(false); }
        foreach (GameObject _object in activeOnGameOver) { _object.SetActive(true); }
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
