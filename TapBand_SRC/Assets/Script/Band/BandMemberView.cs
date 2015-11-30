using UnityEngine;
using System.Collections;

public abstract class BandMemberView : TapBandElement {

    private float shakeY;
    private float shakeYSpeed = 0.8f;

    void OnMouseDown()
    {
        TapEventTrigger();
        if (shakeY == 0.0)
            shakeY = 0.8f;
    }

    protected abstract void TapEventTrigger();


    void Update()
    {
        Vector3 newPosition = new Vector3(0, shakeY, 0);
        if (shakeY < 0)
        {
            shakeY *= shakeYSpeed;
        }
        shakeY = -shakeY;
        transform.Translate(newPosition, Space.Self);

        if (shakeY < 0.1 && shakeY > -0.1)
        {
            shakeY = 0.0f;
        }
    }

}
