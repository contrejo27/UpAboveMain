using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleStabilize : MonoBehaviour {


	private Rigidbody body;
	private float enginesForce;
	private float StabilizedHoverHeight = 3000f;
	public GameObject[] HoverPointsGameObjects;
	private LayerMask terrain = -8;
	public ParticleSystem flame1;
	public ParticleSystem flame2;
	public ParticleSystem flame3;
	public ParticleSystem flame4;
	private SecondStage _secondstage;

	void Start () 
	{
	body = GetComponent<Rigidbody>();
	_secondstage = GetComponentInParent <SecondStage> ();
	
	
	}

	void OnDrawGizmos()
	{


		RaycastHit hit;
		for (int i = 0; i < HoverPointsGameObjects.Length; i++)
		{
			var hoverPoint = HoverPointsGameObjects [i];
			if (Physics.Raycast(hoverPoint.transform.position, 
				-Vector3.up, out hit,
				StabilizedHoverHeight, 
				terrain))
			{
				Gizmos.color = Color.green;
				//Color if correctly alligned
				Gizmos.DrawLine(hoverPoint.transform.position, hit.point);
				Gizmos.DrawSphere(hit.point, 0.5f);
			} else
			{
				Gizmos.color = Color.red;
				//Color if incorrectly alligned
				Gizmos.DrawLine(hoverPoint.transform.position, 
					hoverPoint.transform.position - Vector3.up * StabilizedHoverHeight);
			}
		}
	}
	

	void FixedUpdate ()
	{
		RaycastHit hit;
		for (int i = 0; i < HoverPointsGameObjects.Length; i++) {
			var hoverPoint = HoverPointsGameObjects [i];
			if (Physics.Raycast (hoverPoint.transform.position, -Vector3.up, out hit, StabilizedHoverHeight, terrain))
				body.AddForceAtPosition (Vector3.up * enginesForce, hoverPoint.transform.position);
			else {
				if (transform.position.y > hoverPoint.transform.position.y)
					body.AddForceAtPosition (
						hoverPoint.transform.up * enginesForce,
						hoverPoint.transform.position);
				else
					body.AddForceAtPosition (
						hoverPoint.transform.up * -enginesForce,
						hoverPoint.transform.position);
			
			}
			float distanceToGround = hit.distance;

			//Debug.Log ("GroundDistance =" + distanceToGround);
			//Debug.Log ("HoverForce =" + enginesForce);


			if (distanceToGround > 1000) {
				enginesForce = 0;
			} 
			if (distanceToGround < 1000) {
				enginesForce = 200;
			}
			if(_secondstage.payload == true && enginesForce >= 200)
				{
				flame1.Play ();
				flame2.Play ();
				flame3.Play ();
				flame4.Play ();
			   } 

			if (distanceToGround < 500) {
				enginesForce = 285;
			}
				
			//if (distanceToGround < 50) {
				//hoverForce = 500;
			//}
			if (distanceToGround < 4) {
				enginesForce = 0;
				flame1.Stop ();
				flame2.Stop ();
				flame3.Stop ();
				flame4.Stop ();
			}
		}
	}
}
