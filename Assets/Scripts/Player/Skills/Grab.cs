using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public void GrabFunction()
    {
        Transform playerTransform =  GameManager.instance.player.transform;
        Transform enemyTransform = GameManager.instance.targetedEnemy.transform;


        if (Vector3.Distance(playerTransform.position, enemyTransform.position) > 5)
        {
            enemyTransform.LookAt(playerTransform.position);
            Vector3 distance = playerTransform.position - enemyTransform.position;
            enemyTransform.position = enemyTransform.position + distance / 10 * Time.deltaTime * 5;
        }
    }
}
