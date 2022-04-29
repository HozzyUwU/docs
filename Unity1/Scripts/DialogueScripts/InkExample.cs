using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkExample : MonoBehaviour
{
    private TextAsset inkJSONAsset;
    private Story story;
    private string CharacterName;
    public string PlayerName;
    private bool isNPC;
    [SerializeField] public GameObject dialoguePrefab;
    [SerializeField] public GameObject responsePrefab;
    [SerializeField] public GameObject DialogueHolder;
    [SerializeField] public GameObject ResponseHolder;
    [SerializeField] public ScrollRect dialogueScroll;
    // Start is called before the first frame update
    void Start()
    {
        isNPC = true;
        story = new Story(inkJSONAsset.text);
        CharacterName = story.variablesState.GetVariableWithName("CharacterName").ToString();
        //Debug.Log(getNextStoryBlock());
        // foreach(Choice choice in story.currentChoices)
        // {
        //    Debug.Log("The index is " + choice.index + " and its text is '" + choice.text +"'");
        // }
        // story.ChooseChoiceIndex(0);
        //Debug.Log(getNextStoryBlock());
        // Debug.Log(getNextStoryBlock());
        PrintNextStoryBlock();
    }

    void PrintNextStoryBlock()
    {
        RefreshView();
        getNextStoryBlock();
        //MakeNewButtons();
        StartCoroutine(ScrollCo());
    }

    void getNextStoryBlock()
    {
        string text = "Story cant continue";
        while(story.canContinue)
        {
            text = story.Continue();
            DialogueObject newDialogObj = Instantiate(dialoguePrefab, DialogueHolder.transform).GetComponent<DialogueObject>();
            if(isNPC)
            {
                newDialogObj.Setup(text, CharacterName, true);
            }
            else
            {
                newDialogObj.Setup(text, PlayerName, false);
            }
            isNPC = true;
            //StartCoroutine(ScrollCo());
        }
    }

    IEnumerator ScrollCo()
    {
        yield return new WaitForSeconds(0.02f);
        //yield return null;
        Debug.Log("done here");
        dialogueScroll.verticalNormalizedPosition = 0f;
        //Debug.Log(dialogueScroll.verticalNormalizedPosition);
    }

    public void MakeNewButtons()
    { 
        foreach(Choice choice in story.currentChoices)
        {
            GameObject Button = Instantiate(responsePrefab, ResponseHolder.transform);
            ResponseObject newResponseObj = Button.GetComponent<ResponseObject>();
            newResponseObj.Setup(choice.text);
            Button.GetComponent<Button>().onClick.AddListener(delegate{ClickButtonChoice(choice);});
        }
    }

    void RefreshView()
    {
        for(int i = 0; i< ResponseHolder.transform.childCount; i++)
        {
            Destroy(ResponseHolder.transform.GetChild(i).gameObject);
        }
        // for(int i = 0; i< DialogueHolder.transform.childCount; i++)
        // {
        //     Destroy(DialogueHolder.transform.GetChild(i).gameObject);
        // }
    }

    void ClickButtonChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        isNPC = false;
        PrintNextStoryBlock();
    }
    
    void Update() 
    {
        //Debug.Log(dialogueScroll.verticalNormalizedPosition);
    }

    public void SetDialogue(TextAsset json)
    {
        inkJSONAsset = json;
    }

    public void ExitFromDialogue()
    {
        Cursor.visible = false;
        gameObject.SetActive(false);
    }
}
