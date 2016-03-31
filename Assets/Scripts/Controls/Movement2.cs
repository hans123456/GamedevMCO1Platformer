using UnityEngine;
using System.Collections;

public class Movement2 : buttons {
	
    public enum type { LeftB, RightB, JumpB, AttackB };
    public type buttType;

    private GameObject playerObject;
    private Rigidbody2D playerRigid;
	private Player player;
    private GUITexture buttonTexture;
   
    void Start()
    {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		playerRigid = playerObject.GetComponent<Rigidbody2D>();
		player = playerObject.GetComponentInParent<Player> ();
		buttonTexture = gameObject.GetComponentInParent<GUITexture> ();
    }

    void Update()
    {
        TouchInput(buttonTexture);
    }

    void OnFirstTouchBegan()
    {
        switch (buttType)
        {
            case type.JumpB:
                //playerRigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
				player.jump = true;
				//playerObject.transform.Translate(Vector2.up * player.jumpHeight * Time.deltaTime);
				break;
			case type.AttackB:
				player.attack = true;
				break;
        }
    }

    void OnFirstTouch()
    {
        switch (buttType)
        {
			case type.LeftB:
				player.goLeft = true;
				//playerObject.transform.Translate(-Vector2.right * player.moveSpeed * Time.deltaTime);
                break;
			case type.RightB:
				player.goRight = true;
				//playerObject.transform.Translate(Vector2.right * player.moveSpeed * Time.deltaTime);
                break;
        }
    }

    void OnSecondTouchBegan()
    {
        switch (buttType)
        {
            case type.JumpB:
                //playerRigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
				player.jump = true;
				//playerObject.transform.Translate(Vector2.up * player.jumpHeight * Time.deltaTime);
				break;
			case type.AttackB:
				player.attack = true;
				break;
        }
    }

    void OnSecondTouch()
    {
        switch (buttType)
        {
			case type.LeftB:
				player.goLeft = true;
				//playerObject.transform.Translate(-Vector2.right * player.moveSpeed * Time.deltaTime);
                break;
			case type.RightB:
				player.goRight = true;	
				//playerObject.transform.Translate(Vector2.right * player.moveSpeed * Time.deltaTime);
                break;
        }
    }

}
