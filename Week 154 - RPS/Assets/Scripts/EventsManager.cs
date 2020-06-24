using UnityEngine;

public static class EventsManager
{

    /*
    INDEX

    OnGameEnd
    OnMessageBroadcast
    OnScoreChanged
    OnLevelStart

    */

    #region EndGame

    public delegate void OnGameEnd();
    static event OnGameEnd onGameEnd;

    public static void ADD_GameEndListener(EventsManager.OnGameEnd _method)
    {
        onGameEnd += _method;
    }
    public static void REMOVE_GameEndListener(EventsManager.OnGameEnd _method)
    {
        onGameEnd -= _method;
    }

    public static void EndGame()
    {
        // Debug.Log("Game End Called");
        if (onGameEnd != null)
            onGameEnd();
    }

    #endregion

    #region BroadcastMessage

    public delegate void OnMessageBroadcast(string _message);
    static event OnMessageBroadcast onMessageBroadcast;

    public static void ADD_OnMessageBroadcastListener(EventsManager.OnMessageBroadcast _method)
    {
        onMessageBroadcast += _method;
    }
    public static void REMOVE_OnMessageBroadcastListener(EventsManager.OnMessageBroadcast _method)
    {
        onMessageBroadcast -= _method;
    }

    public static void BroadcastMessage(string _message)
    {
        if (onMessageBroadcast != null)
            onMessageBroadcast(_message);
    }

    #endregion

    #region Score Changed

    public delegate void OnScoreChanged(float _value);
    static event OnScoreChanged onScoreChanged;

    public static void ADD_OnScoreChangedListener(EventsManager.OnScoreChanged _method)
    {
        onScoreChanged += _method;
    }
    public static void REMOVE_OnScoreChangedListener(EventsManager.OnScoreChanged _method)
    {
        onScoreChanged -= _method;
    }

    public static void ScoreChanged(float _value)
    {
        if (onScoreChanged != null)
            onScoreChanged(_value);
    }

    #endregion

    #region LevelStart

    public delegate void OnLevelStart();
    static event OnLevelStart onLevelStart;

    public static void ADD_OnLevelStartListener(EventsManager.OnLevelStart _method)
    {
        onLevelStart += _method;
    }
    public static void REMOVE_OnLevelStartListener(EventsManager.OnLevelStart _method)
    {
        onLevelStart -= _method;
    }

    public static void LevelStart()
    {
        if (onLevelStart != null)
            onLevelStart();
    }

    #endregion
}