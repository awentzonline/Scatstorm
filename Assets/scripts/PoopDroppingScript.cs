using UnityEngine;
using System.Collections;

public class PoopDroppingScript : MonoBehaviour {

	const float MAX_X = 15f;
	const float MAX_Z = 15f;

	const float FLASH_DURATION = 3f;
	const float BLINK_DURATION = 0.4f;

	const float WAITTIME_MAX = 7f;
	const float WAITTIME_MIN = 1.5f;
	const float WAITTIME_DECREASING_INCREMENT = 0.5f;
	public float RANDOM_TIME_WAIT;
	public float current_wait_time = 0f;
	float interval_wait_time = 0f;
	const float RANDOM_VALUE_SWITCH = 0.1f;

	const float STARTING_POOP_HEIGHT = 100f;

	public GameObject poop1;
	public GameObject poop2;
	public GameObject poop3;

	public string[] states;

	public float[] flash_lengths;
	public float[] blink_lengths;

	// Use this for initialization
	void Start () {

		RANDOM_TIME_WAIT = WAITTIME_MAX;

		states = new string[3] { "inactive", "inactive", "inactive" };
		flash_lengths = new float[3] { 0f, 0f, 0f };
		blink_lengths = new float[3] { 0f, 0f, 0f };
		RestartPoopPosition(poop1);
		RestartPoopPosition(poop2);
		RestartPoopPosition(poop3);
	}

	void RestartPoopPosition(GameObject obj) {
		obj.transform.position = new Vector3(Random.Range(-MAX_X, MAX_X), STARTING_POOP_HEIGHT, Random.Range(-MAX_Z, MAX_Z));
	}
	
	// Update is called once per frame
	void Update () {
		HandleStates(1);
		HandleStates(2);
		HandleStates(3);
		RandomActivator();
	}

	void ActivatePoop() {
		if (states[0] == "inactive") {
			states[0] = "flashing";
			flash_lengths[0] = FLASH_DURATION;
			blink_lengths[0] = BLINK_DURATION;
		} else if (states[1] == "inactive") {
			states[1] = "flashing";
			flash_lengths[1] = FLASH_DURATION;
			blink_lengths[1] = BLINK_DURATION;
		} else if (states[2] == "inactive") {
			states[2] = "flashing";
			flash_lengths[2] = FLASH_DURATION;
			blink_lengths[2] = BLINK_DURATION;
		}
	}

	void RandomActivator() {
		if (states[0] != "inactive" && states[1] != "inactive" && states[2] != "inactive") {
			current_wait_time = 0f;
			return;
		}

		current_wait_time += Time.deltaTime;
		if (current_wait_time > RANDOM_TIME_WAIT) {
			if (current_wait_time - interval_wait_time > 0.1f) {
				float random_verifier = Random.Range(0.0f, 1.0f);

				if (random_verifier < RANDOM_VALUE_SWITCH) {
					current_wait_time = 0f;
					interval_wait_time = 0f;
					ActivatePoop();
					DecreaseWaitTime();
					return;
				}

				interval_wait_time = current_wait_time;
			}
		}
	}

	void DecreaseWaitTime() {
		RANDOM_TIME_WAIT = Mathf.Max(RANDOM_TIME_WAIT - WAITTIME_DECREASING_INCREMENT, WAITTIME_MIN);
	}

	void HandleStates(int poopnum) {
		if (poopnum < 1 || poopnum > 3) return;

		int i = poopnum - 1;
		GameObject obj;
		if (poopnum == 1) obj = poop1;
		else if (poopnum == 2) obj = poop2;
		else obj = poop3;

		if (states[i] != "active") {
			obj.rigidbody.Sleep();
		}

		if (states[i] == "flashing") {
			float time = Time.deltaTime;
			flash_lengths[i] -= time;
			blink_lengths[i] -= time;
			if (flash_lengths[i] <= 0f) {
				flash_lengths[i] = 0f;
				blink_lengths[i] = 0f;
				obj.renderer.enabled = true;
				obj.collider.enabled = true;
				obj.rigidbody.WakeUp();
				states[i] = "active";
			}
			else if (blink_lengths[i] <= 0f) {
				obj.renderer.enabled = !(obj.renderer.enabled);
				blink_lengths[i] = BLINK_DURATION;
			}
		} else if (states[i] == "active") {
			if (obj.transform.position.y <= 0f) {
				obj.renderer.enabled = false;
				obj.collider.enabled = false;
				obj.rigidbody.Sleep();
				RestartPoopPosition(obj);
				states[i] = "inactive";
			}	
		}
	}


}
