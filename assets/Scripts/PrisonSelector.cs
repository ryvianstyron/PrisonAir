using UnityEngine;
using System.Collections;

public class PrisonSelector : MonoBehaviour 
{
    public void LoadLevelSelectionScreen()
    {
        Application.LoadLevel("LevelSelect");
    }
}
