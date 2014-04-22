using UnityEngine;
using System.Collections;

public class player1Controls : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.W) ) {
			GetComponent<Rigidbody>().AddForce(transform.right * 25 * Time.deltaTime, ForceMode.VelocityChange);
		}
		if (Input.GetKey (KeyCode.S) ) {
			GetComponent<Rigidbody>().AddForce(transform.right * -25 * Time.deltaTime, ForceMode.VelocityChange);
		}
		if (Input.GetKey (KeyCode.A) ) {
			transform.Rotate ( new Vector3 (0f, -100f * Time.deltaTime) );
		}
		if (Input.GetKey (KeyCode.D) ) {
			transform.Rotate ( new Vector3 (0f, 100f * Time.deltaTime) );
		}
		if (Input.GetKey(KeyCode.Space)) {
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
