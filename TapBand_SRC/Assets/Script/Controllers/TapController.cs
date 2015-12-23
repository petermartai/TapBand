using UnityEngine;

public class TapController
{
    private TapView view;

    public delegate void TapEvent(BigInteger value);
    public event TapEvent OnTap;

    TapController(TapView view)
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
