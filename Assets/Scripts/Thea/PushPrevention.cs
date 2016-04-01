using UnityEngine;
using System.Collections;

public class PushPrevention : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col) {
		gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
	}

	void OnTriggerStay2D(Collider2D col) {
	}

	void OnTriggerExit2D(Collider2D col) {
		gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
	}

}
