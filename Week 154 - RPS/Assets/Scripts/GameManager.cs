using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float SpeedMultiplier = 3.5f;

    void Start()
    {
        Time.timeScale = 1;
        EventsManager.LevelStart();
        StartCoroutine("LevelUp");        
    }



    IEnumerator LevelUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(14);
            Time.timeScale += 0.2f;
        }
    }
}
