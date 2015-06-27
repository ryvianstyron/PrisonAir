using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class ObjectiveScreen : MonoBehaviour
{
    public Text TitleOfPhase;
    public GameObject ObjectiveItemHolder;
    public GameObject MainCamera;
    public GameObject PreFab_ObjectiveItem;

    private int CurrentTaskCount;
    private int CurrentPhaseCount;
    
    private bool ShowingObjectiveScreen;

    // These variables should get reset very often
    Level CurrentLevel;
    List<Phase> PhasesInCurrentLevel;
    List<Task> CurrentPhaseTasks;

    public void Start()
    {
        ShowingObjectiveScreen = false;
    }
    public void ResetAll() // purpose - reset the information required "IN - GAME" - after a buildandload
    {
        CurrentTaskCount = 0;
        CurrentPhaseCount = 0;

        FindCurrentIncompleteLevel();
        FindCurrentIncompletePhase(); 

        ClearObjectiveItemScreen();

        // TO RESET CURRENT PHASE COUNT
        CurrentLevel = GameManager.LevelBuilder.GetCurrentLevel();
        PhasesInCurrentLevel = CurrentLevel.GetLevelObjectives();
        foreach (Phase Phase in PhasesInCurrentLevel)
        {
            if (Phase.IsPhaseCompleted())
            {
                CurrentPhaseCount++;
            }
        }
        // TO RESET CURRENT TASK COUNT
        if(GameManager.LevelBuilder.GetCurrentPhase() != null)
        {
            Debug.Log(GameManager.LevelBuilder.GetCurrentPhase().GetObjectiveTitle());
            CurrentPhaseTasks = GameManager.LevelBuilder.GetCurrentPhase().GetTasks();
            foreach (Task Task in CurrentPhaseTasks)
            {
                if (Task.IsTaskCompleted())
                {
                    CurrentTaskCount++;
                }
            }
        }
        Debug.Log("CurrentPhaseCount= " + CurrentPhaseCount);
        Debug.Log("CurrentTaskCount= " + CurrentTaskCount);
    }
    public void DisplayTaskList()
    {
        Debug.Log("DisplayTaskList");
        ResetAll();
        if(ShowingObjectiveScreen)
        {
            ShowingObjectiveScreen = false;
        }
        else
        {
            ShowingObjectiveScreen = true;
            TitleOfPhase.text = GameManager.LevelBuilder.GetCurrentPhase().GetObjectiveTitle();
            
            for (int i = 0; i < CurrentPhaseTasks.Count; i++)
            {
                ObjectiveItem ObjectiveItem = PreFab_ObjectiveItem.GetComponent<ObjectiveItem>();
                ObjectiveItem.SetObjectiveText(CurrentPhaseTasks[i].GetDescription());
                ObjectiveItem.SetObjectiveDescription(CurrentPhaseTasks[i].GetDialog());
                GameObject OI = (GameObject)Instantiate(PreFab_ObjectiveItem, transform.position, Quaternion.identity);
                OI.transform.SetParent(ObjectiveItemHolder.transform);
                if (CurrentPhaseTasks[i].IsTaskCompleted())
                {
                    Debug.Log(CurrentPhaseTasks[i].GetDescription() + " IS COMPLETED - CROSS OUT!");
                    ObjectiveItem.ShowLine();
                }
            }
        }
    }
    public void ClearObjectiveItemScreen()
    {
        List<GameObject> Children = new List<GameObject>();
        foreach (Transform Child in (ObjectiveItemHolder.GetComponentInChildren<Transform>()))
        {
            Children.Add(Child.gameObject);
        }
        foreach (GameObject Child in Children)
        {
            Destroy(Child);
        }
    }
    public void FindCurrentIncompletePhase()
    {
        List<Phase> PhaseList = GameManager.LevelBuilder.GetCurrentLevel().GetLevelObjectives();
        for (int i = 0; i < PhaseList.Count; i++)
        {
            if (!PhaseList[i].IsPhaseCompleted())
            {
                GameManager.LevelBuilder.SetCurrentPhase(PhaseList[i]);
                break;
            }
        }
    }
    public void FindCurrentIncompleteLevel()
    {
        List<Level> LevelList = GameManager.LevelBuilder.GetCurrentPrison().GetLevels();
        for(int i = 0; i < LevelList.Count; i++)
        {
            if(!LevelList[i].IsLevelCompleted())
            {
                GameManager.LevelBuilder.SetCurrentLevel(LevelList[i]);
                Debug.Log("ObjectiveScreen.cs: " + LevelList[i].GetLevelNumber() + " Is the current Level now");
                break;
            }
        }
    }
    /*
     * WILL NEED TO BE USED AS A CHECK EVERYTIME A LEVEL IS COMPLETED ONLY
     * public void ShouldWeChangePrison()
    {
        Debug.Log("ShouldWeChangePrison");
        FindCurrentIncompletePrison();
        if (GameManager.LevelBuilder.GetCurrentPrison() == null)
        {
            Debug.LogError("ObjectiveScreen: CurrenPrison is returning NULL");
            return;
        }
        int CurrentLevelCount = GameManager.LevelBuilder.GetCurrentPrison().GetLevels().Count;
        if (CurrentLevelCount == CompletedLevelCount)
        {
            GameManager.LevelBuilder.GetCurrentPrison().SetPrisonCompleted();
            FindCurrentIncompletePrison();
            CompletedLevelCount = 0;
        }
    }*/
    public void ShouldWeChangeLevel()
    {
        FindCurrentIncompleteLevel();
        if(GameManager.LevelBuilder.GetCurrentLevel() == null)
        {
            Debug.LogError("ObjectiveScreen: CurrentLevel is returning NULL");
            return;
        }
        int PhaseCountToCompleteLevel = GameManager.LevelBuilder.GetCurrentLevel().GetLevelObjectives().Count;
        Debug.Log("PhaseCountToCompleteLevel= " + PhaseCountToCompleteLevel + " CurrentPhaseCount = " + CurrentPhaseCount);
        if (CurrentPhaseCount == PhaseCountToCompleteLevel)
        {
            Debug.Log("Setting Level To Completed!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            GameManager.LevelBuilder.GetCurrentLevel().SetLevelCompleted();
            FindCurrentIncompleteLevel();
            CurrentPhaseCount = 0;

            // Show Level Over Screen
            GameManager.LevelOverScreen.SetVisibility(true);
        }
    }
    public void ShouldWeChangePhase()
    {
        FindCurrentIncompletePhase();
        if (GameManager.LevelBuilder.GetCurrentPhase() == null)
        {
            Debug.LogError("ObjectiveScreen: CurrentPhase is returning NULL");
            return;
        }
        int TaskCountToCompletePhase = GameManager.LevelBuilder.GetCurrentPhase().GetTasks().Count;
		if (CurrentTaskCount == TaskCountToCompletePhase)
        {
            GameManager.LevelBuilder.GetCurrentPhase().SetPhaseCompleted();
			CurrentTaskCount = 0;
            FindCurrentIncompletePhase();
        }
    }
    public void UpdateCurrentTaskCount(int Count)
    {
        CurrentTaskCount = Count;
    }
    public int GetCurrentTaskCount()
    {
        return CurrentTaskCount;
    }
    public void UpdateCurrentPhaseCount(int Count)
    {
        CurrentPhaseCount = Count;
    }
    public int GetCurrentPhaseCount()
    {
        return CurrentPhaseCount;
    }
}