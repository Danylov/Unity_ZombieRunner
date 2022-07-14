using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   [SerializeField] private float hitPoints = 100f;

   private bool isDead = false;
   public bool IsDead { get => isDead; }

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
   }
}
