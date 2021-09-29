using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager GM;
    private PlayerManager PM;
    private instantiateSkills IS;

    private Animator animator;

    Skill1 ScriptFromSkill1;
    Skill2 ScriptFromSkill2;
    Skill3 ScriptFromSkill3;
    Skill4 ScriptFromSkill4;
    Skill5 ScriptFromSkill5;

    Weapon1 ScriptFromWeapon1;
    Weapon2 ScriptFromWeapon2;
    Charge ScriptCharge;
    Grab ScriptGrab;
    PhotonView view;

    GameObject test;
    SpellCooldown ScriptSkillA;

    public GameObject skill1;
    public GameObject antiProjectiles;

    public LayerMask enemyLayer;

    //TESTS
    private int testy = 0;

    //Skills CDs
    private float skill1CD = 5f;

    public bool attackingBool = false;


    private int spinCount = 0;





    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        PM = FindObjectOfType<PlayerManager>();
        IS = FindObjectOfType<instantiateSkills>();

        animator = GetComponentInChildren<Animator>();

        //Skill 1
        ScriptFromSkill1 = FindObjectOfType<Skill1>();

        //Skill 2
        ScriptFromSkill2 = FindObjectOfType<Skill2>();

        //Skill 3
        ScriptFromSkill3 = FindObjectOfType<Skill3>();

        //Skill 4
        ScriptFromSkill4 = FindObjectOfType<Skill4>();

        //Skill 5
        ScriptFromSkill5 = FindObjectOfType<Skill5>();

        //
        ScriptFromWeapon1 = FindObjectOfType<Weapon1>();
        ScriptFromWeapon2 = FindObjectOfType<Weapon2>();
        ScriptCharge = FindObjectOfType<Charge>();
        ScriptGrab = FindObjectOfType<Grab>();

        test = GameObject.Find("skillA");
        ScriptSkillA = GM.skillA.GetComponent<SpellCooldown>();
        ScriptSkillA.cooldownTime = 5.0f;

        view = GetComponent<PhotonView>();



    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (view != null && view.isMine)
        {
            //Skill 5
            if (Input.GetKey("b"))
            {
                antiProjectiles.SetActive(true);
                //ScriptFromSkill5.UseSpellFromSkill5();
            }
            else
            {
                antiProjectiles.SetActive(false);
            }


            //Skill 4
            if (Input.GetKey("n"))
            {
                ScriptFromSkill4.UseSpellFromSkill4();
            }

            //Skill 3
            if (Input.GetKey("m"))
            {
                ScriptFromSkill3.UseSpellFromSkill3();
            }

            //Skill 2
            if (Input.GetKey(KeyCode.Alpha8))
            {
                animator.SetBool("spin", true);
            }

            //Skill 1
            if (Input.GetKey(KeyCode.Alpha7))
            {
                animator.SetBool("smash", true);
            }



            if (Input.GetKey(KeyCode.Alpha9))
            {

                if (!IS.sc.isCooldown)
                {
                    //animator.Play("Great Sword Slash 0");
                    IS.sc.UseSpell();
                    //animator.SetBool("attacking", true);

                    attackingBool = true;
                    animator.SetBool("attacking", attackingBool);

                    Debug.Log("HEY");
                    //
                    //animator.SetTrigger("attackTrigger");
                }
            }



            if (Input.GetKey(KeyCode.Alpha2))
            {
                //
                //animator.SetBool("attacking", true);
                animator.SetTrigger("stopTrigger");

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
                    ScriptSkillA.UseSpell();
                    if (!ScriptFromWeapon2.isOnCooldown)
                    {
                        PM.FaceTarget();
                    }

                    ScriptFromWeapon2.Shoot();

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

    public void TEST()
    {
        Debug.Log("TEST");
        attackingBool = false;
        animator.SetBool("attacking", attackingBool);
        //
        //animator.SetTrigger("stopTrigger");
    }

    public void SpinEvent()
    {
        Debug.Log("SpinEvent" + spinCount);
        spinCount++;
        if (spinCount == 3)
        {
            animator.SetBool("spin", false);
            spinCount = 0;
        }


        //
        //animator.SetTrigger("stopTrigger");
    }




}
