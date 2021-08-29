using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerManager : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    [SerializeField]
    private GameManager GM;

    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 moveDir;
    Vector3 keepDirectionUnderLeftClick = Quaternion.Euler(0f, 0, 0f) * Vector3.forward;

    float angle;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        GM = FindObjectOfType<GameManager>();
    }

    public void FaceTarget()
    {
        Vector3 direction = (GM.targetedEnemy.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }

    public void Update()
    {
        //if (Input.GetKey("mouse 0"))
        //{
        //    currentHealth -= 10;
        //    healthBar.SetHealth(currentHealth);
        //}


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isMoving", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


            if (Input.GetKey("mouse 0"))
            {
                controller.Move(keepDirectionUnderLeftClick.normalized * speed * Time.deltaTime);

            }

            else
            {
                //To look at targeted enemy while attacking : if (Input.GetKey("mouse 1") && GameManager.instance.isNotAttacking == true)

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
                    if (GameManager.instance.isNotAttacking == true)
                    {
                        transform.rotation = Quaternion.Euler(0f, angle, 0f);
                    }
                    else
                    {
                        if (GM.targetedEnemy != null)
                        {
                            FaceTarget();
                        }

                    }

                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                    keepDirectionUnderLeftClick = moveDir;

                }

            }
        }
        else
        {
            animator.SetBool("isMoving", false);

        }
    }
}
