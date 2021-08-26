using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private new Renderer renderer;

    Color OriginalColor;
    public int health = 10000;


    private void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        OriginalColor = renderer.material.color;
    }



    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        
    }

    public bool Targeted()
    {
        renderer.material.color = Color.blue;
        return true;
    }

    public void Detargeted()
    {
        renderer.material.color = OriginalColor;

    }

void Die()
    {
        Destroy(gameObject);
    }
}
