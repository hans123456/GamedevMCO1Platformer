using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0|| Input.GetKey(KeyCode.UpArrow)) {
			player.transform.Translate (Vector2.up * 5f * Time.deltaTime);
		}
	}

}
