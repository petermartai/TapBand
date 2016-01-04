using UnityEngine;
using System.Collections;

public class DevelopmentUI : MonoBehaviour {

	public GameObject Maythe4thButton,UpgradePanel;
	
	public void Start()
	{
		OnMayNot();
	}
	
	public void OnMaythe4th()
	{
		Maythe4thButton.SetActive (false);
		UpgradePanel.SetActive (true);
		Time.timeScale=0;
	}
	
	public void OnMayNot()
	{ 
		UpgradePanel.SetActive (false);
		Maythe4thButton.SetActive (true);
		Time.timeScale=1;
	}

}
