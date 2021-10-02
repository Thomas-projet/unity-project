using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rusher : MonoBehaviour
{
    [Cinemachine.TagField] public string Tag;
    public GameObject explosionEffect;
    private GameObject target;
    NavMeshAgent agent;
    public float lookRadius = 10f;
    private bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(Tag);
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position) ;
            agent.SetDestination(target.transform.position);
            if (distance <= lookRadius)
            {
                if(!hasExploded)
                {
                    Instantiate(explosionEffect, transform.position, transform.rotation);
                    Debug.Log("BOOOOOOM");
                    hasExploded = true;

                    Destroy(gameObject);
                }

            }
        }
        else
        {
            target = GameObject.FindGameObjectWithTag(Tag);
        }



    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}