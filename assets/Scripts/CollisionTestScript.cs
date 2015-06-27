using UnityEngine;
using System.Collections;

public class CollisionTestScript : MonoBehaviour 
{
	public void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Inventory")
		{
			if(GameManager.Inventory.AddToInventory(collision.gameObject.name))
			{
				GameManager.Inventory.AddToInventory(collision.gameObject.name);
				GameObject.Destroy(collision.gameObject);
				Debug.Log (GameManager.Inventory.ToString());
			}
		}
		if(collision.gameObject.tag == "Test")
		{
			Task CurrentTask = GameManager.LevelBuilder.GetCurrentTask();
			Debug.Log ("Collision" + CurrentTask.GetDescription());
			if(CurrentTask.GetItemNeeded() == "None" || GameManager.Inventory.RemoveFromInventory(CurrentTask.GetItemNeeded()))
			{
				CurrentTask.SetTaskCompleted();
			}

		}
	}
	public void DebugTest()
	{
		//Debug.Log("Level status: " + LevelBuilder.CurrentLevel);
	}
}
