using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawnerScript : MonoBehaviour
{
    public GameObject fuel;
    public float spawnRate = 10;
    private float timer = 0;
    public float heightOffset = 15;
    // Start is called before the first frame update
    void Start()
    {
        spawnFuel();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        } 
        else
        {
            spawnFuel();
            timer = 0;
        }
    }

    public void spawnFuel()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(fuel, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), -1), transform.rotation);
    }
}
