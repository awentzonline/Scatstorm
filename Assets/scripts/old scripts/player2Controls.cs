using UnityEngine;
using System.Collections;

public class player2Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.UpArrow) ) {
			GetComponent<Rigidbody>().AddForce(transform.right * 25 * Time.deltaTime, ForceMode.VelocityChange);
		}
		if (Input.GetKey (KeyCode.DownArrow) ) {
			GetComponent<Rigidbody>().AddForce(transform.right * -25 * Time.deltaTime, ForceMode.VelocityChange);
		}
		if (Input.GetKey (KeyCode.LeftArrow) ) {
			transform.Rotate ( new Vector3 (0f, -100f * Time.deltaTime) );
		}
		if (Input.GetKey (KeyCode.RightArrow) ) {
			transform.Rotate ( new Vector3 (0f, 100f * Time.deltaTime) );
		}
	}
}
