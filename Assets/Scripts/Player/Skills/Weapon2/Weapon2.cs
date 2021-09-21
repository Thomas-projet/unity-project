using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;

    //public float cooldownTime = 5f;
    public bool isOnCooldown = false;
    public float cooldownTime = 5.0f;
    public float cooldownTimer = 0.0f;


    public float castTime = 1;


    private void Update()
    {
        if (isOnCooldown)
        {
            ApplyCooldown();
        }

    }
    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
        {
            isOnCooldown = false;
        }
    }

    public void ShootFollowingBullets()
    {
        if (isOnCooldown == false)
        {
            StartCoroutine(waiter());
            StartCoroutine(cooldown());

            Shoot();
        }
    }

    public void Shoot()
    {
        if (isOnCooldown)
        {
            // user has clicked spell while in use
        }
        else
        {
            isOnCooldown = true;
            StartCoroutine(waiter());
            
            cooldownTimer = cooldownTime;
        }
            

    }

    IEnumerator waiter()
    {
        GameManager.instance.isNotAttacking = false;
        for (int i = 0; i < 5; i++)
        {
            if (GameManager.instance.test == 3)
            {
                Instantiate(bullet, firepoint.position, firepoint.rotation);
            }

                yield return new WaitForSeconds(0.5f);

            
        }
        GameManager.instance.isNotAttacking = true;
    }

    IEnumerator cooldown()
    {
        GameManager.instance.isNotAttacking = false;
        isOnCooldown = true;

        yield return new WaitForSeconds(5.0f);
        isOnCooldown = false;
        GameManager.instance.isNotAttacking = true;

    }

}
