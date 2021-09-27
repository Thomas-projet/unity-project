using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateSkills : MonoBehaviour
{
    public GameObject skill1Prefab;

    [SerializeField]
    public GameObject skill1;

    [SerializeField]
    public SpellCooldown sc;



    // Start is called before the first frame update
    void Start()
    {
        GameObject skill1 = Instantiate(skill1Prefab, new Vector3(97,36,0), Quaternion.identity, transform);
        sc = skill1.GetComponent<SpellCooldown>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (skill1 != null)
        //{
        //    SpellCooldown script = skill1.GetComponent<SpellCooldown>();
        //}
        

        if (Input.GetKey(KeyCode.Alpha9))
        {
            //sc.UseSpell();
            //Debug.Log("AYAYA");
            //Destroy(skill1);
        }
    }
}
