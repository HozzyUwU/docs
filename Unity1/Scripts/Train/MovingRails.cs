using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRails : MonoBehaviour
{
    GameObject Player;
    public float Speed=0.005f;
    float charSpeed;
    float charDir;
    float width;
    void Start()
    {
        width = GetComponent<SpriteRenderer>().sprite.rect.width / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit * transform.lossyScale.x;
        Player = GameObject.Find("WeztBoy");
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < Player.transform.position.x-width*3)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        charDir = Player.GetComponent<PlayerController>().movementDirection.x;
        charSpeed = Player.GetComponent<PlayerController>().movementSpeed;
        if(charDir < 0)
        {
            transform.position = new Vector2(transform.position.x-Speed*Time.deltaTime-0.5f*Time.deltaTime, transform.position.y);
        }
        else if(charDir > 0)
        {
            transform.position = new Vector2(transform.position.x-Speed*Time.deltaTime+0.5f*Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x-Speed*Time.deltaTime, transform.position.y);
        }

    }
}
