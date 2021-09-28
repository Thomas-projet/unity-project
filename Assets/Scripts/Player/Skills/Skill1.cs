using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    public Transform attackPoint;
    private float attackRange = 2.5f;
    public LayerMask enemyLayer;


    public void UseSpellFromSkill1()
    {
            Debug.Log("skill 1 activated");
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

            foreach (Collider enemy in hitEnemies)
            {
                Debug.Log("Skill 1 hit " + enemy.name);
                EnemyManager enemyy = enemy.GetComponent<EnemyManager>();
                enemyy.TakeDamage(5);
            }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint.position == null)
            return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
