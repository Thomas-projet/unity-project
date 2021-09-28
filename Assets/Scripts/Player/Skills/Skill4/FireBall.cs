using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody rb;

    public float attackRangeX = 2.5f;
    public float attackRangeY = 2.5f;
    public float attackRangeZ = 2.5f;

    public LayerMask enemyLayer;

    public Collider[] enemiesThatWashit = null;
    private bool AAA = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;

    }

    void Update()
    {
        //Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
        Collider[] hitEnemies = Physics.OverlapBox(transform.position, new Vector3(1, 1, 1), Quaternion.identity, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            //Debug.Log("Fireball hit " + enemy.name);
            EnemyManager enemyy = enemy.GetComponent<EnemyManager>();
            if (enemiesThatWashit != null)
            {
                foreach (Collider enemyyy in enemiesThatWashit)
                {
                    AAA = true;
                }
            }

            if (AAA == false)
            {
                Debug.Log("AAA" + enemy.name);
                enemyy.TakeDamage(5);
            }


        }


        AAA = false;

        enemiesThatWashit = hitEnemies;
    }

    private void OnDrawGizmosSelected()
    {
        if (transform.position == null)
            return;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        //Gizmos.DrawCube(Vector3.zero, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(1, 1, 1));
    }
}
