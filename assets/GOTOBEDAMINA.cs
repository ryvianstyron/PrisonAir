using UnityEngine;
using System.Collections;

public class GOTOBEDAMINA : MonoBehaviour {
	public Rigidbody rigidBDY;
	private float Thrust = 3500;
	private float Lift = 2200f;
	public Transform spawnPoint;
	// Use this for initialization
	void Start () {
	
	}
	public void Launch()
	{
		Transform Direction = spawnPoint.transform;
		Component [] rgbs = rigidBDY.GetComponentsInChildren(typeof(Rigidbody));
		foreach(Rigidbody Ridgid in rgbs)
		{
			rigidBDY.AddForce(spawnPoint.forward * Thrust );
			rigidBDY.AddForce(spawnPoint.up * Lift);
		}
	}

}
