using UnityEngine;
using System.Collections.Generic;

// Save all tasks in game according to level and prison - "P1_L1_A", 1
public class CreateStoryBoard 
{

	List<string> Preferences = new List<string>();
	// Use this for initialization
	void Start () 
	{
		SavePreference("Get Knife");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SavePreference(string TaskDescription)
	{
		//for()
		{
			// Create label
			// create order
			PlayerPrefs.SetString ("Label", "order" + TaskDescription);
		}
	}
}
