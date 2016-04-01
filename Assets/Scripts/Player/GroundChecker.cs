using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

	private Player player;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<Player> ();
	}

	// Update is called once per frame
	void Update () {

	}
		
	void OnTriggerEnter2D(Collider2D col) {
		if (col.isTrigger == false && col.tag.Equals("Ground"))
			player.grounded = true;
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.isTrigger == false && col.tag.Equals ("Ground"))
			player.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.isTrigger == false && col.tag.Equals("Ground"))
			player.grounded = false;
	}

}
