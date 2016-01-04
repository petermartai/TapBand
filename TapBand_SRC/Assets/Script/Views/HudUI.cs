using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudUI : MonoBehaviour {

    public float heightOfBar = 25f;
    public float startingVerticalPos = 60f;

    public delegate void NewTourEvent();
    public event NewTourEvent NewTour;

    public delegate void NewCoinEvent();
    public event NewCoinEvent NewCoin;

    public delegate void NewFansEvent();
    public event NewFansEvent NewFans;

    public GameObject coin;
    public GameObject fan;
    public GameObject tour;
    
    void Start () {
        coin = GameObject.Find("CoinText");
        fan = GameObject.Find("FanText");
        tour = GameObject.Find("TourText");
    }
	
    void OnGUI()
    {
        if (NewTour != null) {
            NewTour();
        }
        if (NewCoin != null)
        {
            NewCoin();
        }
        if (NewFans != null)
        {
            NewFans();
        }
        
        
        // TODO : finish for all the UI elements

        GUI.color = Color.yellow;
        GUI.Box(
            new Rect(
                Screen.width / 4,
                startingVerticalPos,
                //GameState.instance.tapDuringSong * 5 + 50f,
                60f,
                heightOfBar), "Force");

        GUI.color = Color.red;
        GUI.Box(
            new Rect(
                Screen.width / 4,
                startingVerticalPos + heightOfBar + 5f,
                //GameState.instance.passedTimeInSeconds * 5 + 50f,
                60f,
                heightOfBar), "Time: ");

    }
}
