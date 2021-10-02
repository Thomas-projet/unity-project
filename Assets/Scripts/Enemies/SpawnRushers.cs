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

    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    //Instantiate(ObjectToSpawn, waypoints[0].position, waypoints[0].rotation);
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        int x = Random.Range(0, 3);
        Instantiate(ObjectToSpawn, waypoints[x].position, waypoints[x].rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
