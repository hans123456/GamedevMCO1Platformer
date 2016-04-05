using UnityEngine;
using System.Collections;

public class DamageEffect : MonoBehaviour {

	public float damageUIDuration = 0.05f;
	private float currDuration = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (currDuration <= 0) {
			GetComponent<SpriteRenderer> ().color = Color.white;
		} else {
			currDuration -= Time.deltaTime;
		}

	}
		
	void Damage (int dmg) {
		GetComponent<SpriteRenderer> ().color = Color.red;
		currDuration = damageUIDuration;
	}

}
