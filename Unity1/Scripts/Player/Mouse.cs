using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [Space]
    [Header("InfoL: ")]
    Vector3 worldPosition;
    public float sense = 1.0f;

    void Start()
    {
        //cam = Camera.main;
    }
    void Update() 
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 3;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.localPosition = worldPosition * sense;    
    }

    // void OnGUI()
    // {
    //     Vector3 point = new Vector3();
    //     Event   currentEvent = Event.current;
    //     Vector2 mousePos = new Vector2();

    //     // Get the mouse position from Event.
    //     // Note that the y position from Event is inverted.
    //     mousePos.x = currentEvent.mousePosition.x;
    //     mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;


    //     point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

    //     transform.position = new Vector2(0, 0);
        
    //     GUILayout.BeginArea(new Rect(20, 20, 250, 120));
    //     GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
    //     GUILayout.Label("Mouse position: " + mousePos);
    //     GUILayout.Label("World position: " + point.ToString("F3"));
    //     GUILayout.EndArea();
    // }

}
