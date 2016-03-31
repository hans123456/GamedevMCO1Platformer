using UnityEngine;
using System.Collections;

public class TheaProjectileScript : MonoBehaviour {

	private float startPosX;
	public bool start = false;
	public bool facingRight = true;
	public float distanceBeforeDestroy;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		startPosX = transform.position.x;
	}

	// Update is called once per frame
	void Update () {
		
		if (!start)
			return;

		if (Mathf.Abs (startPosX - transform.position.x) >= distanceBeforeDestroy) {
			Destroy (gameObject);
		} else if (facingRight) {
			gameObject.transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
		} else if (!facingRight) {
			gameObject.transform.Translate (-Vector2.left * moveSpeed * Time.deltaTime);
		}

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			col.SendMessageUpwards ("Damage", 1);
			Destroy (gameObject);
		}
	}

}
