using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class GameData
{
	public const string GAME_DATA_PATH = "gamedata";

	#region Singleton access
	private static GameData _instance;
	public static GameData instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<GameDataHolder>().gameData;
			}
			return _instance;
		}
	}
	#endregion
	
	public List<ExampleData> exampleDatas { get { return _exampleDatas; } }
	private List<ExampleData> _exampleDatas;

	public void LoadWithLoader(IGameDataLoader gameDataLoader)
	{
		_exampleDatas = gameDataLoader.LoadExampleDatas();
	}

	public void TryLoadFromStreamingAssets()
	{
		IFormatter formatter = new BinaryFormatter();
		
		string gameDataPath = "Data/" + GAME_DATA_PATH;
		gameDataPath = System.IO.Path.Combine(Application.streamingAssetsPath, gameDataPath);
		
		// Load GameData byte[]
		#if UNITY_ANDROID && !UNITY_EDITOR
		IEnumerator a = GetByteArray(gameDataPath);
		while (a.MoveNext()) {}

		#else
		byteArray = File.ReadAllBytes(gameDataPath);

		#endif
		
		// Load GameState	
		MemoryStream ms = new MemoryStream(byteArray);
		GameData gd = (GameData)formatter.Deserialize(ms);
		
		SetGameData(gd);
	}

	private byte[] byteArray;

	private IEnumerator GetByteArray(string dataPath)
	{
		WWW www = new WWW(dataPath);
		while(!www.isDone)
		{
			yield return null;
		}

		byteArray = www.bytes;
	}
	
	private void SetGameData(GameData gd)
	{
		_exampleDatas = gd.exampleDatas;
	}

	public void SaveToFile(string filePath)
	{		
		BinaryFormatter bf = new BinaryFormatter();

		// Get GameState byte[]
		MemoryStream ms = new MemoryStream();
		bf.Serialize(ms, this);
		byte[] normalByteArray = ms.ToArray();
		
		// Save to file
		File.WriteAllBytes(filePath, normalByteArray);
	}
}
