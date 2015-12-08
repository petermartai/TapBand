using UnityEngine;
using System.Collections;

public class DrumsView : BandMemberView {

    private DrumsController drumsController;

    void Start()
    {
        drumsController = (DrumsController)FindObjectOfType(typeof(DrumsController));
    }

    protected override void TapEventTrigger()
    {
        drumsController.TapEventOnBandMember();
    }

}
