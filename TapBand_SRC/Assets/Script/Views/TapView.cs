using System;
using System.Collections.Generic;

using UnityEngine;

public class TapArgs
{
    public ICollection<Vector3> positions;
}

public class TapView : MonoBehaviour
{
    private Collider2D collider;

    public delegate void TapEvent(TapArgs args);
    public event TapEvent OnTap;

	// Use this for initialization
	void Start()
    {
        collider = GetComponent<Collider2D>();
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

    private TapArgs CalculateTapEventArgs()
    {
        TapArgs args = new TapArgs();
        Collider2D collider = GetComponent<Collider2D>();
        for (var i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
                if (collider == Physics2D.OverlapPoint(wp))
                {
                    args.positions.Add(touch.position);
                }
            }
        }

        return args;
    }
}
