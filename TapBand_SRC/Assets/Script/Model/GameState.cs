using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameState {

    public long mood;
    public int passedTimeInSeconds;

    public long money;
    public long numberOfFans;


    #region Singleton access
    private static GameState _instance;
    public static GameState instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameStateHolder>().gameState;
            }
            return _instance;
        }
    }
    #endregion
}
