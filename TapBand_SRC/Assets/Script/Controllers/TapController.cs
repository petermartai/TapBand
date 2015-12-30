using UnityEngine;

public class TapController : MonoBehaviour
{
    private TapUI tapUI;

    public delegate void TapEvent(BigInteger value);
    public event TapEvent OnTap;

    void Awake()
    {
        BindWithUI();
    }

    void OnEnable()
    {
        tapUI.OnTap += HandleTap;
    }

    void OnDisable()
    {
        tapUI.OnTap -= HandleTap;
    }

    #region MVC bindings
    private void BindWithUI()
    {
        tapUI = (TapUI)FindObjectOfType(typeof(TapUI));
    }
    #endregion

    private void HandleTap(TapArgs args)
    {
        foreach(Vector3 position in args.positions)
        {
            tapUI.DisplayTapValueAt(position, 1);
        }
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
