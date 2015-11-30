using UnityEngine;
using System.Collections;

public class GuitarView : BandMemberView {

    protected override void TapEventTrigger()
    {
        app.controller.guitar.TapEventOnBandMember();
    }

}
