using UnityEngine;
using System.Collections;

public class LevelSelectController : MonoBehaviour 
{
    public void LoadPrisonLevel(string PrisonLevel)
    {
        Debug.Log(PrisonLevel);
        Application.LoadLevel(PrisonLevel);
    }
}
