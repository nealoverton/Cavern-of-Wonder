using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBalloonScript : MonoBehaviour
{
    public AudioSource music;
    private int xMovement = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + ((new Vector3(xMovement, 0, 0))) * Time.deltaTime;
        // Debug.Log(transform.position.x);


        if(transform.position.x > 12)
        {
            transform.position = new Vector3(12, Random.Range(-3, 3), 0);
            xMovement = -2;
        }

        if(transform.position.x < -12)
        {
           transform.position = new Vector3(-12, Random.Range(-3, 3), 0);
            xMovement = 2;
        }
    }
}
