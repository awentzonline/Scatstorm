using UnityEngine;
using System.Collections;

public class poopCollision : MonoBehaviour {

	public GameObject poop1;
	public GameObject poop2;
	public GameObject poop3;

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject == poop1 || col.gameObject == poop2 || col.gameObject == poop3 )
		{
			Time.timeScale=0;
		}
	}
}
