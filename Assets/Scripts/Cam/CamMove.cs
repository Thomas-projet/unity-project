using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 
public class CamMove : MonoBehaviour {

    [TagField]
    public string Tag = string.Empty;

    void Start(){
        CinemachineCore.GetInputAxis = GetAxisCustom;


        var vcam = GetComponent<CinemachineVirtualCameraBase>();
        if (vcam != null && Tag.Length > 0)
        {
            var targets = GameObject.FindGameObjectsWithTag(Tag);
            if (targets.Length > 0)
                vcam.LookAt = vcam.Follow = targets[0].transform;
        }
    }



    public float GetAxisCustom(string axisName){
        if(axisName == "Mouse X"){
            //if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
            //{
            //    return -UnityEngine.Input.GetAxis("Mouse X");
            //}
            //    return 0;

                return -UnityEngine.Input.GetAxis("Mouse X");


        }
        else if (axisName == "Mouse Y"){
            //if (Input.GetMouseButton(1) ||  Input.GetMouseButton(0))
            //{
            //    return -UnityEngine.Input.GetAxis("Mouse Y");
            //} else{
            //    return 0;
            //}


                return -UnityEngine.Input.GetAxis("Mouse Y");
        }
        return UnityEngine.Input.GetAxis(axisName);
    }
}