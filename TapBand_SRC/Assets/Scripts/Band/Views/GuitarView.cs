using UnityEngine;
using System.Collections;

public class GuitarView : BandMemberView {

    protected override void TapEventTrigger()
    {
        app.controller.guitar.TapEventOnBandMember(this);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
