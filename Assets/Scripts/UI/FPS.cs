using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private static float fps;
    private void OnGUI()
    {
        fps = 1f / Time.deltaTime;
        GUI.Label(new Rect(Screen.width-55,0,100,100),"FPS:"+(int)fps); 
    }

}
