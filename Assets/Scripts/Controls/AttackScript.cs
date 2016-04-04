using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
	
	private GameObject playerObject;
	private Player player;

	//private bool attacking = false;

	//private float attackTimer = 0;
	//private float attackCD = 0.3f;

	//public Collider2D attackTrigger;
	//private Animator anim;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		player = playerObject.GetComponentInParent<Player> ();
		//attackTrigger.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
            player.Attack(true);
			//attacking = true;
			//attackTimer = attackCD;
			//attackTrigger.enabled = true;
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            player.Attack(false);
        }
		/*
		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTimer = 0;
				attackTrigger.enabled = false;
			}
		}

		player.GetComponent<Animator> ().SetBool ("Attacking", attacking);
		*/
	}

}
