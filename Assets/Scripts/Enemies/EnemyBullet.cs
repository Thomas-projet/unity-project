using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public float turn;
    public Rigidbody rb;
    public int damage = 10;

    [SerializeField]
    private GameManager GM;
    [SerializeField]
    private ScriptA scriptA;

    SpawnPlayers SP;
    Transform target;

    public void Start()
    {
        SP = FindObjectOfType<SpawnPlayers>();
        target = SP.player.transform;
    }
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform.position + new Vector3(0, target.transform.lossyScale.y / 1.1f, 0));
        }


        rb.velocity = transform.forward * speed;

    }

    private void OnTriggerEnter(Collider hitInfo)
    {

        //EnemyManager targetedEnemy = hitInfo.GetComponent<EnemyManager>();
        //if (targetedEnemy != null)
        //{
        //    targetedEnemy.TakeDamage(damage);
        //}
        Debug.Log(hitInfo.name);
        if (hitInfo.name != "EnemyBullet(Clone)")
        {
            Destroy(gameObject);
        }



    }
}
