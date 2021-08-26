using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        EnemyManager targetedEnemy = hitInfo.GetComponent<EnemyManager>();
        if (targetedEnemy != null)
        {
            targetedEnemy.TakeDamage(damage);
        }

        if (hitInfo.name != "Bullet(Clone)" && hitInfo.name != "Player")
        {
            Destroy(gameObject);
        }

    }
}
