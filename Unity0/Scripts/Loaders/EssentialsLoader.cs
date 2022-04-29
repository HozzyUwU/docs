using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    // Adding objects we need to load into the scene
    [Header("Objects we need to load into the scene:")]
    public GameObject UIScren;
    public GameObject Player;

    // Start is called before the first frame update
    void Awake()
    {
        if(UIFade.instance == null)
        {
            Instantiate(UIScren);
        }
        if(MyPlayerController.instance == null)
        {
            Instantiate(Player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
