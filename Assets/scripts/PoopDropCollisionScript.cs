using UnityEngine;
using System.Collections;

public class PoopDropCollisionScript : MonoBehaviour {

	public GameObject ship1;
	public GameObject ship2;

	const float COLLISION_DISTANCE = 12f;

	public bool hit = false;
	public int shipnum = 0;

	const float ROTATION_FORCE_TIME = 1.5f;
	const float ROTATION_STRENGTH = 6f;
	public float rotation_time;
	
	AudioSource asrc;

	// Use this for initialization
	void Start () {

		rotation_time = ROTATION_FORCE_TIME;
		
		asrc = GetComponent(typeof(AudioSource)) as AudioSource;
	
	}
	
	// Update is called once per frame
	void Update () {

		float dist1 = Vector3.Distance(transform.position, ship1.transform.position);
		float dist2 = Vector3.Distance(transform.position, ship2.transform.position);

		if (dist1 <= dist2) {

			if (dist1 < COLLISION_DISTANCE) {
				//play sound
				asrc.Play();
				
				shipnum = 1;
				transform.position = new Vector3(0, 404f, 0);
				renderer.enabled = false;
				rigidbody.Sleep();
				hit = true;

			}

		}
		else {

			if (dist2 < COLLISION_DISTANCE) {
				//play sound
				asrc.Play();
				
				shipnum = 2;
				transform.position = new Vector3(0, 404f, 0);
				renderer.enabled = false;
				rigidbody.Sleep();
				hit = true;

			}

		}

		HandleHitNoticeHelper(ship1.transform, ship2.transform);


	}

	void HandleHitNoticeHelper(Transform ship1, Transform ship2) {

		if (shipnum == 1) {

			HandleHitNotice(ship1);

		}
		else if (shipnum == 2) {

			HandleHitNotice(ship2);

		}

	}

	void HandleHitNotice(Transform ship) {

		if (!hit) return;
		
		float time = Time.deltaTime;
		rotation_time -= time;

		if (rotation_time > 0f) {

			ship.eulerAngles = new Vector3(ship.eulerAngles.x, ship.eulerAngles.y + rotation_time * ROTATION_STRENGTH, ship.eulerAngles.z);

		}
		else {

			rotation_time = ROTATION_FORCE_TIME;
			transform.position = new Vector3(0, -404f, 0); // let PoopDroppingScript reset the poop
			shipnum = 0;
			hit = false;
			return;

		}

	}
}
