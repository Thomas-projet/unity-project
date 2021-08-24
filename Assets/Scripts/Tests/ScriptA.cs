using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptA : MonoBehaviour
{
    public string name;

    public void Function1(string name)
    {
        Debug.Log(Function2(name));
    }

    public string Function2(string name)
    {
        return name + " has executed my function1 ! I am " + this.name + " btw";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
