using UnityEngine;
using System.Collections;

public class CatapultArm : MonoBehaviour 
{
	
	//public GameObject arm;
	public static bool spaceKeyDown=false;
	
	private float Power;
	private float Velocity;
	public static bool isPressed;
	public Rigidbody ammo;
	
	private float LamePowerAmount;
	private float HalfPowerAmount;
	private float FullPowerAmount;
	
	private float MaxPower;
	
	private AnimatingTest animationTest;

	//private Cop CopSetup;

	
	void Start()
	{
		//CopSetup = GameObject.Find("Cop").GetComponent<Cop>();
		animationTest = GetComponent<AnimatingTest>();
		StartCoroutine(animationTest.PlayAnimation("Idle"));
	}
	public void LaunchCriminal()
	{
		MaxPower = UI.MaxPower;
		LamePowerAmount = (float)(MaxPower * 0.33f);
		HalfPowerAmount = (float)(MaxPower * 0.66f);
		FullPowerAmount = UI.MaxPower;

		if(UI.PowerValue != -1.0f && UI.VelocityValue != -1.0f)
		{
			Power = UI.PowerValue;
			Velocity = UI.VelocityValue;
			
//			Debug.Log ("LamePowerAmount: " + LamePowerAmount);
//			Debug.Log("HalfPowerAmount: " + HalfPowerAmount);
//			Debug.Log ("FullPowerAmount: " + FullPowerAmount);
//			
//			Debug.Log ("Power: " + Power);
//			Debug.Log ("Velocity: " + Velocity);
//			
			if(Power >= 0 && Power <= LamePowerAmount)
			{
				StartCoroutine(animationTest.PlayPowerAnimationAndInstantiate("LamePower", Power, Velocity));
				//ammo.AddForce(0,Power,Velocity);
			}
			else if(LamePowerAmount > 0 && Power <= HalfPowerAmount)
			{
				StartCoroutine(animationTest.PlayPowerAnimationAndInstantiate("HalfPower", Power, Velocity));
				//ammo.AddForce(0,Power,Velocity);
			}
			else if(Power > HalfPowerAmount && Power <= FullPowerAmount)
			{
				StartCoroutine(animationTest.PlayPowerAnimationAndInstantiate("FullPower", Power, Velocity));
				//ammo.AddForce(0,Power,Velocity);
				//ammo.AddForce(0,4000,1000);
			}
			/*if(Power >= 0 && Power <= LamePowerAmount)
			{
				StartCoroutine(animationTest.PlayPowerAnimationAndInstantiate("LamePower", Power, Velocity));
				//ammo.AddForce(0,Power,Velocity);
			}
			else if(LamePowerAmount > 0 && Power <= HalfPowerAmount)
			{
				StartCoroutine(animationTest.PlayPowerAnimationAndInstantiate("HalfPower", Power, Velocity));
				//ammo.AddForce(0,Power,Velocity);
			}
			else if(Power > HalfPowerAmount && Power <= FullPowerAmount)
			{
				StartCoroutine(animationTest.PlayPowerAnimationAndInstantiate("FullPower", Power, Velocity));
				//ammo.AddForce(0,Power,Velocity);
				//ammo.AddForce(0,4000,1000);
			}*/
		}
	}
}
