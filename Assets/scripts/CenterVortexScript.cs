using UnityEngine;
using System.Collections;

public class CenterVortexScript : MonoBehaviour {

	public GameObject ship1;
	public GameObject ship2;

	public float dead_state1;
	public float dead_state2;

	const float LOSING_RANGE = 4f;
	const float TWIRL_TIME = 100f;
	const float TWIRLING_PACE_RATE = 8f;
	const float LOWEST_POINT = 1f;
	const float SINK_DEPTH = 12f;

	// Use this for initialization
	void Start () {
		dead_state1 = TWIRL_TIME;
		dead_state2 = TWIRL_TIME;
	}
	
	// Update is called once per frame
	void Update () {
		if (ship1.transform.position.x < LOSING_RANGE && ship1.transform.position.x > -LOSING_RANGE && ship1.transform.position.z < LOSING_RANGE && ship1.transform.position.z > -LOSING_RANGE) {

			ship1.collider.enabled = false;
			ship1.transform.position = new Vector3(0, LOWEST_POINT, 0);
			dead_state1 -= 1f;

		}

		if (ship2.transform.position.x < LOSING_RANGE && ship2.transform.position.x > -LOSING_RANGE && ship2.transform.position.z < LOSING_RANGE && ship2.transform.position.z > -LOSING_RANGE) {
			
			ship2.collider.enabled = false;
			ship2.transform.position = new Vector3(0, LOWEST_POINT, 0);
			dead_state2 -= 1f;

		}

		if (dead_state1 < TWIRL_TIME) { TwirlShip(ship1.transform, 1); }
		if (dead_state2 < TWIRL_TIME) { TwirlShip(ship2.transform, 2); }

		if (dead_state1 < 0 || dead_state2 <0) {
			if (dead_state1 <0 ) {
				Application.LoadLevel ("RedShipWonScene");
			}
			else if (dead_state2 <0 ){
				Application.LoadLevel ("BlueShipWonScene");
				
			}

		}
		//GetComponent <TextMesh> ().text = textBuffer;
	}

	void TwirlShip(Transform ship, int player) {
		float time = Time.deltaTime;

		ship.eulerAngles = new Vector3(ship.eulerAngles.x, ship.eulerAngles.y + TWIRLING_PACE_RATE, ship.eulerAngles.z);

		float lerp_fraction;

		// sinking the ship
		if (player == 1) {

			dead_state1 -= time;

			lerp_fraction = (TWIRL_TIME - dead_state1) / TWIRL_TIME;
			ship.position = Vector3.Lerp(new Vector3(0, LOWEST_POINT, 0), new Vector3(0, LOWEST_POINT - SINK_DEPTH, 0), lerp_fraction);

		}
		else if (player == 2) {

			dead_state2 -= time;

			lerp_fraction = (TWIRL_TIME - dead_state2) / TWIRL_TIME;
			ship.position = Vector3.Lerp(new Vector3(0, LOWEST_POINT, 0), new Vector3(0, LOWEST_POINT - SINK_DEPTH, 0), lerp_fraction);

		}
	}
}
