using UnityEngine;
using System.Collections;

public class DrumsView : BandMemberView {

    protected override void TapEventTrigger()
    {
        app.controller.drums.TapEventOnBandMember(this);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
