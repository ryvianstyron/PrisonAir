using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public static Dictionary<string, TaskDetail> StoryTasks;
	public static Dictionary<string, PhaseDetail> StoryPhases;
    public static Dictionary<Enums.Prisoner, List<string>> RandomGuyJokes;
	public static Inventory Inventory;
	public static LevelBuilder LevelBuilder;
    public static ObjectiveScreen ObjectiveScreen;
    public static LevelOverScreen LevelOverScreen;
    public static Score Score;
    public GameObject LevelOverPopup;

	public static TaskTracker TaskTracker;
    // Use this for initialization
	void Awake () 
	{
        Score = GameObject.Find("SCORE").GetComponent<Score>();
		Descriptions Descriptions = new Descriptions();
		StoryTasks = Descriptions.GetStoryTasks();
		StoryPhases = Descriptions.GetPhaseTitles();
        RandomGuyJokes = Descriptions.GetRandomGuyJokes();
        LevelOverScreen = LevelOverPopup.GetComponent<LevelOverScreen>();
		Inventory = new Inventory ();

        // TESTING ONLY
        Inventory.AddToInventory("knife");
        Inventory.AddToInventory("detergent");
        
        LevelBuilder = GameObject.Find("Camera").GetComponent<LevelBuilder>();
        ObjectiveScreen = GameObject.Find("Camera").GetComponent<ObjectiveScreen>();
		TaskTracker = GameObject.Find ("Camera").GetComponent<TaskTracker>();

        // TESTING ONLY
        //GetRandomJokeBasedOn(Enums.Prisoner.Fatty);
        //GetRandomJokeBasedOn(Enums.Prisoner.Midget);
        //GetRandomJokeBasedOn(Enums.Prisoner.Skinny);
        //GetRandomJokeBasedOn(Enums.Prisoner.Fatty);
        //GetRandomJokeBasedOn(Enums.Prisoner.Midget);
        //GetRandomJokeBasedOn(Enums.Prisoner.Skinny);
        //GetRandomJokeBasedOn(Enums.Prisoner.Fatty);
        //GetRandomJokeBasedOn(Enums.Prisoner.Midget);
        //GetRandomJokeBasedOn(Enums.Prisoner.Skinny);
        //GetRandomJokeBasedOn(Enums.Prisoner.Fatty);
        //GetRandomJokeBasedOn(Enums.Prisoner.Midget);
        //GetRandomJokeBasedOn(Enums.Prisoner.Skinny);
        //GetRandomJokeBasedOn(Enums.Prisoner.Fatty);
        //GetRandomJokeBasedOn(Enums.Prisoner.Midget);
        //GetRandomJokeBasedOn(Enums.Prisoner.Skinny);
        //GetRandomJokeBasedOn(Enums.Prisoner.Fatty);
        //GetRandomJokeBasedOn(Enums.Prisoner.Midget);
        //GetRandomJokeBasedOn(Enums.Prisoner.Skinny);
	}
    public static void SaveCherryPoppedPref(bool CherryPopped)
    {
        if (CherryPopped)
        {
            PlayerPrefs.SetString("CherryPopped", "T");
        }
        else
        {
            PlayerPrefs.SetString("CherryPopped", "F");
        }
    }
    public static bool IsCherryPopped()
    {
        string Cherry = PlayerPrefs.GetString("CherryPopped");
        if (Cherry.Equals("F"))
        {
            return false;
        }
        else if (Cherry.Equals("T"))
        {
            return true;
        }
        else return true; // if never been set before
    }
	public static string GetTaskDescription(int prison, int level, int phase, int order)
	{
		TaskDetail Found = null;
		string Label = "P" + prison + "_L" + level + "_PH" + phase + "_T" + order;
		StoryTasks.TryGetValue(Label, out Found);
		if (Found == null) 
		{
			return "Description Not Found";
		}
		else{return Found.GetTaskDescription();}
	}
    public static string GetTaskDialog(int prison, int level, int phase, int order)
    {
        TaskDetail Found = null;
        string Label = "P" + prison + "_L" + level + "_PH" + phase + "_T" + order;
        StoryTasks.TryGetValue(Label, out Found);
        if (Found == null)
        {
            return "Dialog Not Found";
        }
        else 
        { 
            return Found.GetTaskDialog(); 
        }
    }

	public static string GetItemNeededByTask(int prison, int level, int phase, int order)
	{
		TaskDetail Found = null;
		string Label = "P" + prison + "_L" + level + "_PH" + phase + "_T" + order;
		StoryTasks.TryGetValue(Label, out Found);
		if (Found != null)
		{
			return Found.ItemNeeded();
		}
		else return "Item Not Found";
	}
	public static string GetPhaseTitle(int prison, int level, int phase)
	{
		PhaseDetail Found = null;
		string Label = "P" + prison + "_L" + level + "_PH" + phase;
		StoryPhases.TryGetValue(Label, out Found);
		if (Found == null) 
		{
			return "Title Not Found";
		}
		else{return Found.GetPhaseTitle();}
	}
	public static int GetTotalPhasesInLevel(int Prison, int Level)
	{
		string Label = "P" + Prison + "_" + "L" + Level;
		return PlayerPrefs.GetInt (Label, 0);
	}
	public static int GetTotalTasksInPhase(int Prison, int Level, int Phase)
	{
		string Label = "P" + Prison + "_" + "L" + Level + "_" + "PH" + Phase;
		return PlayerPrefs.GetInt (Label, 0);
	}
	public void DeleteAllPlayerPrefs()
	{
		Debug.Log("DeleteAllPlayerPrefs");
		PlayerPrefs.DeleteAll();
	}
    public string GetRandomJokeBasedOn(Enums.Prisoner Prisoner)
    {
        int PositionToReturn = Random.Range(1,10);
        List<string> Joke;
		RandomGuyJokes.TryGetValue(Prisoner, out Joke);
        if(Joke != null && Joke.Count == 10)
        {
            Debug.Log("Joke for " + Prisoner.ToString() + " = " + Joke[PositionToReturn]);
            return Joke[PositionToReturn];
        }
        return "JokeNotFound";
    }
}