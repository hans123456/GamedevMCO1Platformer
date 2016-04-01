using UnityEngine;
using System.Collections;

public class Auguste : MonoBehaviour {

	public float moveSpeed;

	public bool attacking = false;
	private GameObject augusteObject;

	private float attackTimer = 0;
	private float attackCD = 0.3f;

	private Animator anim;

	public bool goLeft = false;
	public bool goRight = false;
	public bool attack = false;

	public GameObject AugusteProjectile;
	private GameObject projectile1, projectile2;
	private float time1, time2;
	public bool facingRight = true;

	public int hitPoints;

	// Use this for initialization
	void Start () {
		augusteObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (hitPoints <= 0) {
			Destroy (gameObject);
		}

		if (attack && !attacking) {
			attacking = true;
			attackTimer = attackCD;

			if (projectile1 == null) {
				projectile1 = Instantiate (AugusteProjectile);
				time1 = Random.Range (0, 2);
			}
			projectile1.transform.position = new Vector3 (transform.position.x + 2, transform.position.y + 2, transform.position.z);

			if (projectile2 == null) {
				projectile2 = Instantiate (AugusteProjectile);
				time2 = Random.Range (0, 2);
			}
			projectile2.transform.position = new Vector3 (transform.position.x - 2, transform.position.y + 2, transform.position.z);

		}

		if (projectile1 != null) {
			projectile1.transform.position = new Vector3 (transform.position.x + 2, transform.position.y + 2, transform.position.z);
		}

		if (projectile2 != null) {
			projectile2.transform.position = new Vector3 (transform.position.x - 2, transform.position.y + 2, transform.position.z);
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTimer = 0;

				if (time1 <= 0) {
					projectile1.GetComponentInParent<AugusteProjectileScript> ().start = true;
					projectile1 = null;
				}

				if (time2 <= 0) {
					projectile2.GetComponentInParent<AugusteProjectileScript> ().start = true;
					projectile2 = null;
				}

			}
		}

		if (!attacking) {
			if (goRight) {
				augusteObject.transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);
				augusteObject.transform.localEulerAngles = new Vector2 (0, 180);
				facingRight = true;
			} else if (goLeft) {
				augusteObject.transform.Translate (-Vector2.right * moveSpeed * Time.deltaTime);
				augusteObject.transform.localEulerAngles = new Vector2 (0, 0);
				facingRight = false;
			}
		}

		goLeft = goRight = attack = false;
		time1 -= Time.deltaTime;
		time2 -= Time.deltaTime;

	}

	void Damage (int dmg) {
		hitPoints -= dmg;
	}

}
