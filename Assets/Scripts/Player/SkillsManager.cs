using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager GM;
    private PlayerManager PM;

    Weapon1 ScriptFromWeapon1;
    Weapon2 ScriptFromWeapon2;
    Charge ScriptCharge;
    Grab ScriptGrab;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        PM = FindObjectOfType<PlayerManager>();

        ScriptFromWeapon1 = FindObjectOfType<Weapon1>();
        ScriptFromWeapon2 = FindObjectOfType<Weapon2>();
        ScriptCharge = FindObjectOfType<Charge>();
        ScriptGrab = FindObjectOfType<Grab>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            GameManager.instance.isNotAttacking = false;
            if (GM.targetedEnemy != null)
            {

                PM.FaceTarget();
                ScriptFromWeapon1.ShootBullets();
            }
        }

        else if (Input.GetKey(KeyCode.Alpha3))
        {
            
            if (GM.targetedEnemy != null)
            {
                PM.FaceTarget();
                ScriptFromWeapon2.ShootFollowingBullets();

            }
        }

        else if (Input.GetKey(KeyCode.Alpha4))
        {
            GameManager.instance.isNotAttacking = false;
            if (GM.targetedEnemy != null)
            {
                PM.FaceTarget();
            }
            ScriptCharge.ChargeFunction();
        }

        else if (Input.GetKey(KeyCode.Alpha5))
        {
            GameManager.instance.isNotAttacking = false;
            if (GM.targetedEnemy != null)
            {
                //FaceTarget(GM.targetedEnemy.transform.position);

            }
        }

        else if (Input.GetKey(KeyCode.Alpha6))
        {
            GameManager.instance.isNotAttacking = false;
            if (GM.targetedEnemy != null)
            {
                PM.FaceTarget();
                ScriptGrab.GrabFunction();
            }
        }
    }
}
