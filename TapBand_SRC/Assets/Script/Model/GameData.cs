using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

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
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameStateHolder>().gameData;
            }
            return _instance;
        }
    }
    #endregion

    private List<SongData> songDataList;
    private List<ConcertData> concertDataList;
    private List<TourData> tourDataList;
    private List<EquipmentData> equipmentDataList;
    private List<MerchData> merchDataList;
    private List<GeneralData> generalDataList;

    public List<SongData> SongDataList
    {
        get
        {
            return songDataList;
        }

        set
        {
            songDataList = value;
        }
    }

    public List<ConcertData> ConcertDataList
    {
        get
        {
            return concertDataList;
        }

        set
        {
            concertDataList = value;
        }
    }

    public List<TourData> TourDataList
    {
        get
        {
            return tourDataList;
        }

        set
        {
            tourDataList = value;
        }
    }

    public List<EquipmentData> EquipmentDataList
    {
        get
        {
            return equipmentDataList;
        }

        set
        {
            equipmentDataList = value;
        }
    }

    public List<MerchData> MerchDataList
    {
        get
        {
            return merchDataList;
        }

        set
        {
            merchDataList = value;
        }
    }

    public List<GeneralData> GeneralDataList
    {
        get
        {
            return generalDataList;
        }

        set
        {
            generalDataList = value;
        }
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

        this.songDataList = gd.songDataList;
        this.concertDataList = gd.concertDataList;
        this.tourDataList = gd.tourDataList;
        this.merchDataList = gd.merchDataList;
        this.equipmentDataList = gd.equipmentDataList;
        this.generalDataList = gd.generalDataList;
    }

    private byte[] byteArray;

    private IEnumerator GetByteArray(string dataPath)
    {
        WWW www = new WWW(dataPath);
        while (!www.isDone)
        {
            yield return null;
        }

        byteArray = www.bytes;
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