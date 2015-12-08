
using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ExampleController : MonoBehaviour
{	
	public int id;
	
	private List<ExampleData> exampleDatas;
	//private ExampleUI exampleUI;
	
	void Awake()
	{		
		BindWithModel();
		BindWithGFX();
		BindWithUI();
	}
	
	void Start()
	{
		//InitGFX();
		InitUI();
	}
	
	#region MVC bindings
	private void BindWithModel()
	{
		exampleDatas = GameData.instance.exampleDatas;
	}
	
	private void BindWithGFX()
	{
		// Find GFX objects in the scene
	}
	
	private void BindWithUI()
	{
		// Find UI parts
	}
	#endregion

	private void InitUI()
	{
		Debug.Log ("Coin values");
		for(int i = 0; i < exampleDatas[0].levelDatas.Count; i++)
		{
			Debug.Log(exampleDatas[0].levelDatas[i].coin);
		}
	}
}