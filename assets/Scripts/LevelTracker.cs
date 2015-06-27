using UnityEngine;
using System.Collections.Generic;

public class LevelTracker : MonoBehaviour 
{
	// completed task format: P1_L1_PH1_T1, 1
	// incompleted task format : P1_L1_PH1_T1, 0
    public static void SaveNumberOfTasksInPhase(string PhaseLabel, int NumberOfTasks)
    {
        PlayerPrefs.SetInt(PhaseLabel, NumberOfTasks);
    }
    public static int GetNumberOfTasksInPhase(string PhaseLabel)
    {
        int TaskNumber = PlayerPrefs.GetInt(PhaseLabel);
        //Debug.Log(PhaseLabel + "got:" + TaskNumber);
        return TaskNumber;
    }
	/*This method will automatically save a Tasks progress in PlayerPrefs - is used for when the task is completed or incomplete*/
	public static void TrackTaskProgress(Task TaskInProgress)
	{
		//get level/prison/task from level builder
		//task completed
		string Label = "P" + TaskInProgress.GetPrison() + "_" + 
						"L" + TaskInProgress.GetLevel() + "_" +
						"PH" + TaskInProgress.GetPhase() + "_" +
						"T" + TaskInProgress.GetOrder();
		int Progress = TaskInProgress.IsTaskCompleted() ? 1 : 0;
		PlayerPrefs.GetInt (Label);
		PlayerPrefs.SetInt(Label, Progress);
	}

    public static void TrackLevelProgress(Level LevelInProgress)
    {
        string Label = "P" + LevelInProgress.GetPrisonNumber() + "_" +
                       "L" + LevelInProgress.GetLevelNumber();
        int Progress = LevelInProgress.IsLevelCompleted() ? 1 : 0;
        PlayerPrefs.GetInt(Label);
        PlayerPrefs.SetInt(Label, Progress);

    }
    public static void TrackPrisonProgress(Prison PrisonInProgress)
    {
        string Label = "P" + PrisonInProgress.GetPrisonNumber();
        int Progress = PrisonInProgress.IsCompleted() ? 1 : 0;
        PlayerPrefs.GetInt(Label);
        PlayerPrefs.SetInt(Label, Progress);
    }
	public static void TrackPhaseProgress(Phase PhaseInProgress)
	{
        string Label = "P" + PhaseInProgress.GetPrison() + "_" +
                        "L" + PhaseInProgress.GetLevel() + "_" +
                        "PH" + PhaseInProgress.GetPhase();

		int Progress = PhaseInProgress.IsPhaseCompleted() ? 1 : 0;
        Debug.Log("LevelTracker.cs -> Phase  Being Saved:" + Label + " as " + Progress);
		PlayerPrefs.GetInt (Label);
		PlayerPrefs.SetInt(Label, Progress);
	}

	public static bool CheckIfTaskIsCompleted(int Prison, int Level, int Phase, int Order)
	{
		string Label = 	"P" + Prison + "_" + 
						"L" + Level + "_" +
						"PH" + Phase + "_" +
						"T" + Order;
		int Progress = PlayerPrefs.GetInt (Label, -1);
		if (Progress == 0 || Progress == -1) 
		{
			return false;
		} 
		else
			return true;
	}
    public static bool CheckIfPhaseIsCompleted(int Prison, int Level, int Phase)
    {
        string Label = "P" + Prison + "_" +
                        "L" + Level + "_" +
                        "PH" + Phase;
        int Progress = PlayerPrefs.GetInt(Label, -1);
        if (Progress == 0 || Progress == -1)
        {
            return false;
        }
        else return true;
    }
    public static bool CheckIfLevelIsCompleted(int Prison, int Level)
    {
        string Label = "P" + Prison + "_" +
                       "L" + Level;
        int Progress = PlayerPrefs.GetInt(Label, -1);
        if (Progress == 0 || Progress == -1)
        {
            return false;
        }
        else return true;
    }
    public static bool CheckIfPrisonIsCompleted(int Prison)
    {
        string Label = "P" + Prison;
        int Progress = PlayerPrefs.GetInt(Label, -1);
        if (Progress == 0 || Progress == -1)
        {
            return false;
        }
        else return true;
    }
}