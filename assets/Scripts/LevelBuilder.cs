using UnityEngine;
using System.Collections.Generic;
public class LevelBuilder : MonoBehaviour
{
	private int PrisonSelected = 1;
    private int LevelSelected = 1;

	private Level CurrentLevel;
	private Phase CurrentObjective;
	private Task CurrentTask;
	private Phase CurrentPhase;
    private Prison CurrentPrison;

    private List<Prison> PrisonAir;
	void Start () 
	{
        if (GameManager.IsCherryPopped())
		{
			//List<Prison> PrisonAir = new List<Prison>();
            PrisonAir = new List<Prison>();

			List<Level> Prison1Levels = new List<Level> ();

			List<Phase> Prison1Level1Phases = new List<Phase>();
			List<Phase> Prison1Level2Phases = new List <Phase> ();

			List<Task> TheTourTasks = new List<Task>();
			List<Task> MakingFriendsTasks = new List<Task>();
			List<Task> LearningTheRopesTasks = new List<Task>();
			List<Task> MamasBoyTasks = new List<Task>();

			List<Task> KillBillTasks = new List<Task> ();

			CurrentTask = new Task (1,1,1,1);
			TheTourTasks.Add(CurrentTask);
			TheTourTasks.Add(new Task(1, 1, 1, 2));
			TheTourTasks.Add(new Task(1, 1, 1, 3));
			TheTourTasks.Add(new Task(1, 1, 1, 4));
			Phase P1_L1_PH1 = new Phase(1, 1, 1, TheTourTasks);

			CurrentPhase = P1_L1_PH1;

			MakingFriendsTasks.Add(new Task(1, 1, 2, 1));
			MakingFriendsTasks.Add(new Task(1, 1, 2, 2));
			MakingFriendsTasks.Add(new Task(1, 1, 2, 3));
			Phase P1_L1_PH2 = new Phase(1, 1, 2, MakingFriendsTasks);
			
			LearningTheRopesTasks.Add(new Task(1, 1, 3, 1));
			LearningTheRopesTasks.Add(new Task(1, 1, 3, 2));
			LearningTheRopesTasks.Add(new Task(1, 1, 3, 3));
			LearningTheRopesTasks.Add(new Task(1, 1, 3, 4));
			Phase P1_L1_PH3 = new Phase(1, 1, 3, LearningTheRopesTasks);
			
			MamasBoyTasks.Add(new Task(1, 1, 4, 1));
			MamasBoyTasks.Add(new Task(1, 1, 4, 2));
			MamasBoyTasks.Add(new Task(1, 1, 4, 3));
			Phase P1_L1_PH4 = new Phase(1, 1, 4, MamasBoyTasks);
			
			Prison1Level1Phases.Add(P1_L1_PH1);
			Prison1Level1Phases.Add(P1_L1_PH2);
			Prison1Level1Phases.Add(P1_L1_PH3);
			Prison1Level1Phases.Add(P1_L1_PH4);
			
			Level Prison1Level1 = new Level(1, 1, Prison1Level1Phases);
			CurrentLevel = Prison1Level1;
			
			KillBillTasks.Add (new Task (1,2,1,1));
			KillBillTasks.Add (new Task (1,2,1,2));
			KillBillTasks.Add (new Task (1,2,1,3));
			KillBillTasks.Add (new Task (1,2,1,4));
			
			Phase P1_L2_PH1 = new Phase (1, 2, 1, KillBillTasks);
			
			Prison1Level2Phases.Add (P1_L2_PH1);
			
			Level Prison1Level2 = new Level (1, 2, Prison1Level2Phases);
			
			Prison1Levels.Add (Prison1Level1);
			Prison1Levels.Add (Prison1Level2);

			Prison Prison1 = new Prison (1, Prison1Levels);
            CurrentPrison = Prison1;
			PrisonAir.Add (Prison1);
            GameManager.SaveCherryPoppedPref(false);
            GameManager.TaskTracker.Initialize();
		} 
		else 
		{
			// Load relevant Prison & Level needed ONLY - from PlayerPrefs
			BuildAndLoadPrison();
		}        
	}
	// Loads the entire Prison with a certain level
	public void BuildAndLoadPrison()
	{
        Debug.Log("BuildAndLoadPrison");
		string PrisonLevelLabel = 	"P" + PrisonSelected + "_L" + LevelSelected + "_";
		List<Phase> LevelPhases = new List<Phase>();
		bool FoundCurrentTask = false;
		for(int i = 1; i < 5; i++) // 4 phases in each level
		{
			int taskInPhase = LevelTracker.GetNumberOfTasksInPhase (PrisonLevelLabel + "PH" + i + "_TN"); // Get # tasks in phase
			List<Task> Tasks = new List<Task>();
			for (int j = 1; j < taskInPhase + 1; j++)
			{
				Task TaskToCheck = new Task(PrisonSelected, LevelSelected, i, j);
				if(!TaskToCheck.IsTaskCompleted() && !FoundCurrentTask)
				{
					CurrentTask = TaskToCheck;
					FoundCurrentTask = true;
				}
                Tasks.Add(TaskToCheck);
			}
			LevelPhases.Add (new Phase(PrisonSelected, LevelSelected, i, Tasks));
		}
		Level Level = new Level(PrisonSelected, LevelSelected, LevelPhases);
		CurrentLevel = Level;
        List<Level> Levels = new List<Level>();
		Prison Prison = new Prison(PrisonSelected, Levels);
        CurrentPrison = Prison;

        GameManager.ObjectiveScreen.ResetAll();

        // Signal the Task Tracker that everything is ready for action
        GameManager.TaskTracker.Initialize();
	}
	public Task GetCurrentTask()
	{
		return CurrentTask;
	}
	public Level GetCurrentLevel()
	{
		return CurrentLevel;
	}
    public Phase GetCurrentPhase()
    {
        return CurrentPhase;
    }
    public Prison GetCurrentPrison()
    {
        return CurrentPrison;
    }
    public void SetCurrentPhase(Phase Current)
    {
        CurrentPhase = Current;
    }
    public void SetCurrentLevel(Level Current)
    {
        CurrentLevel = Current;
    }
	public override string ToString ()
	{
		return ("ToString(): LevelBuilder.cs");
	}
}