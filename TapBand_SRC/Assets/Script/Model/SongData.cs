using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SongData
{
	public int id;
	public string name;

    [System.Serializable]
    public class LevelData
    {
        public BigInteger coin;
        public BigInteger upgradeCost;
    }

    public List<LevelData> levelDatas;

    public SongData(int edId)
	{
		id = edId;
	}
}
