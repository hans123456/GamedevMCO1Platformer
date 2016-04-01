using UnityEngine;
using System.Collections;

public class TheaAI : MonoBehaviour {

	private GameObject playerObject;

	private Thea thea;

	public float attackCD = 3.0f;
	private float currAttackCD = 0;
	public bool startBattle = false;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		thea = GetComponentInParent<Thea> ();
		currAttackCD = attackCD;
	}

	// Update is called once per frame
	void Update () {

		float relativePoint = playerObject.transform.position.x - transform.position.x;
		float distanceX = Mathf.Abs(transform.position.x - playerObject.transform.position.x);

		if (!startBattle) {
			return;
		}

		if (currAttackCD > 0) {
			
			currAttackCD -= Time.deltaTime;

			if ((distanceX > 5 || thea.facingRight) && relativePoint < 0.0) {	// to the left
				thea.goLeft = true;
			} else if ((distanceX > 5 || !thea.facingRight) && relativePoint > 0.0) {	// to the right
				thea.goRight = true;
			}

		} else if (currAttackCD <= 0){
			
			currAttackCD = attackCD;
			thea.attack = true;
		
		}

	}
	
}
