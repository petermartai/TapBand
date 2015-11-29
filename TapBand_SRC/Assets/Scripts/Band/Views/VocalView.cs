using UnityEngine;
using System.Collections;
using System;

public class VocalView : BandMemberView {

    protected override void TapEventTrigger()
    {
        app.controller.vocal.TapEventOnBandMember(this);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
