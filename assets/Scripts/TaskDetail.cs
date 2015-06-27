using UnityEngine;
using System.Collections;

// Class structure for holding string detail for tasks
public class TaskDetail 
{
	private string TaskDescription; // What the player sees
	private string TaskDialog;
	private string NeedsItem;

	public TaskDetail(string TaskDescription, string TaskDialog) 
	{
		//new TaskDetail (TaskDescription, TaskDialog, "None");
		this.TaskDescription = TaskDescription;
		this.TaskDialog = TaskDialog;
		this.NeedsItem = "None";
	}
	public TaskDetail(string TaskDescription, string TaskDialog, string NeedsItem) // any new TaskDetail with Knife will end up here
	{
		this.TaskDescription = TaskDescription;
		this.TaskDialog = TaskDialog;
		this.NeedsItem = NeedsItem;
	}
	public string GetTaskDescription()
	{
		return TaskDescription;
	}
	public string GetTaskDialog()
	{
		return TaskDialog;
	}
	public string ItemNeeded()
	{
		return NeedsItem;
	}
}