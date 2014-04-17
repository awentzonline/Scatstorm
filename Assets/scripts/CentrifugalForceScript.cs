﻿using UnityEngine;
using System.Collections;

public class CentrifugalForceScript : MonoBehaviour {

	const float FORCE_CONSTANT = 7.5f;
	const float INWARD_FORCE = .1f;
	const float MAX_X = 10f;
	const float MAX_Z = 10f;

	public float distance;
	public Vector3 target;
	public Vector3 normalv;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		float max_d = Mathf.Sqrt(MAX_X*MAX_X + MAX_Z*MAX_Z);

		float x = transform.position.x;
		float z = transform.position.z;

		distance = Mathf.Sqrt(x*x + z*z);

		Vector3 origin = Vector3.zero;
		target = (new Vector3(x, 0, z)) - origin;


		normalv = new Vector3(-target.z, 0, target.x);
		normalv = Vector3.Normalize(normalv);

		float factor = Mathf.Exp(-1 * (distance * distance) / (max_d * max_d));
		normalv *= factor * FORCE_CONSTANT;

		target *= -1;
		target = Vector3.Normalize(target);
		target *= INWARD_FORCE;

		rigidbody.AddForce(normalv, ForceMode.Force);
		rigidbody.AddForce(target, ForceMode.Force);

	
	}
}
