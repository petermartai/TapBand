using UnityEngine;
using System.Collections;

public class GameStateHolder : MonoBehaviour
{
    public GameData gameData;
    public GameState gameState;

    void Awake()
    {
        gameData = new GameData();
        // gameData.TryLoadFromStreamingAssets();
        gameState = new GameState();
        // gameState.TryLoadFromStreamingAssets();
    }
}