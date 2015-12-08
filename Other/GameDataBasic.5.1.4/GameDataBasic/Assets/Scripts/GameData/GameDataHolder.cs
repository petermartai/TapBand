using UnityEngine;

public class GameDataHolder : MonoBehaviour
{
	public GameData gameData;

	void Awake()
	{
		gameData = new GameData();
		gameData.TryLoadFromStreamingAssets();
	}
}
