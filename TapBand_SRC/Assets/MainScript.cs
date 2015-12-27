using UnityEngine;

public class MainScript : MonoBehaviour
{
	void Awake()
    {
        GameObject obj = GameObject.Find("TapArea");
        TapUI view = obj.GetComponent<TapUI>();
        new TapController(view);
    }
}
