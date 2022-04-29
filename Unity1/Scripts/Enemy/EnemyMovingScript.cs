using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingScript : MonoBehaviour
{
    [Space]
    [Header("Statistics: ")]
    public float Speed;
    public float DetectDistance = 100f;
    public bool Hitted, canClear = true;
    public Vector3 ObjectVelocity;
    bool IsRight;
    int layerMask, playerMask;
    float plusdir=0f, minusdir=0f;
    int i = 0;
    [Space]
    [Header("References: ")]
    public Animator anim;
    GameObject Player;
    Rigidbody2D rb;
    List<Vector3> inter = new List<Vector3>();
    List<Vector3> redl = new List<Vector3>();
    List<Vector3> bluel = new List<Vector3>();

    Vector2 nextPos;
    Vector3 PreviousPosition;
    Vector3 NewPositin;
    void Start()
    {
        //shift = new Vector2(0f, 0f);
        layerMask=LayerMask.GetMask("Water", "Player");
        Player = GameObject.Find("/WeztBoy");
        rb = gameObject.GetComponent<Rigidbody2D>();
        PreviousPosition = transform.position;
        NewPositin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        RaycastHit2D kok = Physics2D.Raycast(transform.position, Player.transform.position-transform.position, Vector2.Distance(Player.transform.position, transform.position), layerMask);
        if(kok.collider.tag == Player.tag)
        {
            // Debug.Log("WAY IS "+canClear);
            // if(canClear == true)
            // {
            //     canClear = false;
            //     StartCoroutine(ClearD());
            // }
            inter.Clear();
            i=0;
            Moving();
        }
        else
        {
        // redl.Clear();
        // bluel.Clear();
        // inter.Clear();
        // Joke(transform.position);
        // JokeL(transform.position);
        // plusdir = 0f;
        // minusdir = 0f;
        // //Debug.Log("RED: " + redl.Count);
        // //Debug.Log("BLUE: " + bluel.Count);
        // for(int jo = 0; jo<redl.Count-1; jo++)
        // {
        //     plusdir += Vector2.Distance(redl[jo], redl[jo+1]);
        // }
        // for(int k = 0; k<bluel.Count-1; k++)
        // {
        //     minusdir+=Vector2.Distance(bluel[k], bluel[k+1]);
        // }
        // if(plusdir <= minusdir)
        // {
        //     inter = Choose(redl);
        // }
        // else
        // {
        //    inter = Choose(bluel);
        // }

        redl.Clear();
        bluel.Clear();
        List<Vector3> WayOne = (Choose(Joke(transform.position)));
        List<Vector3> WayTwo = (Choose(JokeL(transform.position)));
        if(CalculateDistance(WayOne) < CalculateDistance(WayTwo))
        {
            inter = WayOne;
        }
        else
        {
            inter = WayTwo;
        }
        i=0;
        Moving();
        // List<Vector3> dad = new List<Vector3>();
        // dad.Add(new Vector3(0f, 0f, 0f));
        // dad.Add(new Vector3(1f, 1f, 0f));
        // dad.Add(new Vector3(2f, 2f, 0f));
        // dad.Add(new Vector3(3f, 3f, 0f));
        // dad.Add(new Vector3(4f, 4f, 0f));
        // dad.Add(new Vector3(5f, 5f, 0f));
        // dad.Add(new Vector3(6f, 6f, 0f));
        // dad.Add(new Vector3(7f, 7f, 0f));
        // dad.Add(new Vector3(7f, 7f, 0f));
        // dad.Add(new Vector3(7f, 7f, 0f));
        // dad.Add(new Vector3(7f, 7f, 0f));
        // dad.Add(new Vector3(7f, 7f, 0f));
        // dad.Add(new Vector3(7f, 7f, 0f));
        // dad.Add(new Vector3(7f, 7f, 0f));
        // dad.Add(new Vector3(7f, 7f, 0f));

        //Debug.Log(WayOne.Count);
        // Per(Choose(WayOne));
        // Per(Choose(WayTwo));
        }
        NewPositin = transform.position;
        ObjectVelocity = (NewPositin - PreviousPosition)*Time.deltaTime;
        PreviousPosition = NewPositin;
    }

    List<Vector3> Per(List<Vector3> list)
    {
        float mindest = CalculateDistance(list);
        List<Vector3> reworkedList = list;
        //Debug.Log("first stage");
        for(int counter = 1; counter <= list.Count/2; counter++)
        {
            Vector3 prevposet = list[counter];
            //Debug.Log("second stage");
            List<Vector3> nut = new List<Vector3>();
            List<Vector3> interList = new List<Vector3>();
            float interDistance = 0f;
            for(int loly = 0; loly < counter; loly++)
            {
                //Debug.Log("third stage");
                interDistance += Vector2.Distance(list[loly], list[loly+1]);
                nut.Add(list[loly]);
            }
            //Debug.Log("forth stage");
            nut.Add(prevposet);
            //Debug.Log("fifth stage");
            redl.Clear();
            bluel.Clear();
            List<Vector3> oneWay = Choose(Joke(prevposet));
            List<Vector3> anotherWay = Choose(JokeL(prevposet));
            //Debug.Log("six stage");
            if(CalculateDistance(oneWay) < CalculateDistance(anotherWay))
            {
                interDistance += CalculateDistance(oneWay);
                interList = AdditionOfLists(nut, oneWay);
            }
            else
            {
                interDistance += CalculateDistance(anotherWay);
                interList = AdditionOfLists(nut, anotherWay);
            }
            if(interDistance < mindest)
            {
                mindest = interDistance;
                reworkedList = interList;

            }
        }
        return reworkedList;
    }

    List<Vector3> AdditionOfLists( List<Vector3> nut, List<Vector3> list)
    {
        foreach(Vector3 vector in list)
        {
            nut.Add(vector);
        }
        return nut;
    }

    float CalculateDistance(List<Vector3> list)
    {
        float distance = 0f;
        for(int counter = 0; counter < list.Count-1; counter++)
        {
            distance += Vector2.Distance(list[counter], list[counter+1]);
        }
        return distance;
    }

    List<Vector3> Joke(Vector3 pos)
    {
        Vector3 pik = Player.transform.position - pos;
        pik.Normalize();
        pik*=0.3f;
        RaycastHit2D jot = Physics2D.Raycast(pos, pik, 1.5f, layerMask);
        if(jot.collider == null)
        {
            Debug.DrawRay(pos, pik, Color.red);
            // Add point in list
            redl.Add(pos + pik);
            Joke(pos+pik);
        }
        else
        {
            if(jot.collider.tag == Player.tag)
            {
                Debug.DrawRay(pos, (Player.transform.position - pos), Color.red);
                // Add point in list (Player.transform.position + pos)
                redl.Add(Player.transform.position + pos);
            }
            else
            {
                float shifto = 0f;
                while(jot.collider != null)
                {
                    shifto += 2f;
                    pik = Quaternion.Euler(0f, 0f, 2f)*pik;
                    jot = Physics2D.Raycast(pos, pik, 1.5f, layerMask);
                    if(shifto > 360f)
                    {
                        break;
                    }
                }
                if(shifto < 360f)
                {
                    Debug.DrawRay(pos, pik, Color.red);
                    // Add point in list (pos + pik)
                    redl.Add(pos + pik);
                    Joke(pos + pik);
                }
            }
        }
        return redl;
    }

    List<Vector3> JokeL(Vector3 pos)
    {
        Vector3 pik = Player.transform.position - pos;
        pik.Normalize();
        pik*=0.3f;
        RaycastHit2D jot = Physics2D.Raycast(pos, pik, 1.5f, layerMask);
        if(jot.collider == null)
        {
            Debug.DrawRay(pos, pik, Color.blue);
            // Add point in list
            bluel.Add(pos + pik);
            JokeL(pos+pik);
        }
        else
        {
            if(jot.collider.tag == Player.tag)
            {
                Debug.DrawRay(pos, (Player.transform.position - pos), Color.blue);
                // Add point in list (Player.transform.position + pos)
                bluel.Add(Player.transform.position + pos);
            }
            else
            {
                float shifto = 0f;
                while(jot.collider != null)
                {
                    shifto += 2f;
                    pik = Quaternion.Euler(0f, 0f, -2f)*pik;
                    jot = Physics2D.Raycast(pos, pik, 1.5f, layerMask);
                    if(shifto > 360f)
                    {
                        break;
                    }
                }
                if(shifto < 360f)
                {
                    Debug.DrawRay(pos, pik, Color.blue);
                    // Add point in list (pos + pik)
                    bluel.Add(pos + pik);
                    JokeL(pos + pik);
                }
            }
        }
        return bluel;
    }

    List<Vector3> Choose(List<Vector3> list)
    {
        List<Vector3> choosenList = new List<Vector3>();
        int i = 0, j = 1;
        // Add first element in new list 
        //inter.Add(list[i]);
        RaycastHit2D vector = Physics2D.Raycast(list[i], list[j]-list[i], Vector2.Distance(list[i], list[j]), layerMask);
        while(j < list.Count-1) 
        {
            while(vector.collider == null && j < list.Count-1)
            {
                j++;
                vector = Physics2D.Raycast(list[i], list[j]-list[i], Vector2.Distance(list[i], list[j]), layerMask);
            }
            i = j - 1;
            vector = Physics2D.Raycast(list[i], list[j]-list[i], Vector2.Distance(list[i], list[j]), layerMask);
            // Add list[i] in new list 
            choosenList.Add(list[i]);
        }
        choosenList.Add(list[list.Count - 1]);
        return choosenList;
    }

    IEnumerator ClearD()
    {
        yield return new WaitForSeconds(1f);
        i=0;
        inter.Clear();
        canClear = true;
    }
    void Moving()
    {
        if((Vector2.Distance(transform.position, Player.transform.position) <= 100f) || Hitted)
        {
            nextPos = (Player.transform.position -transform.position);
            nextPos.Normalize();
            //nextPos = Vector2.MoveTowards(transform.position, Player.transform.position, 1);
            Vector2 Direction = Player.transform.position;
            //Debug.Log(inter.Count+" "+i);
            if(inter.Count>0)
            {
                transform.position = Vector2.MoveTowards(transform.position, inter[i], Speed*Time.deltaTime);
                if(transform.position == inter[i] && i+1<inter.Count)
                {
                    i++;
                }
            }
            else
            {
                if(IsRight)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(Direction.x-0.22f, Direction.y-0.3f), Speed*Time.deltaTime);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(Direction.x+0.22f,Direction.y-0.3f), Speed*Time.deltaTime);
                }
            }
            if(nextPos.x > 0)
            {
                transform.localScale = new Vector3(-1f,1f,1f);
                IsRight = true;
            }
            else if(nextPos.x < 0)
            {
                transform.localScale = new Vector3(1f,1f,1f);
                IsRight = false;
            }
        }
        if(ObjectVelocity != Vector3.zero)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
}
