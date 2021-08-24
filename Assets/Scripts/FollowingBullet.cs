using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowingBullet : MonoBehaviour
{
    public float speed = 20f;
    public float turn;
    public Rigidbody rb;

    [SerializeField]
    private PlayerMovement PM;
    [SerializeField]
    private ScriptA scriptA;

    void Awake()
    {
        Debug.Log("awake");
    }

    public void Start()
    {
        PM = FindObjectOfType<PlayerMovement>();
        PM.test();

        Debug.Log("speed "+PM.speed);
        scriptA.Function1("name");

        Debug.Log("Start");
    }
    void Update()
    {
        transform.LookAt(PM.targetInfo.transform.position);
        rb.velocity = transform.forward * speed;
        //transform.position = Vector3.MoveTowards(transform.position, PM.targetInfo.point, speed);





        //transform.position = Vector3.MoveTowards(Targeting.hiiit.transform.position, Targeting.hiiit.point, speed);
        //Debug.Log("test"+Targeting.hiiit.transform.position);

        //transform.LookAt(Targeting.myTargetLocation.position);
        //rb.velocity = transform.forward * speed;

    }
}
