using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class TaskTracker : MonoBehaviour 
{
	[Serializable]
	public struct LabelAndGameObject
	{
		public string Label;
		public GameObject gameobject;
	}
    // This is a cute comment put here by a cute person called amina
	public List<LabelAndGameObject> LabelsAndGameObjects;
    public void Initialize()
    {
        Debug.Log("Initialize");
        String SceneLabel = "Prison" + GameManager.LevelBuilder.GetCurrentLevel().GetPrisonNumber() +
                            "Level" + GameManager.LevelBuilder.GetCurrentLevel().GetLevelNumber();
        if (Application.loadedLevelName == SceneLabel && GameManager.LevelBuilder.GetCurrentLevel().IsLevelCompleted() == false)
        {
            Debug.Log("Intialize: Level Not Yet Completed");
            List<Task> TaskList = new List<Task>();
            TaskList.AddRange(GameManager.LevelBuilder.GetCurrentLevel().GetLevelObjectives()[0].GetTasks());
            TaskList.AddRange(GameManager.LevelBuilder.GetCurrentLevel().GetLevelObjectives()[1].GetTasks());
            TaskList.AddRange(GameManager.LevelBuilder.GetCurrentLevel().GetLevelObjectives()[2].GetTasks());
            TaskList.AddRange(GameManager.LevelBuilder.GetCurrentLevel().GetLevelObjectives()[3].GetTasks());

            List<LabelAndGameObject> Temp = LabelsAndGameObjects;
            if (LabelsAndGameObjects.Count > 0)
            {
                for (int i = 0; i < LabelsAndGameObjects.Count; i++)
                {
                    for (int m = 0; m < TaskList.Count; m++)
                    {
                        if (LabelsAndGameObjects[i].Label == TaskList[m].GetLabel()
                        && TaskList[m].IsTaskCompleted())
                        {
                            Debug.Log("Done Task - Popping :" + TaskList[m].GetLabel());
                            Temp.RemoveAt(i);
                        }
                    }
                }
                LabelsAndGameObjects = Temp;
                LabelsAndGameObjects[0].gameobject.tag = "TASK";
                ((Behaviour)LabelsAndGameObjects[0].gameobject.GetComponent("Halo")).enabled = true;
            }
        }
    }
	void Update () 
	{
	}
	public void Pop()
	{
        if(LabelsAndGameObjects.Count > 0)
        {
            ((Behaviour)LabelsAndGameObjects[0].gameobject.GetComponent("Halo")).enabled = false;

            // TESTING ONLY 
            LabelsAndGameObjects[0].gameobject.GetComponent<BoxCollider>().enabled = false;

            LabelsAndGameObjects.RemoveAt(0);


            if(LabelsAndGameObjects.Count > 0)
            {
                LabelsAndGameObjects[0].gameobject.tag = "TASK";
                ((Behaviour)LabelsAndGameObjects[0].gameobject.GetComponent("Halo")).enabled = true;
            }
        }
	}
}
