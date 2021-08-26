using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;

    public float cooldownTime = 5f;
    public bool isOnCooldown = false;
    private float nextFire = 0.0f;

    public float castTime = 1;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Alpha3) && isOnCooldown == false)
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
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("bullet " + i);
            Shoot();
            yield return new WaitForSeconds(0.5f);
        }

    }

    IEnumerator cooldown()
    {
        PlayerManager.instance.AAA = false;
        isOnCooldown = true;

        yield return new WaitForSeconds(3f);
        isOnCooldown = false;
        PlayerManager.instance.AAA = true;

    }

}
