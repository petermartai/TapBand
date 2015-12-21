using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
	public GameObject restartButton,restartPanel;
	
	public void Start()
	{
		OnUnRestart();
	}
	
	public void OnRestart()
	{
		restartPanel.SetActive (true);
		restartButton.SetActive (false);
		Time.timeScale=0;
	}
	
	public void OnUnRestart()
	{ 
		restartPanel.SetActive (false);
		restartButton.SetActive (true);
		Time.timeScale=1;
	}
	
	public void RestartLevel()
	{
		//
	}
}
