using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;

    public float cooldownTime = 0.5f;
    private float nextFire = 0.0f;

    public float castTime = 4;
    public bool isOnCooldown = false;
    PlayerMovement ScriptFromPlayer;

    void Start()
    {
        ScriptFromPlayer = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {

        if (ScriptFromPlayer.attack1==true && isOnCooldown == false)
        {
            StartCoroutine(waiter());
            StartCoroutine(cooldown());

            Shoot();
        }

    }

    public void startShooting()
    {
        Debug.Log("startShooting");
        StartCoroutine(waiter());

    }

    public void Shoot()
    {
        Debug.Log("shoot");
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