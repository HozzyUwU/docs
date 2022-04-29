using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseObject : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI myText;
    public void Setup(string newDialogueStep)
    {
        myText.text = newDialogueStep;
    }
}
