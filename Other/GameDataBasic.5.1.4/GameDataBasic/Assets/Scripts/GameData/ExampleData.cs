using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ExampleData
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

	public ExampleData(int edId)
	{
		id = edId;
	}
}
