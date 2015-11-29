using UnityEngine;
using System.Collections;

public abstract class BandMemberController : TapBandElement {

    public abstract void TapEventOnBandMember(BandMemberView member);
}
