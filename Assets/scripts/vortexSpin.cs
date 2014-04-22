using UnityEngine;
using System.Collections;

public class vortexSpin : MonoBehaviour {

	public float speed;
	
	// Use this for initialization
	void FixedUpdate () {
		transform.Rotate(Vector3.down * speed * Time.deltaTime);
	}
}
