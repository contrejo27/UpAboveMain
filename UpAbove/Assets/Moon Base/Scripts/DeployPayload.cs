using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployPayload : MonoBehaviour {

	private Rigidbody Spayload;
	private SecondStage _secondstage;


	void Start () 
	{
		Spayload = GetComponent <Rigidbody> ();
		_secondstage = GetComponentInParent <SecondStage> ();
		
	}
	

	void Update ()
	{
		if (_secondstage.payload == true) 
		{
			
			Spayload.isKinematic = false;
			Spayload.GetComponent<BoxCollider> ().enabled = true;
	}
}
}