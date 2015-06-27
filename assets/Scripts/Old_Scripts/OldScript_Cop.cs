using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Cop : MonoBehaviour 
{
    int TotalScoreAchieved;
    //int SpaceCount = 0;

    //public GameObject SpawnPoint;

    const int FAT_PRISONER = 0;
    const int SKINY_PRISONER = 1;
    const int MIDGET_PRISONER = 2;

    List<GameObject> CriminalsList;

  	public GameObject FatCriminal;
    public GameObject SkinnyCriminal;
    public GameObject MidgetCriminal;

	private int numberOfPrisonersfired;


	void Awake () 
    {
        TotalScoreAchieved = 0;
        CriminalsList = new List<GameObject>();

        for(int i = 0; i < 7; i++) // added 5 random prisoners
        {
            GameObject Prisoner = null;
            int PrisonerType = (Random.Range(0, 3));
            switch(PrisonerType)
            {
                case FAT_PRISONER:
                    //Debug.Log("Fat");
                    //Prisoner = (GameObject)Instantiate(FatCriminal, new Vector3(3, 20, 0), Quaternion.identity);
					Prisoner = FatCriminal;
                    break;
                case SKINY_PRISONER:
                    //Debug.Log("Skinny");
                    //Prisoner = (GameObject)Instantiate(SkinnyCriminal, new Vector3(3, 20, 0), Quaternion.identity);
					Prisoner = SkinnyCriminal;
                    break; 
                case MIDGET_PRISONER:
                    //Debug.Log("Midget");
                    //Prisoner = (GameObject)Instantiate(MidgetCriminal, new Vector3(3, 20, 0), Quaternion.identity);
					Prisoner = MidgetCriminal;
                    break;
            }

			//Prisoner = MidgetCriminal;
            AddPrisoner(Prisoner);
        }
	}
    void AddPrisoner(GameObject Prisoner)
    {
        if(Prisoner != null)
        {
            CriminalsList.Add(Prisoner);
        }
    }
	public void SetTotalScore(int Score)
	{
		TotalScoreAchieved = Score;
	}
    public void ApplyScoreToCop(int Score)
    {
        TotalScoreAchieved += Score;
    }
    public int GetTotalScore()
    {
        //Debug.Log("Gets Total Score as : " + TotalScoreAchieved);
        return TotalScoreAchieved;
    }

	public GameObject GetNextPrisoner()
	{

		int IndexToRemove = CriminalsList.Count -1;
		GameObject prisonerToReturn = CriminalsList[IndexToRemove];
		CriminalsList.RemoveAt(IndexToRemove);
		//numberOfPrisonersfired ++;
		return prisonerToReturn;
	}

	public string GetNextPrisonerName()
	{
		int IndexToRemove = CriminalsList.Count -1;
		if(IndexToRemove != -1)
		{
			string prisonerToReturnName = CriminalsList[IndexToRemove].name;
			return prisonerToReturnName;
		}
		else return "oup";
	
	}
}
