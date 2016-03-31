using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	private GameObject playerObject;
	private Player player;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		player = playerObject.GetComponentInParent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey(KeyCode.RightArrow) ) {
			player.goRight = true;
			//playerObject.transform.Translate (Vector2.right * player.moveSpeed * Time.deltaTime);
			//playerObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * player.moveSpeed);
			//playerObject.transform.localEulerAngles = new Vector2 (0, 0);
			//playerObject.GetComponent<Animator> ().SetFloat ("Speed", Mathf.Abs(1.0f));
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			player.goLeft = true;
			//playerObject.transform.Translate (-Vector2.left * player.moveSpeed * Time.deltaTime);
			//playerObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * player.moveSpeed);
			//playerObject.transform.localEulerAngles = new Vector2 (0, 180);
			//playerObject.GetComponent<Animator> ().SetFloat ("Speed", Mathf.Abs (1.0f));
		} else {
			//playerObject.GetComponent<Animator> ().SetFloat ("Speed", 0);
		}


	}
}
