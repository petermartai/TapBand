using UnityEngine;
using System.Collections;

[System.Serializable]
public class TourState {

    private int currentTourID;

    public int CurrentTourID
    {
        get
        {
            return currentTourID;
        }
        set
        {
            currentTourID = value;
        }
    }

    public TourData CurrentTour
    {
        get
        {
            return GameData.instance.TourDataList.Find(x => x.id == currentTourID);
        }
    }
}
