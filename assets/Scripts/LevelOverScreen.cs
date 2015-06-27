using UnityEngine;
using System.Collections;

public class LevelOverScreen : MonoBehaviour 
{
    public bool LevelOverScreenShowing;
	void Start () 
    {
        gameObject.SetActive(false);
	}
	void Update () 
    {
	}
    public void SetVisibility(bool Visible)
    {
        Debug.Log("Setting Visibility to:" + Visible);
        LevelOverScreenShowing = Visible;
        gameObject.SetActive(LevelOverScreenShowing);
    }
    public bool IsVisible()
    {
        return LevelOverScreenShowing;
    }
    public void NavigateToScene(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
}
