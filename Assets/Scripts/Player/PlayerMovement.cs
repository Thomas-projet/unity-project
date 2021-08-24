using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    public RaycastHit targetInfo;
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 keepDirectionUnderLeftClick = Quaternion.Euler(0f,0, 0f) * Vector3.forward;

    Camera camm;
    Enemy enemy = new Enemy();
    bool targetIsAlive = false;
    int shooting = 0;

    private void Start()
    {
        camm = Camera.main;
    }

    public void test()
    {
        Debug.Log("TEST");
    }

    void FaceTarget(Vector3 enemyPosition)
    {

        Vector3 direction = (enemyPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            if (targetIsAlive)
            {
                if (enemy != null)
                {
                    enemy.Detargeted();
                }
                else
                {

                }
            }



            Ray ray = camm.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                if (hit.collider.name != "Platform")
                {
                    Collider hitInfo = hit.collider;
                    targetInfo = hit;
                    enemy = hitInfo.GetComponent<Enemy>();
                    enemy.Targeted();
                    targetIsAlive = true;
                }


            }
            //if (check == 1)
            //{
            //    FaceTarget(enemy.transform.position);
            //}

        }


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


            if (Input.GetKey("mouse 0"))
            {
                controller.Move(keepDirectionUnderLeftClick.normalized * speed * Time.deltaTime);

            }

            else
            {
                if (Input.GetKey("mouse 1"))
                {
                    if (Input.GetKey(KeyCode.Alpha2))
                    {
                        //FaceTarget(enemy.transform.position);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
                    }

                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                    keepDirectionUnderLeftClick = moveDir;

                }
                else
                {
                    if (Input.GetKey(KeyCode.Alpha2))
                    {
                        if (enemy != null)
                        {
                            FaceTarget(enemy.transform.position);
                        }

                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0f, angle, 0f);
                    }
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                    keepDirectionUnderLeftClick = moveDir;
                }

            }
        }




        else
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                if (enemy != null)
                {
                    FaceTarget(enemy.transform.position);
                }

            }

        }


     

    }
}
