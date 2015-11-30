using UnityEngine;
using System.Collections;

public abstract class BandMemberController : TapBandElement {

    public void TapEventOnBandMember()
    {
        app.model.gameModel.money++;
        app.view.goldScore.text = "Gold: " + app.model.gameModel.money;
    }
}
