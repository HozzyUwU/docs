using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingScript : MonoBehaviour
{
    [Space]
    [Header("References: ")]
    public GameObject BloodPrefab;
    GameObject Player;
    PlayerHP scr;
    float bulletBorder;
    public int PLdamage;

    [Space]
    [Header("Coordinates where hit occured: ")]
    public Vector2 CoordinatesWhereHitOccured;
    bool Check;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("/WeztBoy");
        scr = Player.GetComponent<PlayerHP>();
        PLdamage = scr.PLDmg;
        bulletBorder = scr.BulletBorder;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyWhenInvisible();
        AttackLocalObjects();
    }

    void AttackLocalObjects()
    {
        var Hitted = Physics2D.OverlapCircle(transform.position, 0.08f, (1 << 11));
        if (Hitted != null)
        {
            if(Hitted.gameObject.GetComponent<EnemyHP>() != null)
            {
            var ScriptFromHittedGO = Hitted.gameObject.GetComponent<EnemyHP>();
            ScriptFromHittedGO.WasHitted(PLdamage);
            Destroy(gameObject);
            }else
            {
                var ScriptFromHittedGO = Hitted.gameObject.GetComponent<ReactToHit>();
                ScriptFromHittedGO.ProcessHitting();
                Destroy(gameObject);
            }
        }
        if(Check)
        {
            Destroy(gameObject);
        }

    }

    // void AttackLocalObjects()
    // {
    //     void OnCollisionEnter(Collision HittedObj) 
    //     {
    //         if(HittedObj != null)
    //         {
    //             Debug.Log("Bullet hitted something");
    //             Destroy(gameObject);
    //         }
    //     }
    // }

    // void OnCollisionEnter2D(Collision2D HittedObj) 
    // {
    //     //CoordinatesWhereHitOccured = transform.localPosition;
    //     //GameObject Blood = Instantiate(BloodPrefab, transform.position, Quaternion.identity);
    //     //Destroy(Blood, 1.0f);
    //     Destroy(gameObject);
    //     Debug.Log("Bullet hitted something");
    //     if(HittedObj.gameObject.layer == 11)
    //     {   
    //         Debug.Log("Bullet hitted enemy");
    //         var ScriptFromHittedGO = HittedObj.gameObject.GetComponent<ReactToHit>();
    //         ScriptFromHittedGO.ProcessHitting();

    //     }
    // }

    // void OnTriggerEnter2D(Collider2D TrigHittedObj) 
    // {
    //     if(TrigHittedObj.gameObject.layer == 11)
    //     {
    //         Debug.Log("Bullet hitted enemy");
    //         var ScriptFromHittedGO = TrigHittedObj.gameObject.GetComponent<ReactToHit>();
    //         ScriptFromHittedGO.ProcessHitting();
    //         Destroy(gameObject);
    //     }
    // }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Check = true;
    }
    
    void DestroyWhenInvisible() 
    {
        Vector2 BulletPlayerDistance = transform.position - Player.transform.position;
        float distX = Mathf.Abs(BulletPlayerDistance.x);
        float distY = Mathf.Abs(BulletPlayerDistance.y);
        if((distX > Screen.width*0.0025f) || (distY > Screen.height*0.0025f))
        {
            Destroy(gameObject);    
        }
    }

}
