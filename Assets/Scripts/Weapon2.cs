using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Shoot();
        }
        //if (!alreadyAttacked)
        //{
        //    Shoot();
        //    alreadyAttacked = true;
        //    Invoke(nameof(ResetAttack), timeBetweenAttacks);
        //}
    }

    void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);

    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }


}
