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


    //This is the Transform of the second GameObject
    public Transform m_NextPoint;
    Quaternion m_MyQuaternion;
    float m_Speed = 1.0f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool biscuit = false;
    public bool matriceIsActive = false;


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
        float camAngle = PM.cam.eulerAngles.y;

        if (view != null && view.isMine)
        {
            //Skill 5 Matrice
            if (Input.GetKey("mouse 1"))
            {
                
                matriceIsActive = true;
                //transform.parent.gameObject.transform.rotation = PM.cam.transform.rotation;
                Debug.Log(PM.cam.transform.rotation);
                transform.parent.gameObject.transform.rotation = Quaternion.Euler(0f, camAngle, 0f);
                antiProjectiles.SetActive(true);
                //ScriptFromSkill5.UseSpellFromSkill5();
            }
            else
            {
                matriceIsActive = false;
                antiProjectiles.SetActive(false);
            }


            //Skill 4 FireBall
            if (Input.GetKey(KeyCode.Alpha4))
            {
                transform.parent.gameObject.transform.rotation = PM.cam.transform.rotation;
                ScriptFromSkill4.UseSpellFromSkill4();
            }

            //Skill 3 Charge
            if (Input.GetKey(KeyCode.Alpha3))
            {
                ScriptFromSkill3.UseSpellFromSkill3();
            }



            //Skill 2 AoE
            if (Input.GetKey(KeyCode.Alpha2))
            {
                animator.SetBool("smash", true);
            }


            //Skill 1 AA


            if (Input.GetKey("mouse 0"))
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



            //Ult
            if (Input.GetKey(KeyCode.Alpha8))
            {
                animator.SetBool("spin", true);
            }

            //if (Input.GetKey(KeyCode.Alpha2))
            //{
            //    //
            //    //animator.SetBool("attacking", true);
            //    animator.SetTrigger("stopTrigger");

            //    GameManager.instance.isNotAttacking = false;
            //    if (GM.targetedEnemy != null)
            //    {

            //        PM.FaceTarget();
            //        ScriptFromWeapon1.ShootBullets();
            //    }
            //}

            //else if (Input.GetKey(KeyCode.Alpha3))
            //{

            //    if (GM.targetedEnemy != null)
            //    {
            //        ScriptSkillA.UseSpell();
            //        if (!ScriptFromWeapon2.isOnCooldown)
            //        {
            //            PM.FaceTarget();
            //        }

            //        ScriptFromWeapon2.Shoot();

            //    }
            //}

            //else if (Input.GetKey(KeyCode.Alpha4))
            //{
            //    GameManager.instance.isNotAttacking = false;
            //    if (GM.targetedEnemy != null)
            //    {
            //        PM.FaceTarget();
            //    }
            //    ScriptCharge.ChargeFunction();
            //}

            //else if (Input.GetKey(KeyCode.Alpha5))
            //{
            //    GameManager.instance.isNotAttacking = false;
            //    if (GM.targetedEnemy != null)
            //    {
            //        //FaceTarget(GM.targetedEnemy.transform.position);

            //    }
            //}

            //Grab?
            //else if (Input.GetKey(KeyCode.Alpha6))
            //{
            //    GameManager.instance.isNotAttacking = false;
            //    if (GM.targetedEnemy != null)
            //    {
            //        PM.FaceTarget();
            //        ScriptGrab.GrabFunction();
            //    }
            //}
            if(biscuit)
            {
                transform.parent.gameObject.transform.rotation = Quaternion.Euler(0f, camAngle, 0f);
            }
            Debug.Log("biscuit " + biscuit);
        }
    }

    public void TEST()
    {
        //Debug.Log("TEST");
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

    public void AoeEvent()
    {
        animator.SetBool("smash", false);
    }



}
