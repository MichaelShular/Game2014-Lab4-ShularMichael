using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public Rect screen;
    public Rect safeArea;

    // Update is called once per frame
    void Update()
    {
        screen = new Rect(0, 0, Screen.width, screen.height);
        safeArea = Screen.safeArea;

        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                break;
            case ScreenOrientation.LandscapeLeft:
                break;
            case ScreenOrientation.LandscapeRight:
                break;
            default:
                Debug.Log("Error Orientation");
                break;
        }
    }
}
