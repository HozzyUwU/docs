using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueObject : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI myText;
    [SerializeField] public TextMeshProUGUI myName;
    GameObject inkFile;
    private bool isNPC;
    //private bool CoState = true;

    void Start()
    {
        inkFile = GameObject.Find("/Canvases/DoalogueCanvas");
    }
    public void Setup(string newDialogueStep, string CharacterName, bool isNPCState)
    {
        isNPC = isNPCState;
        myName.text = CharacterName;
        StartCoroutine(DrawLetters(newDialogueStep));
    }
     IEnumerator DrawLetters(string sentence)
    {
        myText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            myText.text += letter;
            yield return new WaitForSeconds(0.009f);
        }
        if(isNPC)
        {
        inkFile.GetComponent<InkExample>().MakeNewButtons();
        }
    }
}
