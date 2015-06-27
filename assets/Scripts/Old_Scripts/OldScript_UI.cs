using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour 
{
	public int SpacePressedCount = 0;
	
	public Image PowerFiller;
	public Image VelocityFiller;

	public static float MaxPower;

	public static float TTMaxVelocity = 700.0f;
	public static float TTMaxPower = 700.0f;

	public static float MMMaxVelocity = 750.0f;
	public static float MMMaxPower = 800.0f;

	public static float FJMaxVelocity = 850.0f;
	public static float FJMaxPower = 850.0f;
	
	public static float PowerValue;
	public static float VelocityValue;

	public Text CopScore;
	public GameObject Copper;
	public Text nextPrisonerInlist;
	public static int totalScoreAcheived;
	Cop CopSetup;
	Criminal crimcrim;
	public bool resetBarAndCanFire = true;
	
	public bool PlayPowerBarFill = true;
	public bool PlayVelocityBarFill = true;
	
	private CatapultArm CatapultArmScript;

	public Text Hit1Text;
	public Text Hit2Text;
	public Text Hit3Text;
	public Text Hit4Text;

	public Image Hit1;
	public Image Hit2;
	public Image Hit3;
	public Image Hit4;
	private bool SpaceButtonClicked = false;
	//public Image instructions;
	//public float instructionsTimer = 5.0f;

	void Start () 
	{
		Hit1Text.enabled = true;
		Hit2Text.enabled = true;
		Hit3Text.enabled = true;
		Hit4Text.enabled = true;

		CopSetup = (Cop)Copper.GetComponent(typeof(Cop));
		PowerValue = -1.0f;
		VelocityValue = -1.0f;
		//animationTest = GetComponent<AnimatingTest>();
		CatapultArmScript = GetComponent<CatapultArm>();
		nextPrisonerInlist.text = CopSetup.GetNextPrisonerName();
	}
	public void SpacebarButton()
	{
		SpacePressedCount++;
		
		if(SpacePressedCount == 2)
		{
			PlayVelocityBarFill = false;
			if(CopSetup.GetNextPrisonerName().Equals("Magic Mike"))
			{
				MaxPower = MMMaxPower;
				PowerValue = PowerFiller.fillAmount * MMMaxPower;
				VelocityValue = VelocityFiller.fillAmount * MMMaxVelocity;
			}
			else if(CopSetup.GetNextPrisonerName().Equals("Tiny Tim"))
			{
				MaxPower = TTMaxPower;
				PowerValue = PowerFiller.fillAmount * TTMaxPower;
				VelocityValue = VelocityFiller.fillAmount * TTMaxVelocity;
			}
			else if(CopSetup.GetNextPrisonerName().Equals("Fat Joe"))
			{
				MaxPower = FJMaxPower;
				PowerValue = PowerFiller.fillAmount * FJMaxPower;
				VelocityValue = VelocityFiller.fillAmount * FJMaxVelocity;
			}
			//PowerValue = PowerFiller.fillAmount * MaxPower;
			//VelocityValue = VelocityFiller.fillAmount * MaxVelocity;
			CatapultArmScript.LaunchCriminal();
			
		}
		else if(SpacePressedCount == 1)
		{
			PlayPowerBarFill = false;
		}
	}
	
	// Update is called once per frame
	
	void ActivateUIBarFill(string BarGaugeName)
	{
		if(BarGaugeName == "Power")
		{
			float CurrentPowerFill = PowerFiller.fillAmount;
			if(CurrentPowerFill >= 0 && CurrentPowerFill < 1.0f)
			{
				PowerFiller.fillAmount += Time.deltaTime;
			}
			else if(CurrentPowerFill == 1.0f)
			{
				PowerFiller.fillAmount = 0.0f;
			}
		}
		else // Velocity
		{
			float CurrentVelocityFill = VelocityFiller.fillAmount;
			if(CurrentVelocityFill >= 0 && CurrentVelocityFill < 1.0f)
			{
				VelocityFiller.fillAmount += Time.deltaTime;
			}
			else if(CurrentVelocityFill == 1.0f)
			{
				VelocityFiller.fillAmount = 0.0f;
			}
		}
	}
	void Update () 
	{
		totalScoreAcheived = CopSetup.GetTotalScore();
		CopScore.text = "Score:" + CopSetup.GetTotalScore().ToString();
		if(resetBarAndCanFire && (!PlayPowerBarFill && !PlayVelocityBarFill))
		{
			//cameramovement.CamOnRail(true);
			//SpacePressedCount = 0;

			//PlayVelocityBarFill = true;
			//PlayPowerBarFill = true;
			if(!(CopSetup.GetNextPrisonerName().Contains("oup")))
			{
				nextPrisonerInlist.text = CopSetup.GetNextPrisonerName();
			}
			else Application.LoadLevel("ScoreScreen");
		}
		if(PlayPowerBarFill)
		{
			ActivateUIBarFill("Power");
		}
		if(PlayVelocityBarFill)
		{
			ActivateUIBarFill ("Velocity");
		}
		if(Input.GetKeyDown("space"))
		{
			SpacePressedCount++;

			if(SpacePressedCount == 2)
			{
				PlayVelocityBarFill = false;
				if(CopSetup.GetNextPrisonerName().Equals("Magic Mike"))
				{
					MaxPower = MMMaxPower;
					PowerValue = PowerFiller.fillAmount * MMMaxPower;
					VelocityValue = VelocityFiller.fillAmount * MMMaxVelocity;
				}
				else if(CopSetup.GetNextPrisonerName().Equals("Tiny Tim"))
				{
					MaxPower = TTMaxPower;
					PowerValue = PowerFiller.fillAmount * TTMaxPower;
					VelocityValue = VelocityFiller.fillAmount * TTMaxVelocity;
				}
				else if(CopSetup.GetNextPrisonerName().Equals("Fat Joe"))
				{
					MaxPower = FJMaxPower;
					PowerValue = PowerFiller.fillAmount * FJMaxPower;
					VelocityValue = VelocityFiller.fillAmount * FJMaxVelocity;
				}
				//PowerValue = PowerFiller.fillAmount * MaxPower;
				//VelocityValue = VelocityFiller.fillAmount * MaxVelocity;
				CatapultArmScript.LaunchCriminal();

			}
			else if(SpacePressedCount == 1)
			{
				PlayPowerBarFill = false;
			}
		}
	}
}
