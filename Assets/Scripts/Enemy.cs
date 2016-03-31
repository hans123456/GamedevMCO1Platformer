using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public int lives;
	
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		if (lives <= 0) {
			Destroy(gameObject);
		}
		
	}
	
	void Damage (int dmg) {
		lives -= dmg;
	}

}
