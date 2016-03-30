using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
	
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 || Input.GetKey (KeyCode.Space)) {
			player.GetComponent<Animator> ().Play ("PlayerAttackAnim");
		}
	}

}
