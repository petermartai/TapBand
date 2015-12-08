using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

[ExecuteInEditMode]
public class GameDataTools : EditorWindow 
{
	private const string dataRawPath = "Assets/Data/";
	private const string gameDataDirectory = "Assets/StreamingAssets/Data/";

	private string sourceURL;
	private string gameDataDownloadFileName;
	private string gameDataConvertFileName;
	private static byte[] fileAsBinary;

	[MenuItem ("PGI/GameData Tools")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(GameDataTools));
	}

	void OnEnable()
	{
		RestoreDefaultValues ();
	}
		
	void OnGUI()
	{
		RestoreDefaultValuesGUI();

		EditorGUILayout.Space();

		DownloadGameDataGUI();
		
		EditorGUILayout.Space();

		ConvertToResourceFileGUI();

		EditorGUILayout.Space();
		GUILayout.Label ("Warning: values reset to defaults if window is closed!");
	}

	private void RestoreDefaultValuesGUI()
	{		
		if (GUILayout.Button("Restore default values"))
		{
			RestoreDefaultValues();
		}
	}
	
	private void RestoreDefaultValues()
	{
		sourceURL = @"Insert source URL here";
		gameDataDownloadFileName = "GameData.xlsx";
		gameDataConvertFileName = "GameData.xlsx";
	}

	private void DownloadGameDataGUI()
	{
		GUILayout.Label ("Download GameData", EditorStyles.boldLabel);
		
		sourceURL = EditorGUILayout.TextField("Remote URL", sourceURL);
		gameDataDownloadFileName = EditorGUILayout.TextField("Local filename", gameDataDownloadFileName);
		
		if (GUILayout.Button("Download"))
		{
			Debug.LogError("Implement GameData download!");
		}
	}

	private void ConvertToResourceFileGUI()
	{		
		GUILayout.Label ("Convert to resource file", EditorStyles.boldLabel);
		gameDataConvertFileName = EditorGUILayout.TextField("Convert from", gameDataConvertFileName);
		
		if (GUILayout.Button("Convert"))
		{
			EditorUtility.DisplayProgressBar("Please wait", "Loading and converting game data...", 0.2f);

			GameData gameData = new GameData();

			try
			{
				IGameDataLoader rawGameDataLoader  = 
					new RawGameDataLoader(dataRawPath + gameDataConvertFileName);
				//gameData.LoadWithLoader(rawGameDataLoader);
			}
			catch(System.Exception e)
			{
				Debug.LogError("Exception during loading: " + e.Message + ". StackTrace: " + e.StackTrace);
				EditorUtility.ClearProgressBar();
				return;
			}

			EditorUtility.DisplayProgressBar("Please wait", "Loading and converting game data...", 0.8f);

			if(!Directory.Exists(gameDataDirectory))
			{
				Directory.CreateDirectory(gameDataDirectory);
			}

			// Have to save to .txt because Unity can't read anything from resources folder
			string savePath = gameDataDirectory + GameData.GAME_DATA_PATH;

			try
			{
				//gameData.SaveToFile(savePath);
			}
			catch(System.Exception e)
			{
				Debug.LogError("Exception during writing binary file. Please restart Unity and run Convert again! Details: " + e.Message + ". StackTrace: " + e.StackTrace);
				EditorUtility.ClearProgressBar();
				return;
			}
			AssetDatabase.Refresh();

			EditorUtility.ClearProgressBar();
			Debug.Log("GameData converted to " + savePath + ".TimeStamp: " + System.DateTime.Now.ToLongTimeString());
		}
	}

	private IEnumerator LoadGameDataWithLoader()
	{
		return null;
	}
}	
