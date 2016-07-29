using UnityEngine;
using System.Collections;

[System.Serializable]
public class ConversationNode : System.Object {
	public string text;
	public string[] options;

	public ConversationNode(string t, string[] o)
	{
		text = t;
		options = o;
	}
	
}
