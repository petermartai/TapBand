using UnityEngine;
using System.Collections;

public class TapBandRoot : MonoBehaviour {

    public TapBandModel model;
    public TapBandView view;
    public TapBandController controller;
    
    void Start()
    {
        Screen.SetResolution(600, 900, false);
    }

}
