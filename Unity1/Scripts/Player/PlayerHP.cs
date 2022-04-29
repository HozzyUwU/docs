using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [Space]
    [Header("H&D stuff: ")]
    public int PLHealth = 100;
    public int PLDmg = 20;
    bool state = true;
    [Space]
    [Header("Statistics: ")]
    public float BulletBorder;
    
    public void WasHiited(int inputDMG)
    {
        PLHealth -= inputDMG;
    }

    void Update()
    {
        if(PLHealth <= 0 && state)
        {
            Debug.Log("U dead!");
            state = false;
        }
    }

}
