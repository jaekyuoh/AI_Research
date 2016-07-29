using UnityEngine;
using System.Collections;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using BehaviorLibrary;
using BehaviorLibrary.Components;
using BehaviorLibrary.Components.Actions;
using BehaviorLibrary.Components.Composites;
using BehaviorLibrary.Components.Conditionals;
using BehaviorLibrary.Components.Decorators;
using BehaviorLibrary.Components.Utility;

public class BehaviorTreeStructure : MonoBehaviour {

	void Start () {
		Debug.Log ("Press space key to start the tree.");
		infoText = "Press space key to start the tree.";
		//begin.Behave();
	}	

	public ConversationNode sendToGUI(string text, string[] options){
		// send Array of string of Text that Avatar speaks and array of options that user can make to GUI
		ConversationNode result = new ConversationNode(text, options);
		return result;
	}

	static string yes ="nothing";
	static string option = "nothing";
	bool calledOnce = false;
	static string infoText;

	void OnGUI()
	{
		//GUI.skin.textField.wordWrap = true;
		GUI.Label(new Rect(0, 0, Screen.width, Screen.height),infoText);
		//GUI.TextField(new Rect(Screen.width-200,0,200,Screen.height-40), InfoText);
	}
	//public void tree(){ // Actual tree structure
	static BehaviorAction begin = new BehaviorAction (delegate() {
		string text = "eCoach: Hello. My name is eCoach. I am an electronic aid to help you understand your cancer treatment options. Your doctor has asked me to speak with you regarding your choice of treatement for your prostate cancer. Would you like to continue now?";
		infoText = text;
		string[] options = new string[2]{"Yes","No"}; 
		//sendToGUI (text, options);
		Debug.Log (text);
		infoText += "\nUp if Yes\nDown to exit.";
		//Debug.Log ("Press Up Arrow for Yes and Down Arrow for no");
		return BehaviorReturnCode.Success;
		});
	
			static BehaviorAction wantPlay = new BehaviorAction (delegate() {
					string input = MediatorScript.Instance.SendToTree ();
					if (/*If user pressed Yes button*//*input == "Yes"*/yes=="Yes") {
						string text = "eCoach: Select an option by using your number pad:\n" +
							"1. Basic Tutorial of eCoach\n" +
							"2. General Diagnosis\n" +
							"3.Cancer";
		    			infoText= text;
						string[] options = new string[3]{"Basic Tutorial of eCoach","General Diagnosis","Cancer"}; 
						//sendToGUI (text, options);
						Debug.Log(text);
						Debug.Log("Press 1 for Basic Tutorial, 2 for General Diagnosis, 3 for Cancer");
						
						return BehaviorReturnCode.Success;
					}
					//If user pressed No button
					else if (/*input == "No"*/ yes=="No") { 
						string text = "eCoach: Okay, then I will hope to tlk with you later. Thank you.";
						infoText = text;
						string[] options = new string[0]; 
						//sendToGUI (text, options);
						Debug.Log(text);
						return BehaviorReturnCode.Failure;
					} 
					else return BehaviorReturnCode.Failure;
				});
				static BehaviorAction tutorialText = new BehaviorAction (delegate() {
					//If user chose Basic Tutorial of eCoach from wantPlay
					string input = MediatorScript.Instance.SendToTree ();
				if (/*input == "Basic Tutorial of eCoach"*/option == "Basic Tutorial of eCoach") {
						string text = "eCoach: This is the Basic Tutorial of eCoach. Let's start with what it is.";
						infoText = text;
						string[] options = new string[0]; 
						//sendToGUI (text, options);
						Debug.Log (text);
						return BehaviorReturnCode.Success;
					} 
					else return BehaviorReturnCode.Failure;
				});
				static BehaviorAction diagnosisText = new BehaviorAction (delegate() {
					//If user chose General Diagnosis from wantPlay
					string input = MediatorScript.Instance.SendToTree ();
				if (/*input == "General Diagnosis"*/option == "General Diagnosis") {
						string text = "eCoach: This is General Diagnosis. Let's start with how you feel today";
						infoText =  text;
						string[] options = new string[0]; 
						//sendToGUI (text, options);
						Debug.Log (text);
						return BehaviorReturnCode.Success;
					}
					else return BehaviorReturnCode.Failure;
				});
				static BehaviorAction cancerText = new BehaviorAction (delegate() {
					//If user chose Cancer from wantPlay
					string input = MediatorScript.Instance.SendToTree ();
					if (/*input == "Cancer"*/option == "Cancer") {
						string text = "eCoach: This is about Cancer. Let's start with what cancer is.";
						infoText =  text;
						string[] options = new string[0]; 
						//sendToGUI (text, options);
						Debug.Log (text);
						return BehaviorReturnCode.Success;
					} 
					else return BehaviorReturnCode.Failure;
				});
				static Sequence tutorialSequence = new Sequence (tutorialText);
				static Sequence diagnosisSequence = new Sequence (diagnosisText);
				static Sequence cancerSequence = new Sequence (cancerText);
				static Selector MenuSelector = new Selector (tutorialSequence, diagnosisSequence, cancerSequence);
				static Sequence continueSequence = new Sequence (wantPlay, MenuSelector);
				static Sequence beginSequence = new Sequence (begin, continueSequence);
				static RootSelector root = new RootSelector (delegate() {return 0;}, beginSequence);
		//}
	//beginSequence.Behave ();

//	void OnGUI () {
//		// Make a background box
//		GUI.Box(new Rect(10,10,100,90), "Loader Menu");
//		
//		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
//		if(GUI.Button(new Rect(20,40,80,20), "Yes")) {
//			Application.LoadLevel(1);
//		}
//		
//		// Make the second button.
//		if(GUI.Button(new Rect(20,70,80,20), "No")) {
//			Application.LoadLevel(2);
//		}
//	}
//	void OnGUI () {
//		// Make a background box
//		GUI.Box(new Rect(10,10,200,150), "Loader Menu");
//		
//		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
//		if(GUI.Button(new Rect(40,40,120,20), "Basic Tutorial")) {
//			Application.LoadLevel(1);
//		}
//		
//		// Make the second button.
//		if(GUI.Button(new Rect(40,70,120,20), "General Diagnosis")) {
//			Application.LoadLevel(2);
//		}
//		if(GUI.Button(new Rect(40,100,120,20), "Cancer")) {
//			Application.LoadLevel(2);
//		}
//	}

	void Update () {
		//start
		if (Input.GetKeyDown (KeyCode.Space) && !calledOnce) {
			//Pass a no response to the system
			//Print out next choice
			begin.Behave();
				calledOnce = true;
			//OnGUI();
		}
		//Yes instance
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			//Pass a yes response to the system
			//Print out next choice
			yes = "Yes";
			continueSequence.Behave();
		}

		//No instance
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			//Pass a no response to the system
			//Print out next choice
			yes = "No";
			continueSequence.Behave();
			this.enabled = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			//Pass a no response to the system
			//Print out next choice
			option = "Basic Tutorial of eCoach";
			MenuSelector.Behave();
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			//Pass a no response to the system
			//Print out next choice
			option = "General Diagnosis";
			MenuSelector.Behave();
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			//Pass a no response to the system
			//Print out next choice
			option = "Cancer";
			MenuSelector.Behave();
		}
	}
	
//	static int YesNoCheck(){
//		bool keyPushed = false;
//		while(!keyPushed){
//			Debug.Log ("Looping");
//			if(Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)){
//				Debug.Log ("Key was pressed");
//				keyPushed = true;
//				if(Input.GetKeyDown (KeyCode.UpArrow)){ 
//					return 1; 
//				}
//				else if(Input.GetKeyDown (KeyCode.DownArrow)){
//					return 2;
//				}
//			}
//			//yield;
//		}
//		return 0;
//	}
	
//		public IEnumerator FirstFunction()
//		{
//			//by default in our settings this is the space bar, so we will use this just to make it simple.
//			yield return StartCoroutine(WaitForKeyPress("Jump"));
//		//yield return StartCoroutine(WaitForKeyPress(KeyCode.UpArrow));
//			//this time the coroutine won't fire this print statement off until it completes
//			print("Coroutine did finish.");
//		}
//		public IEnumerator WaitForKeyPress(string _button)
//		{
//			while(!_keyPressed)
//			{
//				if(Input.GetButtonDown(_button))
//				{
//					tree();
//					break;
//				}
//				//print("Awaiting key input.");
//				yield return 0;
//			}
//		}
//	public IEnumerator yesFunction()
//	{
//		//by default in our settings this is the space bar, so we will use this just to make it simple.
//		yield return StartCoroutine(WaitForYes("yes"));
//		//yield return StartCoroutine(WaitForKeyPress(KeyCode.UpArrow));
//		//this time the coroutine won't fire this print statement off until it completes
//		print("YesCoroutine did finish.");
//	}
//	public IEnumerator WaitForYes(string _button)
//	{
//		while(!yes_keyPressed)
//		{
//			if(Input.GetButtonDown(_button))
//			{
//				//tree();
//				yes = 1;
//				break;
//			}
//			//print("Awaiting key input.");
//			yield return 0;
//		}
//		//yield return null;
//	}

}


