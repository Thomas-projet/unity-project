
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAndDash : MonoBehaviour
{
    public float JumpHeight = 2f;
    public float Gravity = -40;
    public float GroundDistance = 0.2f;
    public LayerMask Platform;
    public Vector3 Drag = new Vector3(15,0,15);
    public float DashDistance = 0.3f;

    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isGrounded = true;
    private Transform _groundChecker;
    PhotonView view;
    private void Start()
    {

            _controller = GetComponent<CharacterController>();
            _groundChecker = transform.GetChild(0);
        view = GetComponent<PhotonView>();

    }

    void Update()
    {
        if (view != null && view.isMine)
        {


            _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Platform, QueryTriggerInteraction.Ignore);
            if (_isGrounded && _velocity.y <= 0)
            {
                _velocity.y = 0f;
            }

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
            }

            if (Input.GetKey("h"))
            {
                _velocity += Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));
            }

            if (Input.GetKey("i"))
            {
                _controller.Move(new Vector3(1,1,1) * 20 * Time.deltaTime);
            }

            _velocity.x /= 1 + Drag.x * Time.deltaTime;
            _velocity.y /= 1 + Drag.y * Time.deltaTime;
            _velocity.z /= 1 + Drag.z * Time.deltaTime;

            //_velocity.y /= 1 + Drag.y * Time.deltaTime;

            _velocity.y += Gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }

    }

}