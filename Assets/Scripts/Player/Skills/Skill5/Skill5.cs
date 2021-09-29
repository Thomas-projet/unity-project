using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill5 : MonoBehaviour
{
    //public Transform attackPoint;

    //public LayerMask enemyLayer;
    //public void UseSpellFromSkill5()
    //{
    //    //Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
    //    Collider[] hitProjectiles = Physics.OverlapBox(attackPoint.position, new Vector3(3/2, 2/2, 5/2), attackPoint.rotation, enemyLayer);

    //    foreach (Collider enemyProjectile in hitProjectiles)
    //    {
    //        Debug.Log("enemyProjectile " + enemyProjectile.name);
    //        EnemyBullet enemyyProjectile = enemyProjectile.GetComponent<EnemyBullet>();
    //        enemyyProjectile.DestroyBullet();
    //    }
    //}

    //private void OnDrawGizmosSelected()
    //{
    //    if (attackPoint.position == null)
    //        return;
    //    Gizmos.matrix = attackPoint.localToWorldMatrix;
    //    Gizmos.color = Color.red;
    //    //Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    //    //Gizmos.DrawCube(Vector3.zero, Vector3.one);
    //    Gizmos.DrawWireCube(Vector3.zero, new Vector3(3, 2, 5));
    //}

}
