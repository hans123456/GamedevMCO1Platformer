using UnityEngine;
using System.Collections;

public class TheaStartChecker : MonoBehaviour {

	private TheaAI theaAI;

	// Use this for initialization
	void Start () {
		theaAI = transform.parent.gameObject.GetComponentInParent<TheaAI> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player"))
			theaAI.startBattle = true;
	}

}
