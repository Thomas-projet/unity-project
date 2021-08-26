using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowingBullet : MonoBehaviour
{
    public float speed = 20f;
    public float turn;
    public Rigidbody rb;
    public int damage = 40;

    [SerializeField]
    private GameManager GM;
    [SerializeField]
    private ScriptA scriptA;

    public void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (GM.targetedEnemy != null)
        {
            transform.LookAt(GM.targetInfo.transform.position);
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
