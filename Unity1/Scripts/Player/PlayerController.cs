using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Space]
    [Header("Character statistics: ")]
    public Vector2 movementDirection;
    //public Vector2 mouseDirection;
    public Vector2 crosshairDirection;
    public Vector2 shootingDirection;
    public float RotationSpeed = 1f;
    float currentRotation = 0f;
    //bool canRotate = true;
    bool isRotating = false;
    //public Vector2 mouseCursorPos;
    //Vector2 NewShoot;
    Vector2 worldPosition;
    Vector3 shift;
    Vector3 pos;
    Vector3 screenBounds;


    [Space]
    [Header("Charactes attributes: ")]
    public float senseha;
    public float movementSpeed;
    public float Radius = 1.0f;
    public float sesnsivity = 1.0f;
    public float Bullet_Base_Speed = 1.0f;
    public float ShootCooldown = 0.5f;
    public float BaseSpeed = 1.0f;
    //public float CrosshairDistance = 1.0f;
    public bool CanShoot = true;
    public bool EndOfAiming;

    [Space]
    [Header("References: ")]
    //public Camera cam;
    public Rigidbody2D rb;
    public Animator animator;
    public Animator AimingAnimator;
    public GameObject crosshair;
    public GameObject OuterCircle;
    //public Text DebugInfoA;
    //public Text Er;
    //public GameObject newCrosshair;
    //public GameObject CrossHairToo;

    [Space]
    [Header("Prefabs: ")]
    public GameObject bulletPrefab;

    //
    

    // Start is called before the first frame update
    void Start()
    {
        //OuterCircle.transform.rotation = Quaternion.Lerp(Quaternion.Euler(0f, 0f, 30f), Quaternion.Euler(0f, 0f, 100f), 0.8f);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 3));
        //OuterCircle.transform.rotation=Quaternion.Euler(0f, 0f, 361f);
        //Debug.Log("my position after 360: "+OuterCircle.transform.eulerAngles.z);
        //DebugInfoA.text = "";
        //OuterCircle.transform.rotation =  Quaternion.Slerp(OuterCircle.transform.rotation, Quaternion.Euler(0f, 0f, 360f), 1f);
        //StartCoroutine(Ritate(45));
        //OuterCircle.transform.rotation =  Quaternion.Slerp(OuterCircle.transform.rotation, Quaternion.Euler(0f, 0f, 90f), 1f);
        //Debug.Log(OuterCircle.transform.localEulerAngles.z);
    }

    void Awake() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;    
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();
        Animate();
        SecondAim();
        StartCoroutine(ShootItself());
        UseDetect();
        // if(Input.GetKeyUp("e"))
        // {
        //     DebugInfoA.text = "";
        //     Er.text = "";
        //     DebugInfoA.text = "" + currentRotation;
        // }
        // if(Input.GetKeyUp("i"))
        // {
        //     DebugInfoA.text += "\nROTATION: " + OuterCircle.transform.eulerAngles.z;
        // }
        //Debug.Log(OuterCircle.transform.localEulerAngles.z);
        
    }

    private void FixedUpdate() 
    {
        //OuterCircle.transform.Rotate(0f, 0f, 1f); 
        //Debug.Log(OuterCircle.transform.localEulerAngles.z);
    }

    // IEnumerator RotateOuterCircle(float degree)
    // {
    //     bool stit = false;
    //     currentRotation += degree;
    //     if(currentRotation == 360f)
    //     {
    //         currentRotation = 360f - 100f*Time.deltaTime - Time.deltaTime;
    //         stit = true;
    //     }
    //     else if(currentRotation>360)
    //     {
    //         OuterCircle.transform.rotation=Quaternion.Euler(0f, 0f, 0f);
    //         currentRotation = 90f;
    //     }
    //     isRotating = true;
    //     Debug.Log("my next rotation: "+currentRotation);
    //     DebugInfoA.text += "\nNew line:\nMY NIOW" + OuterCircle.transform.eulerAngles.z + "\nmy next rotation: "+currentRotation;


    //     while(OuterCircle.transform.eulerAngles.z < currentRotation)
    //     {
    //         if(OuterCircle.transform.eulerAngles.z < 100f*Time.deltaTime)
    //         {
    //             Er.text = "EROR";
    //         }
    //         DebugInfoA.text += "      IN WHILE: MY UUU" + OuterCircle.transform.eulerAngles.z + " my next rotation: "+currentRotation;
    //         OuterCircle.transform.Rotate(0f, 0f, 100f*Time.deltaTime);
    //         //OuterCircle.transform.rotation = Quaternion.Slerp(OuterCircle.transform.rotation, Quaternion.Euler(0f, 0f, currentRotation), 2f*Time.deltaTime);
    //         isRotating = true;
    //         yield return new WaitForSeconds(0.0003f);
    //     }
    //     Debug.Log("my rotation: "+OuterCircle.transform.eulerAngles.z);
    //     //DebugInfoA.text += "\nmy rotation: "+OuterCircle.transform.eulerAngles.z;
    //     isRotating = false;
    //     OuterCircle.transform.rotation=Quaternion.Euler(0f, 0f, currentRotation);
    //     if(stit)
    //     {
    //         OuterCircle.transform.rotation = Quaternion.Euler(0f, 0f, 359.9f);
    //     }
    //     Debug.Log("my new rotation: "+OuterCircle.transform.eulerAngles.z);
    //      DebugInfoA.text += "\nmy new rotation: "+OuterCircle.transform.eulerAngles.z;
    // }

    IEnumerator Ritate(float amount)
    {
        currentRotation += amount;
        float pi;
        float our = 0f;
        isRotating = true;
        while(our < Mathf.Abs(amount))
        {
            pi = 100f*Time.deltaTime;
            if(amount < 0)
            {
                pi = pi*(-1f);
            }
            our += Mathf.Abs(pi);
            OuterCircle.transform.Rotate(0f, 0f, pi);
            //DebugInfoA.text += " " + our + " " + OuterCircle.transform.eulerAngles.z;
            yield return new WaitForSeconds(0.0003f);
        }
        isRotating = false;
        if(currentRotation > 360f)
        {
            currentRotation = currentRotation - 360f;
        }
        else if(currentRotation < -360f)
        {
            currentRotation = currentRotation + 360f; 
        }
        OuterCircle.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
        //mouseDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //mouseDirection = mouseDirection * sesnsivity;
        // crosshairDirection += mouseDirection;
        // crosshairDirection.Normalize();
        // Vector3 mousePos = Input.mousePosition;
        // mousePos.z = 3;
        // worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        // worldPosition = Vector2.ClampMagnitude(worldPosition, Radius);

        

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        shift = new Vector3(x,y,0f);
        pos += senseha * 0.01f * shift;
        pos.x = Mathf.Clamp(pos.x,-Screen.width*0.0018f, Screen.width*0.0018f);
        pos.y = Mathf.Clamp(pos.y, -Screen.height*0.0018f, Screen.height*0.0018f);
        //worldPosition = Vector3.ClampMagnitude(pos, 3f);
        worldPosition = pos;

        crosshairDirection = crosshair.transform.localPosition;
        crosshairDirection.Normalize();
        EndOfAiming = Input.GetButtonUp("Fire1");

    }

    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * BaseSpeed;
    }

    void Animate()
    {
        if (movementDirection != Vector2.zero)
        {
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Speed", movementSpeed);

        if (crosshairDirection != Vector2.zero)
        {
            AimingAnimator.SetFloat("MouseCoorX", crosshairDirection.x);
            AimingAnimator.SetFloat("MouseCoorY", crosshairDirection.y);
        }
    }

    // void Aim()
    // {
    //     if(crosshairDirection != Vector2.zero)
    //     {
    //         crosshair.transform.localPosition = crosshairDirection * CrosshairDistance;
    //         //mouseCursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
    //         //newCrosshair.transform.position = mouseCursorPos;
    //     }
    // }

    void SecondAim()
    {
        crosshair.transform.localPosition = worldPosition;
    }

    // void Shoot()
    // {
    //     //shootingDirection  = crosshair.transform.localPosition;
    //     //shootingDirection.Normalize();

    //     // StartCoroutine(ShootItself());
        
    //     // if(EndOfAiming)
    //     // {
    //     //     StartCoroutine(ShootItself());
    //     //     // GameObject Bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    //     //     // Bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * Bullet_Base_Speed;
    //     //     // Bullet.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
    //     //     // Destroy(Bullet, 2.0f);
    //     // }
    // }

    IEnumerator ShootItself()
    {
        shootingDirection  = crosshair.transform.localPosition;
        shootingDirection.Normalize();
        if(EndOfAiming && CanShoot)
        {
            GameObject Bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * Bullet_Base_Speed;
            Bullet.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            if(!isRotating)
            {
                //StopCoroutine(RotateOuterCircle(90f));
                //StartCoroutine(RotateOuterCircle(90f));
                StartCoroutine(Ritate(-60f));
            }
            Destroy(Bullet, 2.0f);
            CanShoot = false;
            yield return new WaitForSeconds(ShootCooldown);
            CanShoot= true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("WHAT");
    }

    void UseDetect()
    {
        Collider2D[] ObjInRange = Physics2D.OverlapCircleAll(new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), 0.2f, 1 << LayerMask.NameToLayer("Useable"));
        if(ObjInRange.Length != 0)
        {
            GameObject TextObj = GameObject.Find("Canvas/StatisticText");
            Text TextUI = TextObj.GetComponent<Text>();
            string Name = ObjInRange[0].gameObject.name;
            TextUI.text = "Press E to use " + Name;
        }
        else
        {
            GameObject TextObj = GameObject.Find("Canvas/StatisticText");
            Text TextUI = TextObj.GetComponent<Text>();
            TextUI.text = null;
        }

        if(Input.GetKeyUp("e"))
        {
            for(int i = 0; i < ObjInRange.Length; i++)
            {
                ObjInRange[i].gameObject.GetComponent<ActionScript>().ProcessUsing();
                Debug.Log("Campfire");
            }
        }
    }
}
