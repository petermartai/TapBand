using UnityEngine;
using System.Collections;
using System;

public class BassView : BandMemberView
{
    protected override void TapEventTrigger()
    {
        app.controller.bass.TapEventOnBandMember();
    }

}
