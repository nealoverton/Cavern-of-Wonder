using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public GameObject obstacle;
    public LogicScript logic;
    public float baseSpawnRate = 10;
    public float spawnRateVariance;
    public float spawnRateAcceleration;
    public float spawnRateAccelerationThreshold;
    private float maxSpawnRate = 3;
    private float spawnRate;
    private float timer = 0;
    public float heightOffset;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnRate = baseSpawnRate;
        spawnObstacle();
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
            spawnObstacle();
            timer = 0;
        }
    }

    void spawnObstacle () 
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(obstacle, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

        if(logic.playerScore % spawnRateAccelerationThreshold == 0 && baseSpawnRate > maxSpawnRate)
        {
            baseSpawnRate -= spawnRateAcceleration;
            
            if(baseSpawnRate < maxSpawnRate)
            {
                baseSpawnRate = maxSpawnRate;
            }
        }

        spawnRate = baseSpawnRate - Random.Range(0, spawnRateVariance);
        if(spawnRate < maxSpawnRate)
        {
            spawnRate = maxSpawnRate;
        }
    }
}
