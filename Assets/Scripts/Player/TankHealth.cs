using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    [SerializeField] Slider slider;
    void Awake()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ShellEnemy"))
        {
            TakeDamage(collision.collider.GetComponent<Shell>().damageShell);
            // método que gestionará la vida del tanque enemigo
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        slider.value = currentHealth; // actualizamos la UI

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        // aparece la pantalla de Game Over
    }
}
