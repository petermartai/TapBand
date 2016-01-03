using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameState {

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

    public int songLengthInSeconds = 20;
    public int passedTimeInSeconds;

    public long money;
    private long _numberOfFans;

    public long numberOfFans
    {
        get
        {
            return _numberOfFans;
        }
    }

    private int _tapDuringSong;

    public int tapDuringSong
    {
        get
        {
            return _tapDuringSong;
        }
    }

    public void increaseTapAndNumberOfFans()
    {
        _tapDuringSong++;
        _numberOfFans++;
    }

    public void resetTaps()
    {
        _tapDuringSong = 0;
    }


}
