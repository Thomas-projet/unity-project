using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRushers : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public Transform[] waypoints;

    public bool isCooldown = false;
    public float cooldownTime = 2.0f;
    public float cooldownTimer = 0.0f;

    public float spawnTime;
    public float spawnDelay;
    private int numberOfEnemyToSpawn = 5;

    //Instantiate(ObjectToSpawn, waypoints[0].position, waypoints[0].rotation);
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        numberOfEnemyToSpawn--;
        int randomPoint = Random.Range(0, 3);
        Instantiate(ObjectToSpawn, waypoints[randomPoint].position, waypoints[randomPoint].rotation);

        if (numberOfEnemyToSpawn <= 0)
        {
            CancelInvoke("SpawnObject");
        }

    }

}
