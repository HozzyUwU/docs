using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OS : MonoBehaviour
{
    public float offsetVertical = 10f;
    public float offsetHorizontal = 10f;
    public float shift = 1f;
    public GameObject dotPrefaba;
    float value = 0f;
    float Dpi;
    Vector2 startPos;

    void Start()
    {
        Dpi = (3.1415926535f*2)/offsetHorizontal;
        startPos = transform.position;
    }
    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            MoveRight();
        }
    }
    
void FixedUpdate()
    {
        value += shift;
        GameObject clone = Instantiate(dotPrefaba, new Vector2(transform.position.x+value, transform.position.y+(Mathf.Sin(value/offsetHorizontal))*offsetVertical), Quaternion.identity);
        clone.transform.SetParent(transform);
        transform.position = new Vector2(transform.position.x-shift, transform.position.y);
        Destroy(clone, 4f);
        // if(value > Dpi)
        // {
        //     Debug.Log("lul");
        //     startPos = new Vector2 (clone.transform.position.x-value, clone.transform.position.y);
        //     //transform.position = new Vector2(transform.position.x-value, transform.position.y);
        //     value = 0f;
        // }
    }

    void MoveRight()
    {
        transform.position = new Vector2(transform.position.x-0.1f, transform.position.y);
    }
}
