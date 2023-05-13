using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{
    public class EnemyStats : CharacterStats
    {
        public bool isDead = false;
        public AudioClip hitSound;


        EnemyManager enemyManager;
        Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            enemyManager = GetComponentInChildren<EnemyManager>();
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
        }

      

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (isDead == false)
            {

                currentHealth = currentHealth - damage;

                animator.Play("Damage_01");
               

                                     
            }
        }
    }
}
