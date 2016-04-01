using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float moveSpeed;

	public bool attacking = false;
	private GameObject enemyObject;

	private float attackTimer = 0;
	private float attackCD = 0.3f;

	public Collider2D attackTrigger;
	private Animator anim;

	public bool goLeft = false;
	public bool goRight = false;
	public bool attack = false;

	public bool facingRight = true;

	public int hitPoints;

	// Use this for initialization
	void Start () {
		enemyObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (hitPoints <= 0) {
			Destroy (gameObject);
		}

		if (attack && !attacking) {
			attacking = true;
			attackTimer = attackCD;
			attackTrigger.enabled = true;
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTimer = 0;
				attackTrigger.enabled = false;
			}
		}

		GetComponent<Animator> ().SetBool ("Attacking", attacking);

		if (goRight) {
			enemyObject.transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
			enemyObject.transform.localEulerAngles = new Vector2 (0, 0);
			facingRight = true;
		} else if (goLeft) {
			enemyObject.transform.Translate (-Vector2.left * moveSpeed * Time.deltaTime);
			enemyObject.transform.localEulerAngles = new Vector2 (0, 180);
			facingRight = false;
		}

		goLeft = goRight = attack = false;

	}
		
	void Damage (int dmg) {
		Debug.Log ("Damage");
		hitPoints -= dmg;
	}
		
}
