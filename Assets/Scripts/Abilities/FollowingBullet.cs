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
    private PlayerManager PM;
    [SerializeField]
    private ScriptA scriptA;

    public void Start()
    {
        PM = FindObjectOfType<PlayerManager>();
        //Debug.Log("test = " + PlayerManager.instance.test);
       ;
    }
    void Update()
    {
        if (PM.enemy != null)
        {
            transform.LookAt(PM.targetInfo.transform.position);
        }
        
        rb.velocity = transform.forward * speed;

    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log("HIT "+hitInfo.name);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if(hitInfo.name != "FollowingBullet(Clone)" && hitInfo.name != "Player")
        {
            Debug.Log("destroyed ");
            Destroy(gameObject);
        }



    }
}
