using UnityEngine;
using System.Collections;

public class SongLoadController : MonoBehaviour {

    private float timePassed = 0.0f;

    private AudioSource source1;
    private AudioSource source2;

    private bool oddPlay;

	void Start () {
        oddPlay = false;

        AudioSource[] sounds = GetComponents<AudioSource>();
        source1 = sounds[0];
        source2 = sounds[1];
    }

    void Update () {
        timePassed += Time.deltaTime;

        if (timePassed > GameState.instance.songLengthInSeconds)
        {
            timePassed = 0.0f;
            GameState.instance.resetTaps();
            oddPlay = !oddPlay;

            if (oddPlay)
            {
                source1.Stop();
                source2.Play();
            } else
            {
                source2.Stop();
                source1.Play();
            }
        }

        GameState.instance.passedTimeInSeconds = (int) timePassed;
	}
}
