using UnityEngine;
using System.Collections;

public class Orquicio : MonoBehaviour {
	public bool walk;
	public bool attack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0) {
			walk = true;
		} else {
			walk = false;
		}

		if (Input.GetButtonDown ("Fire1")) {
			attack = true;
		} else {
			attack = false;
		}

		GetComponent<Animator> ().SetBool ("walk", walk);
		GetComponent<Animator> ().SetBool ("attack", attack);
	}
}
