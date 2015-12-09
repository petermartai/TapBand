using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

    public float heightOfBar = 25f;
    public float startingVerticalPos = 60f; 

    void Start()
    {
    }

    void OnGUI()
    {
        GUI.color = Color.yellow;
        GUI.Box(
            new Rect(
                Screen.width/4,
                startingVerticalPos, 
                GameState.instance.tapDuringSong * 5 + 50f,
                heightOfBar), "Force");

        GUI.color = Color.red;
        GUI.Box(
            new Rect(
                Screen.width / 4,
                startingVerticalPos + heightOfBar + 5f,
                GameState.instance.passedTimeInSeconds * 5 + 50f,
                heightOfBar), "Time: " + (GameState.instance.passedTimeInSeconds + 1));
        
    }




}
