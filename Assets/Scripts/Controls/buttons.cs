using UnityEngine;
using System.Collections;

public class buttons : MonoBehaviour {

    public static bool guiTouch = false;

    
    public void TouchInput(GUITexture texture)
    {
        if(Input.touchCount > 0)
        {
            if(texture.HitTest(Input.GetTouch(0).position)){
                switch(Input.GetTouch(0).phase){
                    case TouchPhase.Began:
                        SendMessage("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnFirstTouchBegan", SendMessageOptions.DontRequireReceiver);
                        guiTouch = true;
                        break;
                    case TouchPhase.Stationary:
                        SendMessage("TP1 Stationary", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
                        guiTouch = true;
                        break;
                    case TouchPhase.Moved:
                        SendMessage("TP1 Moved", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
                        guiTouch = true;
                        break;
                    case TouchPhase.Ended:
                        SendMessage("OnFirstTouchEnded", SendMessageOptions.DontRequireReceiver);
                        guiTouch = false;
                        break;
                }
            }
            if(Input.touchCount > 1 && texture.HitTest(Input.GetTouch(1).position)){
                switch(Input.GetTouch(1).phase){
                    case TouchPhase.Began:
                        SendMessage("OnSecondTouch", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnSecondTouchBegan", SendMessageOptions.DontRequireReceiver);
                        break;
                    case TouchPhase.Stationary:
                        SendMessage("TP2 Stationary", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnSecondTouch", SendMessageOptions.DontRequireReceiver);
                        break;
                    case TouchPhase.Moved:
                        SendMessage("TP2 Moved", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnSecondTouch", SendMessageOptions.DontRequireReceiver);
                        break;
                    case TouchPhase.Ended:
                        SendMessage("OnSecondTouchEnded", SendMessageOptions.DontRequireReceiver);
                        break;
                }
            }
        }

    }
}
