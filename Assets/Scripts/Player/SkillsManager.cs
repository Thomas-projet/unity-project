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
    Weapon1 ScriptFromWeapon1;
    Weapon2 ScriptFromWeapon2;
    Charge ScriptCharge;
    Grab ScriptGrab;
    PhotonView view;

    GameObject test;
    SpellCooldown ScriptSkillA;

    public GameObject skill1;
    SpellCooldown ScriptSkill1;

    private Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    //TESTS
    private int testy = 0;
    /// 


    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        PM = FindObjectOfType<PlayerManager>();
        IS = FindObjectOfType<instantiateSkills>();

        animator = GetComponentInChildren<Animator>();

        ScriptFromSkill1 = FindObjectOfType<Skill1>();
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
    void Update()
    {        

        if (view != null && view.isMine)
        {
            animator.SetBool("attacking", false);
            if (Input.GetKey(KeyCode.Alpha9))
            {
                Debug.Log(!ScriptFromSkill1.isCooldown);
                if (!ScriptFromSkill1.isCooldown)
                {
                    //IS.skill1.GetComponent<SpellCooldown>().UseSpell();
                    //SpellCooldown SpellCooldownFromSkill1 = IS.skill1.GetComponent<SpellCooldown>();
                    //SpellCooldownFromSkill1.UseSpell();
                    animator.SetBool("attacking", true);
                    //ScriptFromSkill1.UseSpell();
                }

            }
            else
            {
                animator.SetBool("attacking", false);
            }

            if (Input.GetKey(KeyCode.Alpha8))
            {
                //animator.SetBool("attacking", true);
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

                foreach (Collider enemy in hitEnemies)
                {
                    //Debug.Log("We hit " + enemy.name);
                    if(testy==0)
                    {
                        EnemyManager test = enemy.GetComponent<EnemyManager>();
                        test.TakeDamage(5);
                        testy = 1;
                    }

                }
            }
            else
            {
                //animator.SetBool("attacking", false);
            }



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
    private void OnDrawGizmosSelected()
    {
        if (transform.GetChild(1) == null)
            return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.GetChild(1).position, attackRange);
    }

    public void TEST()
    {
        Debug.Log("skill manager");
    }

    public void Skill1Function()
    {
        ScriptFromSkill1.UseSpell();
    }
}
