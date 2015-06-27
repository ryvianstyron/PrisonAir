using UnityEngine;
using System.Collections.Generic;

public class Descriptions
{
	// Template is: (Label, Detail)

	Dictionary<string,TaskDetail> StoryTasks = new Dictionary<string,TaskDetail>();
	Dictionary<string, PhaseDetail> StoryPhases = new Dictionary<string, PhaseDetail>();
    Dictionary<Enums.Prisoner, List<string>> RandomGuyJokes = new Dictionary<Enums.Prisoner, List<string>>();

	//List<TaskDetail> StoryTasks = new List<TaskDetail>();
	public Descriptions()
	{
		StoryTasks.Add("P1_L1_PH1_T1", new TaskDetail("Go to Cells","I've got a lovely bunch of", "knife"));
		StoryTasks.Add("P1_L1_PH1_T2", new TaskDetail("Go to Kitchen","Coconuts dobee dobee, there", "detergent"));
		StoryTasks.Add("P1_L1_PH1_T3", new TaskDetail("Go to REC Area","they are standing in a row"));
		StoryTasks.Add("P1_L1_PH1_T4", new TaskDetail("Go to Warden's Office","BIG ONES! Small ones!"));

		StoryTasks.Add("P1_L1_PH2_T1", new TaskDetail("Go to Cafe", ""));
		StoryTasks.Add("P1_L1_PH2_T2", new TaskDetail("Go to John's Cell", ""));
		StoryTasks.Add("P1_L1_PH2_T3", new TaskDetail("Return to Billy", ""));
		
		StoryTasks.Add("P1_L1_PH3_T1", new TaskDetail("Workout in REC Area",""));
		StoryTasks.Add("P1_L1_PH3_T2", new TaskDetail("Go to Showers", ""));
		StoryTasks.Add("P1_L1_PH3_T3", new TaskDetail("Go collect item",""));
		StoryTasks.Add("P1_L1_PH3_T4", new TaskDetail("Give item to",""));
		
		StoryTasks.Add("P1_L1_PH4_T1", new TaskDetail("Go to the Foyer - Meet Mom",""));
		StoryTasks.Add("P1_L1_PH4_T2", new TaskDetail("Go back to cells_Cookies stolen",""));
		StoryTasks.Add("P1_L1_PH4_T3", new TaskDetail("Go fight for cookies_maybe find a weapon",""));

		StoryTasks.Add ("P1_L2_PH1_T1", new TaskDetail("Get Knife",""));
		StoryTasks.Add ("P1_L2_PH1_T2", new TaskDetail("Go to cells","", "Knife")); 
		StoryTasks.Add ("P1_L2_PH1_T3", new TaskDetail("Shank someone","", "Knife")); 
		StoryTasks.Add ("P1_L2_PH1_T4", new TaskDetail("Discard Knife","", "Knife"));

        StoryPhases.Add("P1_L1_PH1", new PhaseDetail("The Tour", ""));
        StoryPhases.Add("P1_L1_PH2", new PhaseDetail("Making Friends", ""));
		StoryPhases.Add("P1_L1_PH3", new PhaseDetail("Learning The Ropes",""));
		StoryPhases.Add("P1_L1_PH4", new PhaseDetail("Mama's Boy",""));
        
        //StoryPhases.Add("P1_L2_PH1", new PhaseDetail("Kill Bill", ""));	

        List<string> MidgetJokes = new List<string>();
        List<string> FattyJokes = new List<string>();
        List<string> SkinnyJokes = new List<string>();

        MidgetJokes.Add("MidgetJoke1");
        MidgetJokes.Add("MidgetJoke2");
        MidgetJokes.Add("MidgetJoke3");
        MidgetJokes.Add("MidgetJoke4");
        MidgetJokes.Add("MidgetJoke5");
        MidgetJokes.Add("MidgetJoke6");
        MidgetJokes.Add("MidgetJoke7");
        MidgetJokes.Add("MidgetJoke8");
        MidgetJokes.Add("MidgetJoke9");
        MidgetJokes.Add("MidgetJoke10");

        SkinnyJokes.Add("SkinnyJoke1");
        SkinnyJokes.Add("SkinnyJoke2");
        SkinnyJokes.Add("SkinnyJoke3");
        SkinnyJokes.Add("SkinnyJoke4");
        SkinnyJokes.Add("SkinnyJoke5");
        SkinnyJokes.Add("SkinnyJoke6");
        SkinnyJokes.Add("SkinnyJoke7");
        SkinnyJokes.Add("SkinnyJoke8");
        SkinnyJokes.Add("SkinnyJoke9");
        SkinnyJokes.Add("SkinnyJoke10");

        FattyJokes.Add("FattyJokes1");
        FattyJokes.Add("FattyJokes2");
        FattyJokes.Add("FattyJokes3");
        FattyJokes.Add("FattyJokes4");
        FattyJokes.Add("FattyJokes5");
        FattyJokes.Add("FattyJokes6");
        FattyJokes.Add("FattyJokes7");
        FattyJokes.Add("FattyJokes8");
        FattyJokes.Add("FattyJokes9");
        FattyJokes.Add("FattyJokes10");

        RandomGuyJokes.Add(Enums.Prisoner.Midget, MidgetJokes);
        RandomGuyJokes.Add(Enums.Prisoner.Skinny, SkinnyJokes);
        RandomGuyJokes.Add(Enums.Prisoner.Fatty, FattyJokes);
	}
	public Dictionary<string, TaskDetail> GetStoryTasks()
	{
		return StoryTasks;
	}
	public Dictionary<string, PhaseDetail> GetPhaseTitles()
	{
		return StoryPhases;
	}
    public Dictionary<Enums.Prisoner, List<string>> GetRandomGuyJokes()
    {
        return RandomGuyJokes;
    }
}
