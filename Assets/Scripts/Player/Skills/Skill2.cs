using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRangeX = 2.5f;
    public float attackRangeY = 2.5f;
    public float attackRangeZ = 2.5f;

    public LayerMask enemyLayer;


    public void UseSpellFromSkill2()
    {
        Debug.Log("skill 2 activated");
        //Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
        Collider[] hitEnemies = Physics.OverlapBox(attackPoint.position, new Vector3(attackRangeX/2, attackRangeY/2, attackRangeZ/2), attackPoint.rotation, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Skill 2 hit " + enemy.name);
            EnemyManager enemyy = enemy.GetComponent<EnemyManager>();
            enemyy.TakeDamage(5);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint.position == null)
            return;
        Gizmos.matrix = attackPoint.localToWorldMatrix;
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        //Gizmos.DrawCube(Vector3.zero, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(attackRangeX, attackRangeY, attackRangeZ));
    }

}
