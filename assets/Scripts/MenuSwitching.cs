using UnityEngine;
using System.Collections;

public class MenuSwitching : MonoBehaviour {

	public void MenuSwitch(string level)
	{
		Application.LoadLevel(level);
	}
}
