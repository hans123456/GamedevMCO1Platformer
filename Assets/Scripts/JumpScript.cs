using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {

	private GameObject playerObject;
	private Player player;
	private float distanceToGround;
	private Transform groundCheck;
	public float jumpHeight;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		player = playerObject.GetComponentInParent<Player> ();
	}

	bool IsGrounded() {
		return player.grounded;
	}

	// Update is called once per frame
	void Update () {
		if ((Input.touchCount > 0 || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded()) {
			playerObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpHeight);
		}
	}

}
