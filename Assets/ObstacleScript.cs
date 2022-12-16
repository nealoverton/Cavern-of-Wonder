using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {   
        // int orientation = 1;

        if(Random.Range(0, 2) >= 1)
        {
            transform.localScale = transform.localScale - (new Vector3(0, 2, 0));
        }

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
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
}
