using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    Camera cam;
    Enemy enemy = new Enemy();
    int check = 0;
    public int testy = 6;

    public void testyy()
    {
        Debug.Log("test" + testy);
    }

    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (check == 1)
            {
                enemy.Detargeted();
            }

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                if (hit.collider.name != "Platform")
                {
                    Collider hitInfo = hit.collider;
                    enemy = hitInfo.GetComponent<Enemy>();
                    enemy.Targeted();
                    check = 1;
                }

                
            }
            //if (check == 1)
            //{
            //    FaceTarget(enemy.transform.position);
            //}

        }

    }
    void FaceTarget(Vector3 enemyPosition)
    {
        Vector3 direction = (enemyPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = lookRotation;
    }
}
