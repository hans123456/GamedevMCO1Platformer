using UnityEngine;
using System.Collections;

public class Thea : MonoBehaviour {

	public float moveSpeed;

	public bool attacking = false;
	private GameObject theaObject;

	private float attackTimer = 0;
	private float attackCD = 0.3f;

	private Animator anim;

	public bool goLeft = false;
	public bool goRight = false;
	public bool attack = false;

	public GameObject TheaProjectile;
	public bool facingRight = true;

	public int hitPoints;

	// Use this for initialization
	void Start () {
		theaObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (hitPoints <= 0) {
			Destroy (gameObject);
		}
	
		if (attack && !attacking) {
			attacking = true;
			attackTimer = attackCD;
			GameObject projectile = Instantiate (TheaProjectile);
			projectile.GetComponentInParent<TheaProjectileScript> ().facingRight = facingRight;
			if (facingRight) {
				projectile.transform.position = transform.position;
				projectile.transform.localEulerAngles = new Vector2 (0, 0);
			} else if (!facingRight) {
				projectile.transform.position = transform.position;	
				projectile.transform.localEulerAngles = new Vector2 (0, 180);
			}
			projectile.GetComponentInParent<TheaProjectileScript> ().start = true;
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTimer = 0;
			}
		}

		GetComponent<Animator> ().SetBool ("Attacking", attacking);

		if (!attacking) {
			if (goRight) {
				theaObject.transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
				theaObject.transform.localEulerAngles = new Vector2 (0, 0);
				theaObject.GetComponent<Animator> ().SetFloat ("Speed", Mathf.Abs (1.0f));
				facingRight = true;
			} else if (goLeft) {
				theaObject.transform.Translate (-Vector2.left * moveSpeed * Time.deltaTime);
				theaObject.transform.localEulerAngles = new Vector2 (0, 180);
				theaObject.GetComponent<Animator> ().SetFloat ("Speed", Mathf.Abs (1.0f));
				facingRight = false;
			} else {
				theaObject.GetComponent<Animator> ().SetFloat ("Speed", 0);
			}
		}

		goLeft = goRight = attack = false;

	}

	void Damage (int dmg) {
		Debug.Log ("Damage");
		hitPoints -= dmg;
	}

}
