using UnityEngine;

public class MainScript : MonoBehaviour
{
	void Awake()
    {
        GameObject obj = GameObject.Find("TapArea");
        TapView view = obj.GetComponent<TapView>();
        new TapController(view);
    }
}
