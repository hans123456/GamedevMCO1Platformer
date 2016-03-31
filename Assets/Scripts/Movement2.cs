using UnityEngine;
using System.Collections;

public class Movement2 : buttons {
    public enum type { LeftB, RightB, JumpB };
    public type buttType;

    public float jumpHeight = 0.0f;
    public float moveSpeed = .0f;

    public GameObject playerGO = null;
    Rigidbody2D playerRigid = null;
    public GUITexture buttonTexture = null;
   
    void Start()
    {
        playerRigid = playerGO.GetComponent<Rigidbody2D>();
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
                playerGO.transform.Translate(Vector2.up * jumpHeight * Time.deltaTime);
				break;
        }
    }

    void OnFirstTouch()
    {
        switch (buttType)
        {
            case type.LeftB:
                SendMessage("LEFT");
                playerGO.transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
                break;
            case type.RightB:
                playerGO.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                break;
        }
    }

    void OnSecondTouchBegan()
    {
        switch (buttType)
        {
            case type.JumpB:
                //playerRigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                     playerGO.transform.Translate(Vector2.up * jumpHeight * Time.deltaTime);

				break;
        }
    }

    void OnSecondTouch()
    {
        switch (buttType)
        {
            case type.LeftB:
                playerGO.transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
                break;
            case type.RightB:
                playerGO.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                break;
        }
    }
}
