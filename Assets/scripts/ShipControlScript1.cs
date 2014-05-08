using UnityEngine;
using System.Collections;

public class ShipControlScript1 : MonoBehaviour {

	// Use this for initialization
	const float WEAPON_POSITION = 0.1f;

	//Cannon 
	const float UP_FORCE = 12f;
	const float FORWARD_FORCE = 65f;

	//Catapult
	const float CATAPULT_UP_FORCE = 20f;
	const float CATAPULT_FORWARD_FORCE = 5f;

	//Forward_Force
	const float MOVEMENT_FORCE = 0.35f;

	//Left/Right
	const float ROTATION_FORCE = 1f;
	
	AudioSource asrc;
	

	public GameObject cannon;
	public GameObject catapult;
	

	void Start () {
			
		cannon.rigidbody.Sleep ();
		//cannon.renderer.enabled = false;
		
		catapult.rigidbody.Sleep();
		//catapult.renderer.enabled = false;

		asrc = GetComponent(typeof(AudioSource)) as AudioSource;

	}


	// Update is called once per frame


	void FixedUpdate () {
//		const float UP_FORCE = 30f;
//		const float FORWARD_FORCE = 70f;

		if  (Input.GetKeyDown (KeyCode.U) ){//port side cannon
			if (checkCannonBallRange()) {
				//play sound
				asrc.Play();
				
				cannon.rigidbody.velocity = new Vector3(0f,0f,0f);
				cannon.transform.position = new Vector3 (transform.position.x, transform.position.y + WEAPON_POSITION, transform.position.z);
				cannon.rigidbody.WakeUp();
				cannon.renderer.enabled = true;
				
				cannon.rigidbody.AddForce(transform.right * FORWARD_FORCE, ForceMode.VelocityChange); 
			}
			else{
				Debug.Log ("CANNON ATTACK IS STILL PROCESSING");
			}
		     
		}

		

		if  (Input.GetKeyDown (KeyCode.O) ){//starboard side cannon
			if (checkCannonBallRange()) {
				//play sound
				asrc.Play();
			
				cannon.rigidbody.velocity = new Vector3(0f,0f,0f);
				cannon.transform.position = new Vector3 (transform.position.x, transform.position.y + WEAPON_POSITION, transform.position.z);
				cannon.rigidbody.WakeUp();
				cannon.renderer.enabled = true;

				cannon.rigidbody.AddForce(-transform.right * FORWARD_FORCE, ForceMode.VelocityChange);
			}
			else {
				Debug.Log ("CANNON ATTACK IS STILL PROCESSING");
			}
		

		}

/*
		if (Input.GetKeyDown (KeyCode.K) ) {//Catapult
			if (checkCatapultBallRange()) {
				catapult.rigidbody.velocity = new Vector3(0f,0f,0f);
				catapult.transform.position = new Vector3 (transform.position.x, transform.position.y + WEAPON_POSITION, transform.position.z);
				catapult.rigidbody.WakeUp();
				catapult.renderer.enabled = true;

				catapult.rigidbody.AddForce(transform.right * CATAPULT_FORWARD_FORCE, ForceMode.VelocityChange);
				catapult.rigidbody.AddForce(transform.up * CATAPULT_UP_FORCE, ForceMode.VelocityChange);
				//catapult.rigidbody.AddForce (Vector3.forward.x * FORWARD_PUSH_FORCE, Vector3.up.y * UP_PUSH_FORCE, Vector3.forward.z * -FORWARD_PUSH_FORCE, ForceMode.Force);
				// -forward_push_force at z made the ball pushed down instead of up
			}
			else {
				Debug.Log ("CATAPULT ATTACK IS STILL PROCESSING");

			}

		}
*/

		if (Input.GetKey (KeyCode.I) ){ //FORWARD
			rigidbody.AddForce (-transform.forward * MOVEMENT_FORCE, ForceMode.VelocityChange); 

		}

		if (Input.GetKey (KeyCode.L)){//RIGHT
			transform.Rotate (Vector3.up * ROTATION_FORCE);

		}

		if (Input.GetKey (KeyCode.J )) {//LEFT
			transform.Rotate (-Vector3.up * ROTATION_FORCE);

		}


	}

	bool checkCannonBallRange () {

		if (cannon.transform.position.x < Mathf.Abs(32) && cannon.transform.position.y > -6 ) {
			return false;
		}
		else if (cannon.transform.position.z < Mathf.Abs(32) && cannon.transform.position.y >-6 ) {
			return false;
		}
		else {
			return true;
		}

	}

}

