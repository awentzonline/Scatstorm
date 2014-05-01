using UnityEngine;
using System.Collections;

public class ShipControlScript1 : MonoBehaviour {

	// Use this for initialization
	const float WEAPON_POSITION = 0.1f;

	//Cannon 
	const float UP_FORCE = 12f;
	const float FORWARD_FORCE = 15f;

	//Catapult
	const float CATAPULT_UP_FORCE = 20f;
	const float CATAPULT_FORWARD_FORCE = 5f;

	//Forward_Force
	const float MOVEMENT_FORCE = 0.35f;

	//Left/Right
	const float ROTATION_FORCE = 1f;
	

	public GameObject cannon;
	public GameObject catapult;
	

	void Start () {
			
		cannon.rigidbody.Sleep ();
		//cannon.renderer.enabled = false;
		
		catapult.rigidbody.Sleep();
		//catapult.renderer.enabled = false;

	}


	// Update is called once per frame


	void FixedUpdate () {
//		const float UP_FORCE = 30f;
//		const float FORWARD_FORCE = 70f;

		if  (Input.GetKeyDown (KeyCode.O) ){//right side cannon
			if (checkCannonBallRange()) {
				cannon.rigidbody.velocity = new Vector3(0f,0f,0f);
				cannon.transform.position = new Vector3 (transform.position.x, transform.position.y + WEAPON_POSITION, transform.position.z);
				cannon.rigidbody.WakeUp();
				cannon.renderer.enabled = true;

				cannon.rigidbody.AddForce(-transform.forward * FORWARD_FORCE, ForceMode.VelocityChange); 
				cannon.rigidbody.AddForce(transform.up * UP_FORCE, ForceMode.VelocityChange);
				//cannon.rigidbody.AddForce(Vector3.right.x * FORWARD_FORCE , Vector3.right.y * UP_FORCE, Vector3.right.z * FORWARD_FORCE, ForceMode.Force);
				Debug.Log (cannon.transform.position);
			}
			else{
				Debug.Log ("CANNON ATTACK IS STILL PROCESSING");
			}
		     
		}

		

		if  (Input.GetKeyDown (KeyCode.U) ){//left side cannon
			if (checkCannonBallRange()) {
				cannon.rigidbody.velocity = new Vector3(0f,0f,0f);
				cannon.transform.position = new Vector3 (transform.position.x, transform.position.y + WEAPON_POSITION, transform.position.z);
				cannon.rigidbody.WakeUp();
				cannon.renderer.enabled = true;

				cannon.rigidbody.AddForce(transform.forward * FORWARD_FORCE, ForceMode.VelocityChange);
				cannon.rigidbody.AddForce(transform.up * UP_FORCE, ForceMode.VelocityChange);
				//cannon.rigidbody.AddForce(Vector3.left.x * FORWARD_FORCE , Vector3.left.y * UP_FORCE, Vector3.left.z * FORWARD_FORCE, ForceMode.Force);

					//cannon.rigidbody.AddForce(transform.right * CANNON_FORCE);
			}
			else {
				Debug.Log ("CANNON ATTACK IS STILL PROCESSING");
			}
		

		}


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

	bool checkCatapultBallRange () {
		
		if (catapult.transform.position.x < Mathf.Abs(32) && catapult.transform.position.y > -6 ) {
			return false;
		}
		else if (catapult.transform.position.z < Mathf.Abs(32) && catapult.transform.position.y >-6 ) {
			return false;
		}
		else {
			return true;
		}
		
	}

}

