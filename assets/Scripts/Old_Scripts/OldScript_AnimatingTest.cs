using UnityEngine;
using System.Collections;
public class AnimatingTest : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject ragDoll;
	public Rigidbody RagDollRGB;
	Animator Anim;
	private GameObject PrisonerToFireFinal;
	public CameraMovement cameraMovement;
	public Cop CopSetup;
	//public GameObject Pointer;

	// Method call would be
	void Start () 
    {
		CopSetup = GameObject.Find("Cop").GetComponent<Cop>();
	}
	void Update () 
    {

	}
//	public GameObject getRagDollGameObject()
//	{
//		return rgb;
//	}

	public IEnumerator PlayPowerAnimationAndInstantiate(string AnimationName, float Power, float Velocity)
	{
		Debug.Log ("PlayPowerAnimationAndInstantiate(): " + AnimationName);
		Anim = gameObject.GetComponent<Animator>();
		Anim.Play(AnimationName,0,0);
		yield return new WaitForSeconds(1.65f) ;
		Anim.StopPlayback();
		GameObject PrisonerToFire = CopSetup.GetNextPrisoner();
		PrisonerToFireFinal = (GameObject)Instantiate(PrisonerToFire, spawnPoint.transform.position, Quaternion.identity);

		//rgb=(GameObject)Instantiate(ragDoll,spawnPoint.transform.position,Quaternion.identity);
		Transform Direction = spawnPoint.transform;
		Component [] rgbs = PrisonerToFireFinal.GetComponentsInChildren(typeof(Rigidbody));
		foreach(Rigidbody rigidBDY in rgbs)
		{
			rigidBDY.AddForce(Direction.forward *  Power);
			rigidBDY.AddForce(Direction.up *  (Velocity));
		}
		cameraMovement.prisonerT = PrisonerToFireFinal.transform.GetChild(1).gameObject;
		cameraMovement.spawned = true;
	}
	public IEnumerator PlayAnimation(string AnimationName)
	{
		Debug.Log ("PlayAnimation(): " + AnimationName);
		Anim = gameObject.GetComponent<Animator>();
		Anim.Play(AnimationName,0,0);
		yield return new WaitForSeconds(1.65f) ;
		Anim.StopPlayback();
	}
//	public float GetAnimationLength(string AnimationName)
//	{
//		float clipLength = -1;
//		if(AnimationName.Equals ("Idle"))
//		{
//			clipLength = 1.0f;
//		}
//		else
//		{
//			AnimationInfo[] CurrentPlayingAnimationInfo = Anim.GetCurrentAnimationClipState(0);
//			clipLength = CurrentPlayingAnimationInfo[0].clip.length;
//			for(int i = 0; i < CurrentPlayingAnimationInfo.Length; i++)
//			{
//				//Debug.Log ("At (" + i + ") ->" + CurrentPlayingAnimationInfo[i].clip.name + ": has length= " + CurrentPlayingAnimationInfo[i].clip.length);
//			}
//		}
//		Debug.Log ("Clip Length Found of " + AnimationName + ":" + clipLength);
//		return clipLength;
////		string FullAnimationName = "Base." + AnimationName;
////		Debug.Log ("Using Animation Name -> " + FullAnimationName);
////		Debug.Log("idleState: " + Animator.StringToHash("Base.Idle"));
////		Debug.Log("HalfPower: " + Animator.StringToHash("Base.HalfPower"));
////		Debug.Log("FullPower: " + Animator.StringToHash("Base.FullPower"));
////		Debug.Log("LamePower: " + Animator.StringToHash("Base.LamePower"));
////	
////		AnimtorStateInfo CurrentlyPlaying = Anim.GetCurrentAnimatorStateInfo(0);
////		int AnimationHashToFind = Animator.StringToHash(FullAnimationName);
//		
////		if (AnimtationHashToFind == CurrentlyPlaying.nameHash)
////		{
////			Debug.Log("Match Found!");
////			AnimatorStateInfo stateInfo = Anim.GetCurrentAnimatorStateInfo(0);
////			clipLength = stateInfo.length;
////		}
//
////		if(Anim!=null)
////		
////			int reloadState = Animator.StringToHash("Layer2.Reload");
////			AnimatorStateInfo Layer2CurrentState = Anim.GetCurrentAnimatorStateInfo()
////
////			UnityEditorInternal.AnimatorController AC = Anim.runtimeAnimatorController as UnityEditorInternal.AnimatorController;
////			UnityEditorInternal.StateMachine SM = AC.GetLayer(0).stateMachine;
////
////			for(int i = 0; i < SM.stateCount; i++) 
////			{
////				UnityEditorInternal.State state = SM.GetState(i);
////				if(state.uniqueName.Contains(AnimationName)) 
////				{
////					AnimationClip Clip = state.GetMotion() as AnimationClip;
////					if(Clip != null) 
////					{
////						ClipLength = Clip.length;
////					}
////				}
////			}
//	}
		//return ClipLength;
}

