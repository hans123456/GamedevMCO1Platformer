using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

	private Player player;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<Player> ();
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

	}
		
	void OnTriggerEnter2D(Collider2D col) {
		if (col.isTrigger == false && col.tag.Equals("Ground") && rb.velocity.y == 0)
			player.grounded = true;
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.isTrigger == false && col.tag.Equals ("Ground") && rb.velocity.y == 0)
			player.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.isTrigger == false && col.tag.Equals("Ground") || rb.velocity.y > 0)
			player.grounded = false;
	}

}
