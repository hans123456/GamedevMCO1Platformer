using UnityEngine;
using System.Collections;

public class PlayerAttackTrigger : MonoBehaviour {

	private int dmg = 1;

	void OnTriggerEnter2D(Collider2D col) {

		if (col.tag.Equals ("Enemy")) {
			col.SendMessageUpwards ("Damage", dmg);
		}

	}

}
