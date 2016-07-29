using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Microsoft;
using BehaviorLibrary;
using BehaviorLibrary.Components;
using BehaviorLibrary.Components.Actions;
using BehaviorLibrary.Components.Composites;
using BehaviorLibrary.Components.Conditionals;
using BehaviorLibrary.Components.Decorators;
using BehaviorLibrary.Components.Utility;
namespace BTConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string[] text = new string[2] {"1", "5"};
			string[] options = new string[2] {"2", "3"};
			ArrayList arr = new ArrayList ();
			arr.Add (text);
			arr.Add (options);
			//result[0] = options;
			//result [0] [0] = text;
			foreach (string[] str in arr) {
				foreach(string s in str)
					System.Console.WriteLine (s);
			}
//			for (int i = 0; i < 3; i++) {
//				string str = arr [i];
//				System.Console.WriteLine (str);
//			}


			//for PRACTICE
//			bool cold = false;
//			bool sneeze = false;
//			bool fever = true;
//			bool tired = true;
//			bool headache = true;
//			Conditional tooCold = new Conditional (delegate() {
//				if(cold) return true;
//				else return false;
//			});
//			Conditional tooSneeze = new Conditional (delegate() {
//				if(sneeze) return true;
//				else return false;
//			});
//			Conditional tooFever = new Conditional (delegate() {
//				if(fever) return true;
//				else return false;
//			});
//			Conditional tooTired = new Conditional (delegate() {
//				if(tired) return true;
//				else return false;
//			});
//			Conditional tooHeadache = new Conditional (delegate() {
//				if(headache) return true;
//				else return false;
//			});
//			BehaviorAction areCold = new BehaviorAction (delegate(){
//				if(tooCold.Behave().ToString()=="Success"){
//					Console.WriteLine("He is cold");
//					return BehaviorReturnCode.Success;
//				}else{
//					Console.WriteLine("He is not cold");
//					return BehaviorReturnCode.Failure;
//			}});
//			BehaviorAction areSneeze = new BehaviorAction (delegate(){
//				if(tooSneeze.Behave().ToString()=="Success"){
//					Console.WriteLine("He sneezes");
//					return BehaviorReturnCode.Success;
//				}else{
//					Console.WriteLine("He does not sneeze");
//					return BehaviorReturnCode.Failure;
//				}});
//			BehaviorAction areFever = new BehaviorAction (delegate(){
//				if(tooFever.Behave().ToString()=="Success"){
//					Console.WriteLine("He has a fever");
//					return BehaviorReturnCode.Success;
//				}else{
//					Console.WriteLine("He has no fever");
//					return BehaviorReturnCode.Failure;
//				}});
//			BehaviorAction areTired = new BehaviorAction (delegate(){
//				if(tooTired.Behave().ToString()=="Success"){
//					Console.WriteLine("He is tired");
//					return BehaviorReturnCode.Success;
//				}else{
//					Console.WriteLine("He is not tired");
//					return BehaviorReturnCode.Failure;
//				}});
//			BehaviorAction areHeadache = new BehaviorAction (delegate(){
//				if(tooHeadache.Behave().ToString()=="Success"){
//					Console.WriteLine("He has Headache");
//					return BehaviorReturnCode.Success;
//				}else{
//					Console.WriteLine("He has no Headache");
//					return BehaviorReturnCode.Failure;
//				}});
//			Sequence sequencer1 = new Sequence (areCold, areSneeze);
//			Sequence sequencer2 = new Sequence (areFever, areCold);
//			Selector selector2 = new Selector (areTired, areHeadache);
//			Selector selector1 = new Selector (sequencer1, sequencer2, selector2);
//			RootSelector root = new RootSelector (delegate() {return 0;}, selector1);


			///////////////////////////////////////////////////////////////////////////////////////////////////
			//Basic Outline for eCoach 
//			BehaviorAction option = new BehaviorAction (delegate() {
//				string inputText = Console.ReadLine();
//				if(inputText == "Basic Tutorial of eCoach"){
//					System.Console.WriteLine("eCoach: You selected Tutorial of eCoach. Lets start!");
//					return BehaviorReturnCode.Success;
//				}
//				else if(inputText == "General Diagnosis"){
//					System.Console.WriteLine("eCoach: You selected General Diagnosis. Lets start!");
//					return BehaviorReturnCode.Success;
//				}
//				else if(inputText == "Cancer"){
//					System.Console.WriteLine("eCoach: You selected Cancer. Lets learn about Cancer!");
//					return BehaviorReturnCode.Success;
//				}
//				else return BehaviorReturnCode.Failure;
//			});
//
//			Selector menuSelector = new Selector(option);
//			BehaviorAction begin = new BehaviorAction (delegate() {
//				string[] introLine = System.IO.File.ReadAllLines(@"../../Introduction.txt");
//				//System.Console.WriteLine("Contents of Introduction.txt = ");
//				foreach (string line in introLine)
//				{
//					Console.WriteLine("\t" + line);
//				}
//				Console.WriteLine("eCoach: Enter yes or no:");
//				return BehaviorReturnCode.Success;
//
//			});
//			Conditional introConditional = new Conditional (delegate(){
//				string inputText = Console.ReadLine();
//				if((inputText == "No")|(inputText == "no")|(inputText == "NO")){
//					System.Console.WriteLine("Good Bye!");
//					return false;
//				}
//				else if((inputText == "Yes")|(inputText == "yes")|(inputText == "YES")){
//					return true;
//				}
//				else return false;
//			});
//			BehaviorAction wantPlay = new BehaviorAction (delegate() {
//				if(introConditional.Equals(introConditional)){
//					string[] menuLine = System.IO.File.ReadAllLines(@"../../Menu.txt");
//					//System.Console.WriteLine("Contents of Menu.txt = ");
//					foreach (string line in menuLine)
//					{
//						Console.WriteLine("\t" + line);
//					}
//					Console.WriteLine("eCoach: Select one of the option above:");
//					//Selector menuSelector = new Selector();
//					menuSelector.Behave();
//					return BehaviorReturnCode.Success;
//				}
//				else{
//					System.Console.WriteLine("eCoach: Good Bye!");
//					return BehaviorReturnCode.Failure;
//				}
//			});
//			Sequence introSelector = new Sequence (introConditional, wantPlay);
//			Sequence beginSelector = new Sequence (begin, introSelector);
//			beginSelector.Behave ();
//






			//Basic Conversation
//			BehaviorAction intro = new BehaviorAction (delegate() {
//				System.Console.WriteLine("Hi, my name is eCoach. How are you doing?");
//				return BehaviorReturnCode.Success;
//			});
//			BehaviorAction reply = new BehaviorAction (delegate() {
//				string inputText = Console.ReadLine();
//				if (inputText == "I am fine, how are you?"){
//					System.Console.WriteLine("eCoach: I am fine, thank you. What did you do this weekend?");
//					return BehaviorReturnCode.Success;
//				}
//				else if(inputText == "I am fine"){
//					System.Console.WriteLine("eCoach: What did you do this weekend?");
//					return BehaviorReturnCode.Success;
//				}
//				else return BehaviorReturnCode.Failure;
//			});
////			BehaviorAction sentence2 = new BehaviorAction (delegate() {
////				string inputText = Console.ReadLine();
////				if(inputText == "I am fine"){
////					System.Console.WriteLine("What did you do this weekend?");
////					return BehaviorReturnCode.Success;
////				}
////				else return BehaviorReturnCode.Failure;
////			});
//			BehaviorAction movie1 = new BehaviorAction (delegate() {
//				string inputText = Console.ReadLine();
//				if (inputText == "I watched movie"){
//					System.Console.WriteLine("eCoach: Oh, what movie?");
//					return BehaviorReturnCode.Success;
//				}
//				else return BehaviorReturnCode.Failure;
//			});
//			BehaviorAction movie2 = new BehaviorAction (delegate() {
//				string inputText = Console.ReadLine();
//				if(inputText == "I watched Interstellar"){
//					System.Console.WriteLine("eCoach: I wanted to watched that. How was it?");
//					return BehaviorReturnCode.Success;
//				}
//				else if(inputText == "Interstellar"){
//					System.Console.WriteLine("eCoach: I wanted to watched that. How was it?");
//					return BehaviorReturnCode.Success;
//				}
//				else return BehaviorReturnCode.Failure;
//			});
//			BehaviorAction movie3 = new BehaviorAction (delegate() {
//				string inputText = Console.ReadLine();
//				if (inputText == "It was good"){
//					System.Console.WriteLine("eCoach: I better watch that sometime this week.");
//					return BehaviorReturnCode.Success;
//				}
//				else if(inputText == "It was bad"){
//					System.Console.WriteLine("eCoach: Next time, ask me for recommendation before you watch movie.");
//					return BehaviorReturnCode.Success;
//				}
//				else return BehaviorReturnCode.Failure;
//			});
//			Sequence selector1 = new Sequence (reply, movie1, movie2, movie3);
//			Sequence Introduction = new Sequence (intro, selector1);
//			Introduction.Behave ();
//			if (root.Behave ().ToString()=="Success") {
//				Console.WriteLine ("He is SICK");
//
//				string[] introLine = System.IO.File.ReadAllLines(@"/Users/jaekyuoh/Documents/AI-Research/BTConsole/BTConsole/Introduction.txt");
//				System.Console.WriteLine("Contents of Introduction.txt = ");
//				foreach (string line in introLine)
//				{
//					Console.WriteLine("\t" + line);
//				}
//				Console.WriteLine("Enter yes or no:");
//				string input = Console.ReadLine(); 
//				if (input == "no") {
//					Console.WriteLine ("See you next time!");
//				} 
//				else if (input == "yes") {
//					string[] menuLine = System.IO.File.ReadAllLines(@"/Users/jaekyuoh/Documents/AI-Research/BTConsole/BTConsole/Menu.txt");
//					System.Console.WriteLine("Contents of Menu.txt = ");
//					foreach (string line in menuLine)
//					{
//						Console.WriteLine("\t" + line);
//					}
//					Console.WriteLine("Select one from the Menu:");
//					string input2 = Console.ReadLine();
//					if (input2 == "Cancer") {
//						string[] prescriptionLine = System.IO.File.ReadAllLines(@"/Users/jaekyuoh/Documents/AI-Research/BTConsole/BTConsole/prescription.txt");
//
//						// Display the file contents by using a foreach loop.
//						System.Console.WriteLine("Contents of prescription.txt = ");
//						foreach (string line in prescriptionLine)
//						{
//							// Use a tab to indent each line of the file.
//							Console.WriteLine("\t" + line);
//						}
//					}
//				}
//
//				//int counter = 0;
//				//string line;
//
//				// Read the file and display it line by line.
////				System.IO.StreamReader file = 
////					new System.IO.StreamReader(@"/Users/jaekyuoh/Documents/AI-Research/BTConsole/BTConsole/Introduction.txt");
////				while((line = file.ReadLine()) != null)
////				{
////					System.Console.WriteLine (line);
////					//counter++;
////				}
////
////				file.Close();
//				//System.Console.WriteLine("There were {0} lines.", counter);
//				// Suspend the screen.
//				//System.Console.ReadLine();
//			}

		}
	}
}
