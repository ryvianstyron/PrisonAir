using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private GameObject cam;
	private GameObject prisoner;
	public GameObject prisonerT;
	public float speed = -1.0f;
	AnimatingTest prisonerFollow;
	public bool spawned = false;
//	private float time = 10f;
	

	// Use this for initialization
	void Start () {	
	}

	void Update () {

		CameraFollow();
	}

	public void CameraFollow()
	{
		if(prisonerT!=null)
		{
			//Debug.Log("Updating...");
			Vector3 newPos= Vector3.zero;
			newPos.x = prisonerT.transform.position.x;
			newPos.y = prisonerT.transform.position.y + 3f;
			newPos.z = prisonerT.transform.position.z - 10f;
			this.transform.position=newPos;
		}
	}
}
