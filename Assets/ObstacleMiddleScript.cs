using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public BalloonScript balloon;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        balloon = GameObject.FindGameObjectWithTag("Balloon").GetComponent<BalloonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.layer == 3 && balloon.stillAirborne)
        {
            logic.addScore(1);
        }
        
    }
}
