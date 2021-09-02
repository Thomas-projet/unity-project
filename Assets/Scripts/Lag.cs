using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lag : MonoBehaviour
{
    protected Vector3 RemotePlayerPosition;
    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        if (view.isMine)
            return;

        var LagDistance = RemotePlayerPosition - transform.position;

        if (LagDistance.magnitude > 5f)
        {
            transform.position = RemotePlayerPosition;
            LagDistance = Vector3.zero;
        }
        RemotePlayerPosition = transform.position;

    }
}
