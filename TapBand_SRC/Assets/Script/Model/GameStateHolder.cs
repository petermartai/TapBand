using UnityEngine;
using System.Collections;

public class GameStateHolder : MonoBehaviour
{
    public GameData gameData;
    public GameState gameState;

    void Awake()
    {
        GameData.instance.TryLoadFromAssets(Application.streamingAssetsPath);
        GameState.instance.TryLoadFromAssets(Application.persistentDataPath);

        LoadDefaults();
    }

    void OnDestroy()
    {
        GameState.instance.SaveToFile(Application.persistentDataPath);
    }

    private void LoadDefaults()
    {
        if (GameState.instance.Tour.CurrentTourID == 0)
        {
            TourData firstTour = GameData.instance.TourDataList[0];
            GameState.instance.Tour.CurrentTourID = firstTour.id;
        }
    }
}