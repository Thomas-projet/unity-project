using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject[] players;
    public GameObject player;
    public GameObject test;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    private void Awake()
    {
        Debug.Log("playerChoice" + PlayerPrefs.GetInt("playerChoice"));

        GameObject playerPrefab = players[PlayerPrefs.GetInt("playerChoice") - 1];

        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity, 0);
    }

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("PT" + playerPrefab.transform.position);
    }
}
