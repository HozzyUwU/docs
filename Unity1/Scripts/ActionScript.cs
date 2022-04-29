using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    bool state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessUsing()
    {
        Animator UseAnim =  GetComponent<Animator>();
        if(UseAnim.GetBool("NeedUse"))
        {
            state = false;
        }
        else
        {
            state = true;
        }
        UseAnim.SetBool("NeedUse", state);
    }
}
