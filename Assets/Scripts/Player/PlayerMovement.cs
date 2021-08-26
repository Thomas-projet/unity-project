using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerManager PM;

    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 keepDirectionUnderLeftClick = Quaternion.Euler(0f,0, 0f) * Vector3.forward;

    public int cooldownAttack1 = 1;
    public int cooldownAttack2 = 1;

    float angle;
    Vector3 moveDir;

    public bool isAttacking = false;

    Weapon ScriptFromWeapon;


    public bool attack1 = false;


    private void Start()
    {
        
        PM = FindObjectOfType<PlayerManager>();
    }

    void FaceTarget(Vector3 enemyPosition)
    {
        Vector3 direction = (enemyPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }

    public void Update()
    {
        attack1 = false;
        //Debug.Log("AAA = " + PlayerManager.instance.AAA);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


            if (Input.GetKey("mouse 0"))
            {
                controller.Move(keepDirectionUnderLeftClick.normalized * speed * Time.deltaTime);

            }

            else
            {
                if (Input.GetKey("mouse 1"))
                {
                    //if not attacking enemies
                    if (!Input.GetKey(KeyCode.Alpha2) || !Input.GetKey(KeyCode.Alpha3))
                    {
                        transform.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
                    }

                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                    keepDirectionUnderLeftClick = moveDir;

                }
                else
                {
                   
                    
                    //if attacking
                    if (Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3))
                    {
                        if (PM.enemy != null)
                        {
                            FaceTarget(PM.enemy.transform.position);
                            attack1 = true;

                            //StartCoroutine(focusWhileAttacking());
                            //StartCoroutine(waiter(cooldownAttack1));
                        }

                    }
                    else
                    {
                        if (PlayerManager.instance.AAA == true)
                        {
                            transform.rotation = Quaternion.Euler(0f, angle, 0f);
                        }
                        else
                        {
                            if (PM.enemy !=null)
                            {
                                FaceTarget(PM.enemy.transform.position);
                            }
                            
                        }


                    }
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                    keepDirectionUnderLeftClick = moveDir;

                }

            }
        }




        else
        {
            if (Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3))
            {
                if (PM.enemy != null)
                {
                    FaceTarget(PM.enemy.transform.position);
                }

            }

        }
    }
    IEnumerator focusWhileAttacking()
    {
        Debug.Log("focusWhileAttacking");
        isAttacking = true;
        yield return new WaitForSeconds(5f);
        isAttacking = false;

    }
}
