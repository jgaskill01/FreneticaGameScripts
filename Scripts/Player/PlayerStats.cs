using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{
    public class PlayerStats : CharacterStats
    {
        StartGame startGame;
        

        public HealthBar healthBar;

        AnimatorHandler animatorHandler;

        public bool isAlive = false;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            startGame = GetComponentInChildren<StartGame>();
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }
        
        public void TakeDamage(int damage)
        {

            if (isAlive)
                return;


            currentHealth = currentHealth - damage;

            healthBar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("Damage_01", true);

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Dead_01", true);

                isAlive = true;

                StartCoroutine(SceneTransitionTimer());
                
            }
        }

        IEnumerator SceneTransitionTimer()
        {            
                yield return new WaitForSeconds(5.0f);
                startGame.ReturnToMenu();
        }

       
    }
}
