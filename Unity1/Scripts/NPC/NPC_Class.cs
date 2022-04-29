using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Class : MonoBehaviour
{
    public TextAsset MyDialogue;
    public GameObject canvas;

    void Start() 
    {
        
    }
    public void StartDialogue()
    {
        if(!canvas.activeSelf)
        {
            canvas.SetActive(true);
            Cursor.visible = true;
        }
        canvas.GetComponent<InkExample>().SetDialogue(MyDialogue);
    }
}
