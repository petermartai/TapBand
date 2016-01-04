using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RestartUI : MonoBehaviour {

    public delegate void NewLevelEvent();
    public event NewLevelEvent NewLevel;

    public delegate bool RestartEnabledEvent();
    public event RestartEnabledEvent RestartEnabled;

    public GameObject restartPanelButton,restartPanel,restartButton,upgradePanel;
	
	public void Start()
	{
		OnUnRestart();
	}
	
	public void OnRestart()
	{
		restartPanel.SetActive (true);
		restartPanelButton.SetActive (false);
		upgradePanel.SetActive (false);
		Time.timeScale=0;
	}
	
	public void OnUnRestart()
	{ 
		restartPanel.SetActive (false);
		restartPanelButton.SetActive (true);
		upgradePanel.SetActive (true);
        restartButton.GetComponent<Button>().interactable = false;
		Time.timeScale=1;
	}
	
	public void RestartLevel()
	{
        NewLevel();
        OnUnRestart();
    }

    void OnGui()
    {
        if (restartPanel.activeInHierarchy)
        {
            if (RestartEnabled != null)
            {
                restartButton.GetComponent<Button>().interactable = RestartEnabled();
            }
        }
    }
}
