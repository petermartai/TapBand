using UnityEngine;
using System.Collections;

public abstract class BandMemberController : MonoBehaviour
{

    private GameState gameState;

    void Start()
    {
        gameState = GameState.instance;
    }

    public void TapEventOnBandMember()
    {
        // should notify, instead of this
        // cathc the notification in HudController
        gameState.money++;
    }
}
