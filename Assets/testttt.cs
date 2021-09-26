using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testttt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void test()
    {
        Debug.Log("TEST");
    }


        public void PrintEvent(string s)
        {
            Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
        }
}
