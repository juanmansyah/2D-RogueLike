using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject logicScript;

    public GameObject deathEffect;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        logicScript = GameObject.Find("Game Logic");
        //logicScript.GetComponent<GameLogicScript>().LevelComplete += Enemy_LevelComplete;
        

    }

    private void Enemy_LevelComplete(object sender, EventArgs e)
    {
        TakeDamage(maxHealth);
    }

    private void LevelCompleted(object sender, EventArgs e)
    {

    }

    public void setHp()
    {

        maxHealth += 50;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }




    public void Die()
    {
        //logicScript.GetComponent<GameLogicScript>().LevelComplete -= Enemy_LevelComplete;
        GameObject DeathAnimation = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(DeathAnimation, 0.5f);
        Destroy(gameObject);
    }
}
