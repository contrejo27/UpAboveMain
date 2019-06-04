using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosters : MonoBehaviour {


	private Rigidbody Booster;
	private ThrustRocket MainRocket;
	public float b_thrust = 50;
	public bool secondStage;


	void Start () {

		Booster = GetComponent <Rigidbody> ();
		MainRocket = GetComponentInParent <ThrustRocket> ();
		
	}
	

	void FixedUpdate () 
	{
		if (MainRocket.boostersStage == true) 
		{
			Booster.isKinematic = false;
			Booster.GetComponent<BoxCollider> ().enabled = true;
			Booster.AddRelativeForce (0, 0, b_thrust, ForceMode.Force);
			StartCoroutine (DetachSecondStage ());


		}
	}
	IEnumerator DetachSecondStage()
	{
		yield return new WaitForSeconds(5);
		secondStage = true;
		b_thrust = 0F;
		Booster.GetComponent<BoxCollider> ().enabled = false;
		Booster.isKinematic = true;
	}
}
