using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStage : MonoBehaviour {


	private Rigidbody secondstage;
	private Boosters _boosters;
	public float s_thrust = 50;
	public bool payload;
	public ParticleSystem flame;


	void Start () 
	{
		secondstage = GetComponent <Rigidbody> ();
		_boosters = GetComponentInParent <Boosters> ();
		//ParticleSystem flame = GetComponent<ParticleSystem>();


		}


	void FixedUpdate () 
	{
		if (_boosters.secondStage == true) 
	{
		StartCoroutine (StartSecondStageEngine ());
		secondstage.isKinematic = false;
		secondstage.GetComponent<BoxCollider> ().enabled = true;
		secondstage.AddRelativeForce (0, 0, s_thrust, ForceMode.Force);
		StartCoroutine (DetachPayLoad ());

			}
		}
	IEnumerator DetachPayLoad()
	{
		yield return new WaitForSeconds(5);
		payload = true;
		s_thrust = 0F;
		secondstage.GetComponent<BoxCollider> ().enabled = false;
		secondstage.isKinematic = true;
	}

	IEnumerator StartSecondStageEngine()
	{
		yield return new WaitForSeconds(1);
		flame.Play ();
	}
}
