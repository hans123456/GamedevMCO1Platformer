using UnityEngine;
using System.Collections;

public class EnemyAttackTrigger : MonoBehaviour {

	private int dmg = 1;

	void OnTriggerEnter2D(Collider2D col) {

		if (col.isTrigger == false && col.tag.Equals ("Player")) {
			col.SendMessageUpwards ("Damage", dmg);
		}

	}

}
