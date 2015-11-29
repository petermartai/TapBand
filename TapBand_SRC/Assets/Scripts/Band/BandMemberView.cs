using UnityEngine;
using System.Collections;

public abstract class BandMemberView : TapBandElement {

    void OnCollisionEnter() { // find the correct event
        
    }

    protected abstract void TapEventTrigger();
}
