using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    public bool isCooldown = false;
    private float cooldownTime = 3.0f;
    public float cooldownTimer = 0.0f;

    public LayerMask enemyLayer;

    private void Update()
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

    public void UseSpellFromSkill4()
    {
        if (isCooldown)
        {
            // user has clicked spell while in use
        }
        else
        {
            isCooldown = true;
            cooldownTimer = cooldownTime;
            Shoot();
        }

    }
    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);

    }

}
