using UnityEngine;
using System.Collections.Generic;

public class Phase 	
{
	private int Prison;
	private int Level;
	private int PhaseNumber;
	private string Title;
	private List<Task> Tasks;
	private bool IsCompleted = false;

	public Phase(int Prison, int Level, int PhaseNumber, List<Task> TasksInPhase)
	{
		this.Title = GameManager.GetPhaseTitle(Prison, Level, PhaseNumber); // Need to find titles from Descriptions
        this.IsCompleted = LevelTracker.CheckIfPhaseIsCompleted(Prison, Level, PhaseNumber);
		this.Tasks = TasksInPhase;
		this.Prison = Prison;
		this.Level = Level;
		this.PhaseNumber = PhaseNumber;
        // When a phase is created you want to immediately save the number of tasks for that specific phase:
        LevelTracker.SaveNumberOfTasksInPhase("P" + Prison + "_L" + Level + "_PH" + PhaseNumber + "_TN", Tasks.Count);
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
        return PhaseNumber;
    }
    public int GetNumberOfTasks()
    {
        return Tasks.Count;
    }
    public string GetObjectiveTitle()
	{
		return Title;
	}
	public List<Task> GetTasks()
	{
		return Tasks;
	}
	public void SetPhaseCompleted()
	{
        IsCompleted = true;
        LevelTracker.TrackPhaseProgress(this);
        Debug.Log("Phase Completed: " + GetObjectiveTitle());
		GameManager.ObjectiveScreen.UpdateCurrentPhaseCount(GameManager.ObjectiveScreen.GetCurrentPhaseCount() + 1);
        GameManager.ObjectiveScreen.ShouldWeChangeLevel();
        GameManager.LevelBuilder.BuildAndLoadPrison();
	}
	public bool IsPhaseCompleted()
	{
		return IsCompleted;
	}
	public override string ToString()
	{
		string PhaseInfo = "\n";
        PhaseInfo +=
            "P" + Prison +
            "_L" + Level +
            "_PH" + PhaseNumber + "-Title:" + Title + " Completed? : " + IsCompleted;
		foreach (Task T in Tasks) 
		{
			PhaseInfo += "\n" + T.ToString();
		}
		return PhaseInfo;
	}
}
