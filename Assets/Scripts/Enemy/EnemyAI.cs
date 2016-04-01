using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private GameObject playerObject;

	private Enemy enemy;

	private float attackCD = 2.0f;
	private float currAttackCD = 0;

	public float startX;
	public float endX;

	public bool toLeft;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		enemy = GetComponentInParent<Enemy> ();
		currAttackCD = attackCD;
	}

	// Update is called once per frame
	void Update () {
		
		float relativePoint = playerObject.transform.position.x - transform.position.x;
		float distance = Vector3.Distance (transform.position, playerObject.transform.position);


		if (playerObject.transform.position.x > startX && playerObject.transform.position.x < endX) {

			if (distance < Mathf.Abs (startX - endX)) {

				if (distance > 1) {
					if (relativePoint < 0.0) {	// to the left
						enemy.goLeft = true;
					} else if (relativePoint > 0.0) {	// to the right
						enemy.goRight = true;
					}
				}

				if (currAttackCD > 0) {

					currAttackCD -= Time.deltaTime;

				} else if (currAttackCD <= 0) {

					currAttackCD = attackCD;
					enemy.attack = true;

				}
				
			}

		} else {
			
			if (transform.position.x < endX && !toLeft) {
				enemy.goRight = true;
			} else if (transform.position.x >= endX) {
				toLeft = true;
			}

			if (transform.position.x > startX && toLeft) {
				enemy.goLeft = true;
			} else if (transform.position.x <= startX) {
				toLeft = false;
			}

		}

	}

}
