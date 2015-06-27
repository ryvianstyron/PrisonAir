using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

	private List<string> InventoryObjects = new List<string>();

	public bool AddToInventory(string item)
	{
		if (InventoryObjects.Count < 4) 
		{
			InventoryObjects.Add (item);
			return true;
		}
		return false;
	}
	public bool RemoveFromInventory(string item)
	{
        Debug.Log("RemoveFromInventory(): " + item);
        Debug.Log(this.ToString());

        int index = -1;
		for(int i = 0; i < InventoryObjects.Count; i++)
		{
			if(InventoryObjects[i].Equals(item))
			{
				index = i;
				break;
			}
		}
		if(index != -1)
		{
			InventoryObjects.RemoveAt(index);
			return true; 
		}
		else return false;
	}
	public override string ToString()
	{
		string info = "\n";
		if(InventoryObjects.Count > 0)
		{
			foreach(string s in InventoryObjects)
			{
				info += s + ",";
			}
			return info;
		}
		else return "Empty";
	}
}
	