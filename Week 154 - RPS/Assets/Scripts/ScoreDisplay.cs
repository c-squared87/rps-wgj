using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text text;

    void OnEnable()
    {
        EventsManager.ADD_OnScoreChangedListener(UpdateUI);
        UpdateUI(0);
    }

    void OnDisable()
    {
        EventsManager.REMOVE_OnScoreChangedListener(UpdateUI);
    }

    private void UpdateUI(int _value)
    {
        if (text == null) text = GetComponent<Text>();
        text.text = "score: " + _value.ToString();
    }
}
