using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChatable : MonoBehaviour
{
    public GameObject notification;
    void Update()
    {
        Collider2D[] ObjInRange = Physics2D.OverlapCircleAll(new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), 0.2f, 1 << LayerMask.NameToLayer("Chatable"));
        if(ObjInRange.Length != 0)
        {
            notification.SetActive(true);
        }
        else
        {
            notification.SetActive(false);
        }

        if(Input.GetKeyUp("e"))
        {
            for(int i = 0; i < ObjInRange.Length; i++)
            {
                ObjInRange[i].gameObject.GetComponent<NPC_Class>().StartDialogue();
            }
        }
    }
}
