using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AntiProjectiles : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody rb;

    public Transform point;

    public LayerMask enemyLayer;

    // Start is called before the first frame update

    void FixedUpdate()
    {
        Collider[] hitProjectiles = Physics.OverlapBox(point.position, new Vector3(3/2, 2/2, 5/2), point.rotation, enemyLayer);

        foreach (Collider enemyProjectile in hitProjectiles)
        {
            Debug.Log("enemyProjectile " + enemyProjectile.name);
            Destroy(enemyProjectile.gameObject);
            //EnemyBullet enemyyProjectile = enemyProjectile.GetComponent<EnemyBullet>();
            
            //enemyyProjectile.DestroyBullet();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (transform.position == null)
            return;
        Gizmos.matrix = point.localToWorldMatrix;
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        //Gizmos.DrawCube(Vector3.zero, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(3,2,5));
    }
}
