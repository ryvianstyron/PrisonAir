using UnityEngine;
using System.Collections;

// Class structure for holding string detail for phases
public class PhaseDetail 
{
	private string PhaseTitle;
	private string PhaseDescription; // What the player sees
	
	public PhaseDetail(string PhaseTitle, string PhaseDescription)
	{
		this.PhaseTitle = PhaseTitle;
		this.PhaseDescription = PhaseDescription;
	}
	public string GetPhaseTitle()
	{
		return PhaseTitle;
	}
	public string GetPhaseDescription()
	{
		return PhaseDescription;
	}
}