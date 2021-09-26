using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    public bool isCooldown = false;
    private float cooldownTime = 2.0f;
    private float cooldownTimer = 0.0f;

    public Transform attackPoint;
    private float attackRange = 2.5f;

    public LayerMask enemyLayer;


    void Update()
    {
        if (isCooldown)
        {
            ApplyCooldown();
        }

    }
    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;

        }
    }


    public void UseSpell()
    {
        if (isCooldown)
        {
            // user has clicked spell while in use
        }
        else
        {
            isCooldown = true;
            cooldownTimer = cooldownTime;

            //spell behavior
            Debug.Log("skill 1 activated");
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

            foreach (Collider enemy in hitEnemies)
            {
                Debug.Log("Skill 1 hit " + enemy.name);
                EnemyManager enemyy = enemy.GetComponent<EnemyManager>();
                enemyy.TakeDamage(5);
            }

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
