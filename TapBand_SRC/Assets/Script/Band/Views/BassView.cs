using UnityEngine;
using System.Collections;
using System;

public class BassView : BandMemberView
{
    private BassController bassController;

    void Start()
    {
        bassController = (BassController)FindObjectOfType(typeof(BassController));
    }

    protected override void TapEventTrigger()
    {
        bassController.TapEventOnBandMember();
    }

}
