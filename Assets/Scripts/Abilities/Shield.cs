using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    void Update()
    {
        foreach (Transform child in this.transform)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }

        }
    }
}