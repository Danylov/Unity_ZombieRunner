using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100f;

    private bool isDead;

    public bool IsDead => isDead;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0f) Die();
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
        if (name == "Enemy (2)") { // Отладка
            Debug.Log("Die(): enemy.name =" + name); // Отладка
            Debug.Log("Die(): enemyHealth.IsDead =" + IsDead); // Отладка
        } // Отладка
    }
}