using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public RaycastHit targetInfo;
    Vector3 keepDirectionUnderLeftClick = Quaternion.Euler(0f, 0, 0f) * Vector3.forward;
    public float castingTime;

    public int test = 3;

    Camera cam;
    public Enemy enemy = null;
    bool targetIsAlive = false;

    public bool AAA = true;

    public static PlayerManager instance;
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

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out targetInfo))
            {
                Debug.Log("From Manager We hit " + targetInfo.collider.name + " " + targetInfo.point);
                Collider hitInfo = targetInfo.collider;

                if ((hitInfo.GetComponent("Enemy") as Enemy) != null)
                {
                    Debug.Log("Enemy");
                }
                else
                {
                    Debug.Log("Not Enemy");
                }

                    if ((hitInfo.GetComponent("Enemy") as Enemy) != null)
                {
                    Enemy newEnemy = hitInfo.GetComponent<Enemy>();
                    if (newEnemy.Targeted() == true)
                    {
                        if (enemy != null && enemy != newEnemy)
                        {
                            enemy.Detargeted();
                        }

                        enemy = newEnemy;

                    }
                    else
                    {
                        enemy = null;
                    }
                }
                else
                {
                    if (enemy != null)
                    {
                        enemy.Detargeted();
                    }
                    
                }



            }

        }
    }


}
