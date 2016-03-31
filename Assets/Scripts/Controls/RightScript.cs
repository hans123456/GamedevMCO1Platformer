using UnityEngine;
using System.Collections;

public class RightScript : MonoBehaviour {

	private GameObject playerObject;
	private Player player;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		player = playerObject.GetComponentInParent<Player> ();
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount > 0 || Input.GetKey(KeyCode.RightArrow) ) {
			playerObject.transform.Translate (Vector2.right * 4f * Time.deltaTime);
			//playerObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * player.moveSpeed);
			playerObject.transform.localEulerAngles = new Vector2 (0, 0);
			playerObject.GetComponent<Animator> ().SetFloat ("Speed", Mathf.Abs(1.0f));
		} else {
			playerObject.GetComponent<Animator> ().SetFloat ("Speed", 0);
		}

	}

}
