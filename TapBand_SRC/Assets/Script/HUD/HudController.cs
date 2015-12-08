using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudController : MonoBehaviour {

    private GameObject coin;
    private GameObject fan;

    private GameState state;

    void Start () {
        coin = GameObject.Find("CoinText");
        fan = GameObject.Find("FanText");

        state = GameState.instance;
	}
	
	void Update () {
        coin.GetComponent<Text>().text = state.money.ToString();
        fan.GetComponent<Text>().text = state.numberOfFans.ToString();
    }
}
