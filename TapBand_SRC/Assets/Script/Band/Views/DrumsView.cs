using UnityEngine;
using System.Collections;

public class DrumsView : BandMemberView {

    protected override void TapEventTrigger()
    {
        app.controller.drums.TapEventOnBandMember();
    }

}
