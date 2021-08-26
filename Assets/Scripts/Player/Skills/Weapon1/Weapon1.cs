using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;

    public float castTime = 4;
    public bool isOnCooldown = false;

    public void startShooting()
    {
        StartCoroutine(waiter());
    }

    public void ShootBullets()
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
        Instantiate(bullet, firepoint.position, firepoint.rotation);

    }

    IEnumerator waiter()
    {

            Shoot();
            yield return new WaitForSeconds(0.5f);

    }
    IEnumerator cooldown()
    {
        GameManager.instance.isNotAttacking = false;
        isOnCooldown = true;

        yield return new WaitForSeconds(3f);
        isOnCooldown = false;
        GameManager.instance.isNotAttacking = true;

    }

}