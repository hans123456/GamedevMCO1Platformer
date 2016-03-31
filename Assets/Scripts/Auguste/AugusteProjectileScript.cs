using UnityEngine;
using System.Collections;

public class AugusteProjectileScript : MonoBehaviour {

	private float startPosX;
	public bool start = false;
	public float distanceBeforeDestroy;
	public float moveSpeed;
	private GameObject playerObject;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		startPosX = transform.position.x;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			start = true;
		}

		if (!start) {

			playerObject = GameObject.FindGameObjectWithTag ("Player");

			// https://www.reddit.com/r/Unity2D/comments/2cp8ly/how_do_i_make_a_projectile_fire_in_the_direction/
			direction = transform.position - playerObject.transform.position;
			transform.rotation = Quaternion.LookRotation(transform.forward, direction);

			return;
		}

		if (Mathf.Abs (startPosX - transform.position.x) >= distanceBeforeDestroy) {
			Destroy (gameObject);
		} else {
			Vector3 velocity = gameObject.transform.rotation * Vector3.down;
			gameObject.GetComponent<Rigidbody2D> ().AddForce(velocity * moveSpeed);
		}

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (!start)
			return;
		if (col.tag.Equals ("Player")) {
			col.SendMessageUpwards ("Damage", 1);
			Destroy (gameObject);
		}
		if (col.tag.Equals ("Ground")) {
			Destroy (gameObject);		
		}
	}

}
