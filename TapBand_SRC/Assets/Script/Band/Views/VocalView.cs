using UnityEngine;
using System.Collections;
using System;

public class VocalView : BandMemberView {

    private VocalController vocalController;

    void Start()
    {
        vocalController = (VocalController)FindObjectOfType(typeof(VocalController));
    }

    protected override void TapEventTrigger()
    {
        vocalController.TapEventOnBandMember();
    }

}
