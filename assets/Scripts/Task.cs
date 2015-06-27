using UnityEngine;
using System.Collections.Generic;
public class Task
{
	private int Prison;
	private int Level;
	private int Phase;
	private int Order;
    private string Label;

	private string Description;
    private string Dialog;
	private bool IsCompleted = false;
	private string NeedsItem;

	// Cascading Constructors
	public Task(int Prison, int Level, int Phase, int Order )
	{
		this.NeedsItem = GameManager.GetItemNeededByTask (Prison, Level, Phase, Order);
		this.IsCompleted = LevelTracker.CheckIfTaskIsCompleted(Prison, Level, Phase, Order);
		this.Description = GameManager.GetTaskDescription(Prison, Level, Phase, Order);
        this.Dialog = GameManager.GetTaskDialog(Prison, Level, Phase, Order);
		this.Prison = Prison;
		this.Level = Level;
		this.Phase = Phase;
		this.Order = Order;
        this.Label = "P" + Prison + "_" + "L" + Level + "_" + "PH" + Phase + "_" + "T" + Order;
		LevelTracker.TrackTaskProgress (this);
	}
    public string GetLabel()
    {
        return Label;
    }
	public string GetItemNeeded()
	{
		return NeedsItem;
	}
	public bool IsTaskCompleted()
	{
		return IsCompleted;
	}
	public string GetDescription()
	{
		return Description;
	}
    public string GetDialog()
    {
        return Dialog;
    }
	public int GetOrder()
	{
		return Order;
	}
	public int GetPrison()
	{
		return Prison;
	}
	public int GetLevel()
	{
		return Level;
	}
	public int GetPhase()
	{
		return Phase;
	}
	public void SetTaskCompleted()
	{
        IsCompleted = true;
        LevelTracker.TrackTaskProgress(this);
		GameManager.ObjectiveScreen.UpdateCurrentTaskCount(GameManager.ObjectiveScreen.GetCurrentTaskCount() + 1);
		GameManager.ObjectiveScreen.ShouldWeChangePhase();
        GameManager.LevelBuilder.BuildAndLoadPrison();
	}
	public override string ToString() 
	{
		string TaskInfo = 
			"P" + Prison + "_" +
			"L" + Level + "_" + 
			"PH" + Phase + "_" + 
			"T" + Order + 
            ": Item Needed=" + NeedsItem + 
            " , IsCompleted= " + IsCompleted.ToString () + 
            " , Des: " + Description;
		return TaskInfo;
	}
}