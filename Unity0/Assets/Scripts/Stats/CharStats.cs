using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    [Header("Name Of Character")]
    public string charName;
    public Sprite chrImage;

    [Header("Leveling Up")]
    public int playerLevel = 1;
    public int currentEXP;

    [Header("Health Points")]
    public int currentHP;
    public int maxHP = 100;

    [Header("Magick Points")]
    public int currentMP;
    public int maxMP = 30;

    [Header("Stats")]
    public int strength;
    public int defence;
    public int wpnPower;
    public int armrPower;

    [Header("Equipment")]
    public string equippedWeapon;
    public string equippedArmor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
