using UnityEngine;
using System.Collections;

public class ThrustRocket : MonoBehaviour {

	public float thrust = 50;
	public Rigidbody rocket;
	private bool EngineOn;
	public bool boostersStage;
	//public AudioClip engine;
	//AudioSource audio;




	void Start () 
	{
		rocket = GetComponent<Rigidbody> ();
		EngineOn = false;
		boostersStage = false;
	}


	void FixedUpdate ()
	{
		StartSequence ();
		Launch ();
	}

	private void StartSequence ()
	{
		if (Input.GetKey ("space"))
			EngineOn = true;
	}

	private void Launch ()
	{
		if (EngineOn == true)
		{
			rocket.AddRelativeForce (0, thrust, 0, ForceMode.Force);
			StartCoroutine (DetachBoosters ());

		}
	}
	IEnumerator DetachBoosters()
	{
		yield return new WaitForSeconds(7);
		boostersStage = true;
		thrust = 0F;
		rocket.GetComponent<BoxCollider> ().enabled = false;
		rocket.isKinematic = true;
	}
}