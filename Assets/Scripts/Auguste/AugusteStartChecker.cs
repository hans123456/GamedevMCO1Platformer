using UnityEngine;
using System.Collections;

public class AugusteStartChecker : MonoBehaviour {

	private AugusteAI augusteAI;

	// Use this for initialization
	void Start () {
		augusteAI = transform.parent.gameObject.GetComponentInParent<AugusteAI> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player"))
			augusteAI.startBattle = true;
	}
		
}
