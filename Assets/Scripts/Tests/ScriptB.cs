using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptB : MonoBehaviour
{
    [SerializeField]
    private new string name;

    [SerializeField]
    private ScriptA[] scriptsA;
    // Start is called before the first frame update
    void Start()
    {
        scriptsA = FindObjectsOfType<ScriptA>();
        
        foreach (ScriptA sA in scriptsA)
        {
            sA.Function1(name);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
