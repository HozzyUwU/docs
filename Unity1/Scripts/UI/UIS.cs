using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIS : MonoBehaviour
{
    public GameObject OuterCircle;
    
    public void RotateOuterCircle()
    {
        float PreviousRotation = OuterCircle.transform.rotation.z;
        while(OuterCircle.transform.rotation.z != (PreviousRotation-90f))
        {
            OuterCircle.transform.Rotate(0f,0f,-5f);
        }
    }
}
