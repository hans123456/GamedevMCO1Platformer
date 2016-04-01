using UnityEngine;
using System.Collections;

public class TheaBattleRecognizer : MonoBehaviour {

	public GameObject entranceWall;
	public GameObject exitWall;
	public Thea thea;
	public GameObject openDoorOnWin;
	private TheaAI theaAI;

	// Use this for initialization
	void Start () {
		theaAI = thea.gameObject.GetComponent<TheaAI> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thea.hitPoints <= 0) {
			entranceWall.SetActive (false);
			exitWall.SetActive (false);
			openDoorOnWin.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
			entranceWall.SetActive (true);
			theaAI.startBattle = true;
		}
	}

}
