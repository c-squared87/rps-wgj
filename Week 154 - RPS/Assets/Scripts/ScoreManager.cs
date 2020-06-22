public static class ScoreManager
{
    static int currentScore;

    public static void AddToScore(int _amountToAdd){
        currentScore += _amountToAdd;
        EventsManager.ScoreChanged(currentScore);
    }
}
