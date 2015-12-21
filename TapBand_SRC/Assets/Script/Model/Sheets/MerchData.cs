using UnityEngine;
using System.Collections.Generic;

public enum MerchType
{
    MERCH, ITUNES, SPOTIFY, ALBUM
}

[System.Serializable]
public class MerchData
{
	public int id;
	public MerchType merchType;
    public int level;
    public int coinPerSecond;
    public int upgradeCost;
    public int capacity;
}
