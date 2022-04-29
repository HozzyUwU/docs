using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    [Header("Character's strings: ")]
    public string[] lines;

    // booleans
    private bool canActivate;
    public bool isPerson = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canActivate && Input.GetKeyUp(KeyCode.E))
        {
            DialogueScript.instance.SetDialogue(lines, isPerson);
            //canActivate = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            canActivate = true;
        }    
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            canActivate = false;
        }
    }
}
