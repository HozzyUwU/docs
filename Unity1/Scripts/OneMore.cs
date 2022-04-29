using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneMore : MonoBehaviour
{
    Vector3 pos;
    Vector3 shift;
    public float senseha = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        shift = new Vector3(x,y,0f);
        //add input to crosshair
        pos += senseha *shift;
        transform.localPosition = Vector3.ClampMagnitude(pos, 2);

 
        //get center of the screen
        //Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0.0f);
 
        // //move crosshair to origin to apply circular clamp
        // Vector3 crosshairOrigin = transform.position - screenCenter;
 
        // //clamp vector magnitude to 10
        // if (crosshairOrigin.sqrMagnitude > 100.0f)
        // {
        //     crosshairOrigin.Normalize();
        //     crosshairOrigin *= 2.0f;
        // }
 
        // //update crosshair position
        // transform.position = crosshairOrigin + screenCenter;
    }
}
