using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowingBullet : MonoBehaviour
{
    public float speed = 20f;
    public float turn;
    public Rigidbody rb;
    public int damage = 10;

    [SerializeField]
    private GameManager GM;
    [SerializeField]
    private ScriptA scriptA;

    EnemyManager target;

    public void Start()
    {
        GM = FindObjectOfType<GameManager>();
        target = GM.targetedEnemy;
    }
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform.position + new Vector3(0,target.transform.lossyScale.y/1.1f,0));
        }
            
        
        rb.velocity = transform.forward * speed;

    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        EnemyManager targetedEnemy = hitInfo.GetComponent<EnemyManager>();
        if (targetedEnemy != null)
        {
            targetedEnemy.TakeDamage(damage);
        }

        if(hitInfo.name != "FollowingBullet(Clone)" && hitInfo.name != "Player")
        {
            Destroy(gameObject);
        }



    }
}
