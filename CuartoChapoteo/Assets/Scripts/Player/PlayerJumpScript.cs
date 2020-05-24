using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJumpScript : MonoBehaviour
{
    public static PlayerJumpScript instance;
    private Rigidbody2D body;
    private Animator animator;
    [SerializeField]
    private float forceX, forceY;

    private float tresHoldX = 7f;
    private float tresHoldY = 14f;
    private bool setPower, didJump;
    private float maxForceX= 6.45f;
    private float maxForceY= 13.5f;
   
    private Slider powerbar;
    private float powerBarTreshold = 10f;
    private float powerBarValue = 0f;
    //Todo create slider y powerBarThreshold
    private void Awake()
    {
        MakeInstance();
        Init();
    }
    void MakeInstance() 
    {
        if (instance == null) {
            instance = this;
        }
    }
    void Init()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        powerbar = GameObject.Find("PowerBar").GetComponent<Slider>();
        powerbar.minValue = powerBarValue;
        powerbar.maxValue = powerBarTreshold;
        powerbar.value = powerBarValue;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetPower();
    }
    void SetPower() 
    {
        if (setPower)
        {
            forceX += tresHoldX * Time.deltaTime;
            forceY += tresHoldY * Time.deltaTime;
            if (forceX > maxForceX)
            {
                forceX = maxForceX;
            }
            if (forceY > maxForceY)
            {
                forceY = maxForceY;
            }
            powerBarValue += powerBarTreshold * Time.deltaTime;
            powerbar.value = powerBarValue;
        }
    }
    public void givePower(bool power) 
    {
        setPower = power;
        if (!setPower) 
        {
            Jump();
        }
    }
    void Jump() 
    {
        body.velocity = new Vector2(forceX, forceY);
        forceX = forceY = 0;
        didJump = true;
        animator.SetBool("jump", didJump);
        powerBarValue = 0f;
        powerbar.value = powerBarValue;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (didJump) 
        {
            didJump = false;
            animator.SetBool("jump", didJump);
            if (other.gameObject.tag == "Platform") 
            { 
            }
        }
    }
}
