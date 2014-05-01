using UnityEngine;
using System.Collections;

// TURN OFF Z FREEZE CONSTRAINT WITH THIS SCRIPT

public class ClampSwayingScript : MonoBehaviour {

	const float SWAYING_ANGLE_BOUNDARY = 20f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float check = transform.eulerAngles.x;

		if ((check > SWAYING_ANGLE_BOUNDARY && check <= 180f) || (check < -360f + SWAYING_ANGLE_BOUNDARY && check < -180f)) {
			transform.eulerAngles = new Vector3(SWAYING_ANGLE_BOUNDARY, transform.eulerAngles.y, 0);
		}
		else if ((check < 360f - SWAYING_ANGLE_BOUNDARY && check > 180f) || (check < -SWAYING_ANGLE_BOUNDARY && check > -180f)) {
			transform.eulerAngles = new Vector3(-1 * SWAYING_ANGLE_BOUNDARY, transform.eulerAngles.y, 0);
		}

		// must restrict the z rotation since the z freeze constraint breaks with this script
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

		// for some reason, the ship will fly using this script. so don't let any upwards velocity
		if (rigidbody.velocity.y > 0) 
		rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
	}
}
