using UnityEngine;
using System.Collections;

public class GuitarView : BandMemberView {

    private GuitarController guitarController;

    void Start()
    {
        guitarController = (GuitarController)FindObjectOfType(typeof(GuitarController));
    }

    protected override void TapEventTrigger()
    {
        guitarController.TapEventOnBandMember();
    }
}
