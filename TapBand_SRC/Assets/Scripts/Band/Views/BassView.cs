using UnityEngine;
using System.Collections;
using System;

public class BassView : BandMemberView
{
    protected override void TapEventTrigger()
    {
        app.controller.bass.TapEventOnBandMember(this);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
