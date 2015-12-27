using UnityEngine;

public class TapController
{
    private TapUI view;

    public delegate void TapEvent(BigInteger value);
    public event TapEvent OnTap;

    public TapController(TapUI view)
    {
        this.view = view;

        this.view.OnTap += HandleTap;
    }

    private void HandleTap(TapArgs args)
    {
        if (OnTap != null)
        {
            BigInteger tapValue = CalculateTapValue(args.positions.Count);
            OnTap(tapValue);
        }
    }

    private BigInteger CalculateTapValue(int tapCount)
    {
        return tapCount * 1;
    }
}
