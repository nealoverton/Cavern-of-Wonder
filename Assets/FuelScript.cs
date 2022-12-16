using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelScript : MonoBehaviour
{
    public LogicScript logic;
    public BalloonScript balloon;
    public int fuelValue;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        balloon = GameObject.FindGameObjectWithTag("Balloon").GetComponent<BalloonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * logic.scrollSpeed) * Time.deltaTime;

        if (transform.position.x < logic.deadZone) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.layer == 3 && balloon.stillAirborne)
        {
            balloon.addFuel(fuelValue);
            Destroy(gameObject);
        }
    }
}
