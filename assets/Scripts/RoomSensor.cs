using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomSensor : MonoBehaviour {

	public List<Rigidbody> roomObjects = new List<Rigidbody>();


	private void OnTriggerEnter(Collider collider)
	{
		Debug.Log ("Trigger");
		if (collider.gameObject.name == "TestCube") 
		{

			foreach(Rigidbody rb in roomObjects)
			{
				Debug.Log ("RigidBody");
				rb.isKinematic = false;
			}
		}
	}
}
