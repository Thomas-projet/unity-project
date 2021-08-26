using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    private Vector3 _velocity;
    public Vector3 Drag = new Vector3(15, 0, 15);
    public float DashDistance = 0.3f;
    private PlayerManager PM;

    // Start is called before the first frame update
    void Start()
    {
        PM = FindObjectOfType<PlayerManager>();
    }

    public void ChargeFunction()
    {
        _velocity += Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));
        _velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        _velocity.z /= 1 + Drag.z * Time.deltaTime;
        PM.controller.Move(_velocity * Time.deltaTime);
    }
}
