using UnityEngine;
using System.Collections;

public class SongLoadController : MonoBehaviour {

    private float timePassed = 0.0f;

	void Start () {
	
	}

    void Update () {
        timePassed += Time.deltaTime;

        if (timePassed > GameState.instance.songLengthInSeconds)
        {
            timePassed = 0.0f;
            GameState.instance.resetTaps();
        }

        GameState.instance.passedTimeInSeconds = (int) timePassed;
	}
}
