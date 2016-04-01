using UnityEngine;
using System.Collections;

public class AugusteAI : MonoBehaviour {

	private GameObject playerObject;
	private Auguste auguste;

	private float attackCD = 3.0f;
	private float currAttackCD = 0;
	private bool startBattle = false;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		auguste = GetComponentInParent<Auguste> ();
		currAttackCD = attackCD;
	}
	
	// Update is called once per frame
	void Update () {

		float relativePoint = playerObject.transform.position.x - transform.position.x;
		float distanceX = Mathf.Abs(transform.position.x - playerObject.transform.position.x);

		if (relativePoint < 0.0 && 
			distanceX < 5) {	// 5 to the left
			startBattle = true;
		}

		if (!startBattle) {
			return;
		}

		if (currAttackCD > 0) {

			currAttackCD -= Time.deltaTime;

			if ((distanceX > 5 || auguste.facingRight) && relativePoint < 0.0) {	// to the left
				auguste.goLeft = true;
			} else if ((distanceX > 5 || !auguste.facingRight) && relativePoint > 0.0) {	// to the right
				auguste.goRight = true;
			}

		} else if (currAttackCD <= 0){

			currAttackCD = attackCD;
			auguste.attack = true;

		}

	}
}
