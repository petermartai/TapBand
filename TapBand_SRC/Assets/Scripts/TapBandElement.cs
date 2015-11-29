using UnityEngine;
using System.Collections;

public class TapBandElement : MonoBehaviour {

    public TapBandRoot app {
        get {
            return GameObject.FindObjectOfType<TapBandRoot>();
        }
    }
}
