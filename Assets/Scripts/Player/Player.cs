using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool grounded = true;
	public float jumpHeight;
	public float moveSpeed;

	private bool attacking = false;
	private GameObject playerObject;

	private float attackTimer = 0;
	private float attackCD = 0.3f;

	public Collider2D attackTrigger;
	private Animator anim;

	public bool goLeft = false;
	public bool goRight = false;
	public bool jump = false;
	public bool attack = false;

	public int lives = 3;
	public int hitPoints = 5;

	public bool facingRight = true;

	// Use this for initialization
	void Start () {
		playerObject = gameObject;
	}

	// Update is called once per frame
	void Update () {

		if (goRight) {
			playerObject.transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
			playerObject.transform.localEulerAngles = new Vector2 (0, 0);
			playerObject.GetComponent<Animator> ().SetFloat ("Speed", Mathf.Abs(1.0f));
			facingRight = true;
		} 

		if (goLeft) {
			playerObject.transform.Translate (-Vector2.left * moveSpeed * Time.deltaTime);
			playerObject.transform.localEulerAngles = new Vector2 (0, 180);
			playerObject.GetComponent<Animator> ().SetFloat ("Speed", Mathf.Abs (1.0f));
			facingRight = false;
		} 

		if (!goRight && !goLeft) {
			playerObject.GetComponent<Animator> ().SetFloat ("Speed", 0);
		}

		if (jump && grounded) {
			playerObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpHeight);
		}

		GetComponent<Animator> ().SetBool ("Grounded", grounded);

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

		//goLeft = goRight = attack = jump = false;
        jump = false;

	}

	void Damage(int dmg) {
		
		hitPoints -= dmg;
		Debug.Log ("Damage");

		/*
		if (facingRight) {
			playerObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 10.0f);
		} else if (facingRight) {
			playerObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 10.0f);
		}
		*/

	}

    public void MoveLeft(bool move) {
        goLeft = move;
    }

    public void MoveRight(bool move) {
        goRight = move;
    }

	public void Jump() {
        jump = true;
    }

    public void Attack(bool move) {
        attack = move;
    }

}
