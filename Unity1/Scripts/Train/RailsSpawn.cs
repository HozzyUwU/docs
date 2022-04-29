using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailsSpawn : MonoBehaviour
{
    public GameObject railPrefab;
    public GameObject bgPrefab;
    public GameObject Player;
    float XCor=0f;
    float bgXCor=0f;
    float width;
    float bgWidth;
    Sprite sprite;
    Sprite bgSprite;
    GameObject clone;
    GameObject bgClone;

    void Start()
    {
        //For rails
        sprite = railPrefab.GetComponent<SpriteRenderer>().sprite;
        width = sprite.rect.size.x / railPrefab.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit * railPrefab.transform.lossyScale.x;
        XCor = transform.position.x;
        //For backgrounds
        bgSprite = bgPrefab.GetComponent<SpriteRenderer>().sprite;
        bgWidth = bgSprite.rect.size.x / bgPrefab.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit * bgPrefab.transform.lossyScale.x;
        bgXCor = transform.position.x;
        // clone = Instantiate(railPrefab, new Vector2(0f, transform.position.y), Quaternion.identity);
        // Destroy(clone, 60f);
    }

    void Update()
    {
        //SpawnRails();
        if(Input.GetKeyDown("e"))
        {
            SpawnRails();
        }

    }

    void FixedUpdate()
    {
        SpawnRails();
        SpawnBackground();
    }

    void SpawnRails()
    {
        if(clone == null)
        {
            clone = Instantiate(railPrefab, new Vector2(0f, transform.position.y), Quaternion.identity);
        }
        if(clone == null || clone.transform.position.x+width/2 <= Player.transform.position.x+width*2)
        {
            clone = Instantiate(railPrefab, new Vector2(clone.transform.position.x+width-0.05f, transform.position.y), Quaternion.identity);
            Destroy(clone, 60f);
        }
    }

    void SpawnBackground()
    {
        if(bgClone == null)
        {
            bgClone = Instantiate(bgPrefab, new Vector2(0f, transform.position.y+0.4f), Quaternion.identity);
        }
        else if(bgClone.transform.position.x+bgWidth/2 <= Player.transform.position.x+bgWidth*2)
        {
            bgClone = Instantiate(bgPrefab, new Vector2(bgClone.transform.position.x+bgWidth-0.1f, transform.position.y+0.4f), Quaternion.identity);
            Destroy(bgClone, 60f);
        }
    }
}
