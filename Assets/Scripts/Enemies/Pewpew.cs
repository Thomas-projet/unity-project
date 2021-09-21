using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pewpew : MonoBehaviour
{
    public float lookRadius = 10f;
    public float stopDistance;
    SpawnPlayers SP;
    Transform target;
    NavMeshAgent agent;

    public GameObject bullet;
    public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {
        SP = FindObjectOfType<SpawnPlayers>();
        target = SP.player.transform;
        //target = GameManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            target = SP.player.transform;
            //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + target.position);
            float distance = Vector3.Distance(target.position, transform.position);

            if (distance <= lookRadius)
            {

                if (distance <= stopDistance)
                {
                    agent.SetDestination(transform.position);
                }
                else
                {
                    //Debug.Log("PEWPEW");
                    transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
                    Instantiate(bullet, firepoint.position, firepoint.rotation);

                }

            }
        }




    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}
