using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinWave : MonoBehaviour
{
    public float offsetVertical = 10f;
    public float offsetHorizontal = 10f;
    public float shift = 0.005f;
    public GameObject objl;
    public GameObject dotPrefaba;
    float value = 0f;
    float Dpi;
    Vector2 startPos;
    Vector2 Pos;

    void Start()
    {
        Dpi = (3.1415926535f*2)*offsetHorizontal;
        startPos = new Vector2(0f, 0f);
        Pos = transform.position;

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
        GameObject clone = Instantiate(dotPrefaba, transform);
        //objl.GetComponent<CircleReload>().Sin((Mathf.Sin(value/offsetHorizontal))*offsetVertical);
        clone.transform.localPosition = new Vector2(startPos.x + value, (Mathf.Sin(value/offsetHorizontal))*offsetVertical);
        transform.position = new Vector2(transform.position.x-shift, transform.position.y);
        Destroy(clone, 4f);
        if(value > Dpi)
        {
            Debug.Log("lul");
            startPos = new Vector2 (clone.transform.localPosition.x, clone.transform.localPosition.y);
            //transform.position = new Vector2(clone.transform.position.x, clone.transform.position.y);
            value = 0f;
        }
    }

    void MoveRight()
    {
        transform.position = new Vector2(transform.position.x-0.1f, transform.position.y);
    }
}
