using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public RaycastHit targetInfo;
    Vector3 keepDirectionUnderLeftClick = Quaternion.Euler(0f, 0, 0f) * Vector3.forward;
    public float castingTime;
    public Transform ChargePoint;

    public int test = 3;

    Camera cam;
    public EnemyManager targetedEnemy = null;

    public bool isNotAttacking = true;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha4))
        {
            test = 5;

        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out targetInfo))
            {
                //Debug.Log("From Manager We hit " + targetInfo.collider.name + " " + targetInfo.point);
                Collider hitInfo = targetInfo.collider;

                if ((hitInfo.GetComponent("EnemyManager") as EnemyManager) != null)
                {
                    EnemyManager newTargetedEnemy = hitInfo.GetComponent<EnemyManager>();

                    if (newTargetedEnemy.Targeted() == true)
                    {
                        if (targetedEnemy != null && targetedEnemy != newTargetedEnemy)
                        {
                            targetedEnemy.Detargeted();
                        }

                        targetedEnemy = newTargetedEnemy;

                    }
                    else
                    {
                        targetedEnemy = null;
                    }
                }
                else
                {
                    if (targetedEnemy != null)
                    {
                        targetedEnemy.Detargeted();
                    }
                    targetedEnemy = null;

                }



            }

        }
    }


}
