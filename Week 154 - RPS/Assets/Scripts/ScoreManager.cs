public static class ScoreManager
{
    public static int CurrentScore;

    public static void AddToScore(int _amountToAdd){
        CurrentScore += _amountToAdd;
        EventsManager.ScoreChanged(CurrentScore);
    }
}
