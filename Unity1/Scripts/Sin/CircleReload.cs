using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleReload : MonoBehaviour
{
    float n;

    void Start()
    {
        RectTransform v = gameObject.GetComponent<RectTransform>();
        Debug.Log(transform.position);
        Debug.Log(transform.localPosition);
        Debug.Log(v.GetComponent<Transform>());

    }
    public void Sin(float num)
    {
        
        //num += 0.5f;
        transform.position = new Vector2(transform.position.x, 200f+num);
    }
}
