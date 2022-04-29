using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactToHit : MonoBehaviour
{
    [Space]
    [Header("Stats: ")]
    public int ScoreAward = 1;
    Animator TargetAnim;
    ScoreCounterScript script;

    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("Canvas/ScoreCounter").GetComponent<ScoreCounterScript>();
        TargetAnim = GetComponent<Animator>();
        Debug.Log("Hello im zombie");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Haha zombie
    public void ProcessHitting()
    {
        Debug.Log("Target was hitted");
        TargetAnim.SetTrigger("IsHitted");
        script.IncreaseScore(ScoreAward);

    }
}
