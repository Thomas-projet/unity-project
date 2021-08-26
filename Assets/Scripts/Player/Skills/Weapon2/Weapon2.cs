using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;

    //public float cooldownTime = 5f;
    public bool isOnCooldown = false;

    public float castTime = 1;
    public void ShootFollowingBullets()
    {
        if (isOnCooldown == false)
        {
            StartCoroutine(waiter());
            StartCoroutine(cooldown());

            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);

    }

    IEnumerator waiter()
    {
        for (int i = 0; i < 5; i++)
        {
            if (GameManager.instance.test==3)
            {
                Shoot();
            }

            yield return new WaitForSeconds(0.5f);
        }
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
