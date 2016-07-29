using UnityEngine;
using System.Collections;

public class MediatorScript : MonoBehaviour {

	public string inputFromGUI;
	public string resultToBTree; 

	public static MediatorScript Instance
	{
		get 
		{
			return _instance;
		}
	}
	private static MediatorScript _instance;

	void Awake()
	{
		_instance = this;
	}

	public string GetFromGUI(string input){
		inputFromGUI = input;
		return inputFromGUI;
	}
	
	public string SendToTree(){
		resultToBTree = inputFromGUI;
		return resultToBTree;
	}

}
