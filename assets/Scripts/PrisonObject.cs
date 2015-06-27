using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class PrisonObject : MonoBehaviour
{
	public Enums.PrisonObjectType Type;

    public void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.name.Contains("Head") ||
         Collision.gameObject.name.Contains("Knee") ||
         Collision.gameObject.name.Contains("Hand") ||
         Collision.gameObject.name.Contains("Elbow") ||
         Collision.gameObject.name.Contains("Torso") ||
         Collision.gameObject.name.Contains("Foot") ||
         Collision.gameObject.name.Contains("Pelvis") ||
         Collision.gameObject.name.Contains("Hip") ||
         Collision.gameObject.name.Contains("Shoulder"))
        {
			//Debug.Log(Collision.gameObject.name + " Hit " + gameObject.name);
            if (gameObject.tag == "INVENTORY") // An Inventory Object has been hit by the prisoner
            {
                if (GameManager.Inventory.AddToInventory(gameObject.name))
                {
                    //GameManager.Inventory.AddToInventory(gameObject.name);
                    GameObject.Destroy(gameObject);
                    Debug.Log(GameManager.Inventory.ToString());
                }
            }
            if (gameObject.tag == "TASK")
            {
				if(GameManager.LevelBuilder.GetCurrentTask () == null)
				{
					//Debug.Log ("PrisonObject.cs - CurrentTask is NULL");
					return;
				}
                if (GameManager.LevelBuilder.GetCurrentTask() != null
				    && GameManager.LevelBuilder.GetCurrentTask().GetItemNeeded() == "None" ||
                    GameManager.Inventory.RemoveFromInventory(GameManager.LevelBuilder.GetCurrentTask().GetItemNeeded()))
                {
                    gameObject.tag = "Untagged";
                    GameManager.TaskTracker.Pop(); // Pops the first element in the list of LabelsAndGameObjects
                    GameManager.LevelBuilder.GetCurrentTask().SetTaskCompleted();
                }
            }
            // Send LimbType & Obstacle Type to Score
            Enums.Limb Limb = (Enums.Limb)System.Enum.Parse(typeof(Enums.Limb), Collision.gameObject.name);
            Score.Calculate(Type, Limb);
        }
    }
}
