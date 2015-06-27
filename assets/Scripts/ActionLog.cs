using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ActionLog : MonoBehaviour 
{
	private const int HITS_BEFORE_CLEAR = 8;
	public GameObject HitObjectsPrefab;
	public GameObject ScoreHolder;
	private GameObject ObjectSlot;
	private List <string> actionLog = new List<string> ();
	private int objectsHit;
	public GameObject[] actionLogItems;

	void Start()
	{
		foreach(GameObject action in actionLogItems)
		{
			action.SetActive(false);
		}
	}
	public void OnHit(string objectHit, int Score)
	{
		Debug.Log ("OnHit: " + objectHit + " " + Score);
		if (objectsHit == HITS_BEFORE_CLEAR) 
		{
			for (int i = 0; i< objectsHit; i++) 
			{
				actionLogItems[i].SetActive(false);
			}
			objectsHit = 0;

		}
		objectsHit++;
		for (int i = 0; i< objectsHit; i++) 
		{
			actionLogItems[i].SetActive(true);
		}
		Text[] TextItems = actionLogItems [objectsHit - 1].GetComponentsInChildren<Text> ();
		Debug.Log ("Printing out gameobject names " + TextItems.Length);
		for (int i = 0; i <TextItems.Length; i++) 
		{
			Debug.Log (TextItems [i].gameObject.name);
		}

		for (int i = 0; i < TextItems.Length; i++) 
		{
			if (TextItems[i].gameObject.name == "Name")
			{
				TextItems[i].text = objectHit;
			}
			if (TextItems[i].gameObject.name == "Points")
			{
				TextItems[i].text = Score + "" ;
			}
		}
	}
	public void ItemVisibility(GameObject Item, bool Visible)
	{
		// For each for all the components in item and set them to invisibile
	}
}
