using UnityEngine;
using System.Collections.Generic;

public class Level 
{
    private bool IsCompleted;
    private int PrisonNumber;
	private int LevelNumber;
	private List<Phase> Objectives;
	
	public Level(int PrisonNumber, int LevelNumber, List<Phase> Objectives)
	{
        this.IsCompleted = LevelTracker.CheckIfLevelIsCompleted(PrisonNumber , LevelNumber);
        this.PrisonNumber = PrisonNumber;
		this.LevelNumber = LevelNumber;
		this.Objectives = Objectives;
	}
	public int GetLevelNumber()
	{
		return LevelNumber;
	}
    public int GetPrisonNumber()
    {
        return PrisonNumber;
    }
    public bool IsLevelCompleted()
    {
        return IsCompleted;
    }
	public List<Phase> GetLevelObjectives()
	{
		return Objectives;
	}
    public void SetLevelCompleted()
    {
        IsCompleted = true;
        LevelTracker.TrackLevelProgress(this);
        LevelTracker.SaveLevelScoreToCache(this, GameManager.Score.GetTotalScore());
        Debug.Log("Level " + LevelNumber + "in Prison " + PrisonNumber + " Completed");
        //GameManager.ObjectiveScreen.up(GameManager.ObjectiveScreen.GetCompletedLevelCount() + 1);
        //GameManager.ObjectiveScreen.ShouldWeChangePrison();
        GameManager.LevelBuilder.BuildAndLoadPrison();
        //Debug.Log(GameManager.LevelBuilder.GetCurrentLevel().ToString());
    }
	public override string ToString()
	{
		string LevelInfo = "\n";
		LevelInfo += "L" + LevelNumber + ":" + IsLevelCompleted() + "\n";
		foreach (Phase P in Objectives) 
		{
			LevelInfo += "\n" + P.ToString();
		}
		return LevelInfo;
	}
}
