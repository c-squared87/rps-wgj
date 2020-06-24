using UnityEngine;

public static class ScoreManager
{
    public static float CurrentScore;

    public static void AddToScore(float _amountToAdd){
        CurrentScore += _amountToAdd;
        EventsManager.ScoreChanged(Mathf.Round(CurrentScore));
    }
}
