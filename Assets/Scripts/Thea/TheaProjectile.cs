using UnityEngine;
using System.Collections;

public class TheaProjectile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			col.SendMessageUpwards ("Damage", 1);
			Destroy (gameObject);
		}
	}

}
