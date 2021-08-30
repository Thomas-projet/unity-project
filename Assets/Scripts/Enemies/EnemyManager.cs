using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    private new Renderer renderer;
    private bool isTargeted = false;

    public int maxHealth = 1000;
    public int currentHealth;
    public HealthBar healthBar;

    Color OriginalColor;

    private void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }

        renderer = GetComponentInChildren<Renderer>();
        OriginalColor = renderer.material.color;
    }

    private void Update()
    {
        if (isTargeted)
        {
            if (Input.GetKey(KeyCode.Alpha5))
            {
                if(Vector3.Distance(GameManager.instance.player.transform.position, transform.position)<5)
                {
                    transform.LookAt(GameManager.instance.player.transform.position);
                    transform.position = GameManager.instance.ChargePoint.position;
                }

            }
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    public bool Targeted()
    {
        renderer.material.color = Color.blue;
        isTargeted = true;
        return true;
    }

    public void Detargeted()
    {
        isTargeted = false;
        renderer.material.color = OriginalColor;

    }

void Die()
    {
        Destroy(gameObject);
    }
}
