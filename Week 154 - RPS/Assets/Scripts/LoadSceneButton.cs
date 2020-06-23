using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadSceneButton : MonoBehaviour
{
    Button button;
    [SerializeField] string sceneToLoad;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadAScene);
    }

    private void LoadAScene()
    {
        // if (gameObject.name == "QuitButton") { Application.Quit; }
        SceneManager.LoadScene(sceneToLoad);
    }
}
