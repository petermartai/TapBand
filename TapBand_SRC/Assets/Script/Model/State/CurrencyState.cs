using UnityEngine;
using System.Collections;

[System.Serializable]
public class CurrencyState
{
    private int numberOfFans;
    private int numberOfCoins;

    public int NumberOfFans
    {
        get
        {
            return numberOfFans;
        }

        set
        {
            numberOfFans = value;
        }
    }

    public int NumberOfCoins
    {
        get
        {
            return numberOfCoins;
        }

        set
        {
            numberOfCoins = value;
        }
    }
}
