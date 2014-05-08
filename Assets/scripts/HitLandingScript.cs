using UnityEngine;
using System.Collections;

public class HitLandingScript : MonoBehaviour {

	public GameObject opponent;
	bool hit = false;

	const float ROTATE_FORCE_TIME = 1.5f;
	const float ROTATION_STRENGTH = 6f;
	float rotation_time;

	const float COLLISION_DISTANCE = 8f;

	const float DEFAULT_POOP_HEIGHT = -20f;
	
	AudioSource asrc;

	// Use this for initialization
	void Start () {
		rotation_time = ROTATE_FORCE_TIME;
		
		asrc = GetComponent(typeof(AudioSource)) as AudioSource;
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(opponent.transform.position, transform.position) < COLLISION_DISTANCE) {
			//play sound
			asrc.Play();
			
			if (!hit) {

				// HANDLE HPs HERE

				hit = true;
				transform.position = new Vector3(0, -DEFAULT_POOP_HEIGHT, 0);
				renderer.enabled = false;

			}

		}

		HandleHitNotice(opponent.transform);
	
	}

	void HandleHitNotice(Transform ship) {

		if (!hit) return;
		
		float time = Time.deltaTime;
		rotation_time -= time;

		if (rotation_time > 0f) {

			ship.eulerAngles = new Vector3(ship.eulerAngles.x, ship.eulerAngles.y + rotation_time * ROTATION_STRENGTH, ship.eulerAngles.z);

		}
		else {

			rotation_time = ROTATE_FORCE_TIME;
			hit = false;
			return;

		}

	}
}
