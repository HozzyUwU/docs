using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour
{
    public GameObject roof;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            roof.SetActive(false);
        }    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            roof.SetActive(true);
        }
    }
}

