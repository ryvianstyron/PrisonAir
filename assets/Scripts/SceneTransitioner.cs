using UnityEngine;
using System.Collections;

public class SceneTransitioner : MonoBehaviour 
{
    public void TapToPlay()
    {
        Application.LoadLevel("HomeScreen");
    }
    public void Play()
    {
        Application.LoadLevel("PrisonSelect");
    }
    public void About()
    {
        Application.LoadLevel("AboutScreen");
    }
    public void Settings()
    {
        Application.LoadLevel("SettingsScreen");
    }
    public void GoToLevelSelect()
    {
        Application.LoadLevel("LevelSelect");
    }
    public void Back(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
    public void NavigateToScene(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
}
