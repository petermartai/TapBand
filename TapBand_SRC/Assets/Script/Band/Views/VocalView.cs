using UnityEngine;
using System.Collections;
using System;

public class VocalView : BandMemberView {

    protected override void TapEventTrigger()
    {
        app.controller.vocal.TapEventOnBandMember();
    }

}
