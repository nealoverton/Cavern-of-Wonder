using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonScript : MonoBehaviour
{
    public Rigidbody2D balloonRigidbody;
    public float burnStrength = 5;
    public float maxUpwardVelocity;
    public float burnDelay;
    public float fuelCount;
    public Text fuelCountText;
    public LogicScript logic;
    public bool stillAirborne = true;
    public AudioSource burnSFX;
    public AudioSource music;
    public AudioSource dingSFX;

    private float lastYPosition = 0;
    private bool isFalling = true;
    // Start is called before the first frame update
    void Start()
    {
       logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
       int roundedFuelCount = (int)fuelCount;
       fuelCountText.text = roundedFuelCount.ToString();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && stillAirborne)
        {

            fuelCount -= Time.deltaTime;
            if(fuelCount < 0)
            {
                fuelCount = 0;
            }
           
            if(fuelCount > 0 && (balloonRigidbody.velocity.magnitude < maxUpwardVelocity || isFalling))
            {
                balloonRigidbody.AddForce(transform.up * burnStrength);
            }
            
            int roundedFuelCount = (int)fuelCount;
            fuelCountText.text = roundedFuelCount.ToString();
        }
   
    }

    // Update is called once per frame
    void Update()
    {
        isFalling = balloonRigidbody.velocity.y <= lastYPosition;
        
        if(Input.GetKeyDown(KeyCode.Space) && stillAirborne)
        {
            if(fuelCount > 0)
            {
                burnSFX.Play();
            }
        }

        if(!stillAirborne || fuelCount == 0)
        {
            burnSFX.Stop();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            burnSFX.Stop();  
        }

        if((transform.position.y > 17 || transform.position.y < -17) && stillAirborne)
        {
            logic.gameOver();
            stillAirborne = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        stillAirborne = false;
    }

    public void addFuel(int fuelToAdd) 
    {
        fuelCount += fuelToAdd;
        dingSFX.Play();
    }
}
