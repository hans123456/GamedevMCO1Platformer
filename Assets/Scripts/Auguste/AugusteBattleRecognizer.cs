using UnityEngine;
using System.Collections;

public class AugusteBattleRecognizer : MonoBehaviour {

	public GameObject entranceWall;
	public Auguste auguste;
	private AugusteAI augusteAI;
	private bool win = false;
	
	// Use this for initialization
	void Start () {
		augusteAI = auguste.gameObject.GetComponent<AugusteAI> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (auguste.hitPoints <= 0) {
			win = true;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag.Equals ("Player")) {
			entranceWall.SetActive (true);
			augusteAI.startBattle = true;
		}
	}

	void OnGUI () {
		if (win) {
			var centeredStyle = GUI.skin.GetStyle("Label");
			centeredStyle.fontSize = 50;
			centeredStyle.alignment = TextAnchor.UpperCenter;
			GUI.Label (new Rect (Screen.width/2 - 150, Screen.height / 2 - 30, 300, 60), "You Win!", centeredStyle);
		}
	}

}
