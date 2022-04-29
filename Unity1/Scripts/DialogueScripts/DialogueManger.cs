using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManger : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    void Start() 
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueClass dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        Debug.Log("Starting conversation with " + dialogue.name);
        sentences.Clear();
        foreach(string sentence in dialogue.ClassSentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string CurrentSentence =  sentences.Dequeue();
        Debug.Log(CurrentSentence);
        StopAllCoroutines();
        StartCoroutine(DrawLetters(CurrentSentence));
    }

    IEnumerator DrawLetters(string sentene)
    {
        dialogueText.text = "";
        foreach(char letter in sentene.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation.");
    }
}
