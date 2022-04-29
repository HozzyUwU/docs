using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueClass dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManger>().StartDialogue(dialogue);
    }
}
