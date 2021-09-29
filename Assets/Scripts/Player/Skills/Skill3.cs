using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : MonoBehaviour
{
    private PlayerManager PM;
    public float dashSpeed;
    public float dashTime;

    public bool isCooldown = false;
    private float cooldownTime = 1.0f;
    public float cooldownTimer = 0.0f;

    private Animator animator;

    public Transform chargePoint;
    private float chargeCatchRange = 2.5f;
    public LayerMask enemyLayer;

    Collider chargedEnemy = null;





    int count = 0;

    private void Start()
    {
        PM = FindObjectOfType<PlayerManager>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (isCooldown)
        {
            animator.SetBool("dash", true);
            ApplyCooldown();
            
            if(PM.moveDir == new Vector3(0,0,0))
            {
                Debug.Log("PM.moveDir");
                PM.controller.Move(Vector3.forward * dashSpeed * Time.deltaTime);
            }
            PM.controller.Move(PM.moveDir * dashSpeed * Time.deltaTime);
            CatchEnemy();
        }
        else
        {
            animator.SetBool("dash", false);
            count = 0;
            chargedEnemy = null;
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



    public void UseSpellFromSkill3()
    {
        //PM.controller.Move(PM.moveDir * dashSpeed * Time.deltaTime);
        if (isCooldown)
        {
            // user has clicked spell while in use
            
            
        }
        else
        {
            isCooldown = true;
            cooldownTimer = cooldownTime;
            Debug.Log("SKILL 3 cd activated");

        }

    }

    public void CatchEnemy()
    {
        Collider[] hitEnemy = Physics.OverlapSphere(chargePoint.position, chargeCatchRange, enemyLayer);

        foreach (Collider enemy in hitEnemy)
        {
            if (count==0)
            {
                if(enemy != null)
                {
                    chargedEnemy = enemy;
                    count++;
                }

            }

            //Debug.Log("Skill 3 catch " + enemy.name);
            //EnemyManager enemyy = enemy.GetComponent<EnemyManager>();
            //enemyy.transform.position = chargePoint.position;
        }
        if (chargedEnemy!= null)
        {
            chargedEnemy.transform.position = chargePoint.position;
        }
        
    }


    private void OnDrawGizmosSelected()
    {
        if (chargePoint.position == null)
            return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(chargePoint.position, chargeCatchRange);
    }

}
