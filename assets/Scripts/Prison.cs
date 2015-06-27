using UnityEngine;
using System.Collections.Generic;

public class Prison  
{
    private bool Completed;
	private int PrisonNumber;
	private List<Level> Levels;
	public Prison(int PrisonNumber, List<Level> Levels)
	{
		this.Levels = Levels;
		this.PrisonNumber = PrisonNumber;
        this.Completed = LevelTracker.CheckIfPrisonIsCompleted(PrisonNumber);
	}
	public List<Level> GetLevels()
	{
		return Levels;
	}
	public int GetPrisonNumber()
	{
		return PrisonNumber;
	}
    public void SetPrisonCompleted()
    {
        Completed = true;
        LevelTracker.TrackPrisonProgress(this);
        Debug.Log("Prison " + PrisonNumber + " Completed");
        GameManager.LevelBuilder.BuildAndLoadPrison();
        Debug.Log(GameManager.LevelBuilder.GetCurrentPrison().ToString());
    }
    public bool IsCompleted()
    {
        return Completed;
    }
	public override string ToString()
	{
		string PrisonInfo = "\n";
		PrisonInfo += 
			"P" + PrisonNumber + ":";
		foreach (Level L in Levels) 
		{
			PrisonInfo += "\n" + L.ToString();
		}
		return PrisonInfo;
	}
}