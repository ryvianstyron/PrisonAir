using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectionSlider : MonoBehaviour {

	public GameObject levelSlotPrefab;
	public GameObject content;
	public ToggleGroup levelSlotToggleGroup;


	private int xPos = 0;
	private int yPos = 0;
	private GameObject levelSlot;
	//private Text textField;
	// Use this for initialization
	void Start () {

		CreateLevelSlotsInWindow ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateLevelSlotsInWindow()
	{
		for (int i = 0; i <12; i++) 
		{
			levelSlot = (GameObject)Instantiate(levelSlotPrefab);
			levelSlot.name = i.ToString();
			levelSlot.GetComponent<Toggle>().group = levelSlotToggleGroup;
			levelSlot.transform.SetParent(content.transform);
			//levelSlot = GetComponentsInChildren<Transform>();
			foreach(Transform child in levelSlot.GetComponentInChildren<Transform>())
			{
				Debug.Log (child);
				if(child.gameObject.name == "Level")
				{
					child.gameObject.GetComponent<Text>().text ="Level"+ (i + 1);
					// Each level needs to 
					Debug.Log("Amina ia smelly");
				}
			}
			//textField.text = i.ToString();

			levelSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
			xPos -= (int)levelSlot.GetComponent<RectTransform>().rect.width;
		}
	}
}
