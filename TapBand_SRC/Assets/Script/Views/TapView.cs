using System;
using System.Collections.Generic;

using UnityEngine;

public class TapArgs
{
    public ICollection<Vector3> positions;

    public TapArgs()
    {
        positions = new List<Vector3>();
    }
}

public class TapView : MonoBehaviour
{
    private Collider2D _collider;

    public delegate void TapEvent(TapArgs args);
    public event TapEvent OnTap;

	// Use this for initialization
	void Start()
    {
        _collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update()
    {
        if (Input.touchCount > 0)
        {
            TapArgs args = CalculateTapEventArgs();
            if (OnTap != null)
                OnTap(args);
        }
	}

    void OnMouseDown()
    {
        TapArgs args = new TapArgs();
        args.positions.Add(Input.mousePosition);
        if (OnTap != null)
            OnTap(args);
    }

    private TapArgs CalculateTapEventArgs()
    {
        TapArgs args = new TapArgs();
        for (var i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
                if (_collider == Physics2D.OverlapPoint(wp))
                {
                    args.positions.Add(touch.position);
                }
            }
        }

        return args;
    }
}
