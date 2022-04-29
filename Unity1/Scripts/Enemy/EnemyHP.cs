using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [Space]
    [Header("References: ")]
    public EnemyMovingScript EMS;
    public GameObject Foot;
    public GameObject Body;
    public Animator Death;
    public Animator Attack;
    public Animator Walk;
    GameObject PlayerOBJ;

    [Space]
    [Header("H&D stuff: ")]
    public int EnHP = 100;
    public int EnDMG = 20;
    public float AttackDistance = 1f;
    public float AttaclCooldown = 1f;
    public float ChasingTime = 10f;
    bool CanAttack = true;

    void Start() 
    {
        PlayerOBJ = GameObject.Find("/WeztBoy");    
    }

    void Update()
    {
        Vector2 Position = PlayerOBJ.transform.position;
        if((Vector2.Distance(transform.position, new Vector2(Position.x, Position.y-0.2f)) <= AttackDistance) && CanAttack)
        {
            StartCoroutine(ProcessAttack());
            PlayerOBJ.GetComponent<PlayerHP>().WasHiited(EnDMG);
        }
        if(EnHP <= 0)
        {
            //Animate death
            //Debug.Log("Enemy dead");
            GetComponent<EnemyMovingScript>().enabled = false;
            GetComponent<EnemyHP>().enabled = false;
            Death.SetBool("IsDead", true);
            Destroy(Foot);
            Destroy(Body);
            Destroy(gameObject, 5f);
            
        }
    }

    IEnumerator ProcessAttack()
    {
        //set anim state
        Attack.SetTrigger("IsAttacking");
        CanAttack = false;
        yield return new WaitForSeconds(AttaclCooldown);
        CanAttack = true;
    }
    public void WasHitted(int damage)
    {
        EnHP -= damage;
        StartCoroutine(DmgedTimer());
        StartCoroutine(WalkTimer());
    }

    IEnumerator DmgedTimer()
    {
        if(Attack != null && Walk != null)
        {
        Attack.SetBool("IsDmged", true);
        Walk.SetBool("IsDmged", true);
        yield return new WaitForSeconds(0.3f);
        if(Attack != null && Walk != null)
        {
        Attack.SetBool("IsDmged", false);
        Walk.SetBool("IsDmged", false);
        }
        }
    }

    IEnumerator WalkTimer()
    {
        EMS.Hitted = true;
        yield return new WaitForSeconds(ChasingTime);
        EMS.Hitted = false;
    }

}
