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
            player.MoveRight(true);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
            player.MoveLeft(true);
		}

        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            player.MoveRight(false);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            player.MoveLeft(false);
        }


	}
}
