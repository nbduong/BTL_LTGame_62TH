using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public HealthBar healthBar;
    int currentHealth;
    public UnityEvent OnDeath;

    public void OnEnable()
    {
        OnDeath.AddListener(Death);
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth,maxHealth.ToString());
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateBar(currentHealth, maxHealth, currentHealth.ToString());
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
