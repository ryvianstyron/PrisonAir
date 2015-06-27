using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour 
{
    public void Play()
    {
        Application.LoadLevel("PrisonSelect");
    }
}
