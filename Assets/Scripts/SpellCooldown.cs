using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCooldown : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private Text textCooldown;

    private bool isCooldown = false;
    public float cooldownTime = 10.0f;
    private float cooldownTimer = 0.0f;
    public KeyCode test = KeyCode.K;
    public string youhou = "youhou";

    // Start is called before the first frame update
    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(test))
        {
            UseSpell();
        }
        if (isCooldown)
        {
            ApplyCooldown();
        }

    }
    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer<0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }


    public void UseSpell()
    {
        if (isCooldown)
        {
            // user has clicked spell while in use
        }
        else
        {
            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;

        }

    }
}
