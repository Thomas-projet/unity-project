using UnityEngine;

public class SpawnerSample : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public int EnemyNumber;
    int angle;

    SpawnerSample(){
        angle=0;
    }

    void Start()
    {
        for (int i = 0; i < EnemyNumber; i++)
        {
            SpawnP();
        }
    }

    void SpawnP(){
        int radius = 5;
        Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.right;
        Vector3 spawnPosition = transform.position + direction * radius;
        Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
        angle=angle+45;
    } 
}