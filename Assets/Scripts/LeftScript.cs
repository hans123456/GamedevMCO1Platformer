using UnityEngine;
using System.Collections;

public class LeftScript : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 || Input.GetKey(KeyCode.LeftArrow)) {
			player.transform.Translate (Vector2.right * 4f * Time.deltaTime);
			player.transform.eulerAngles = new Vector2 (0, 180);
		}
	}
}
