using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{
    public class AttackState : State
    {

        PlayerStats playerStats;
        public CombatStanceState combatStanceState;
        public EnemyAttackAction[] enemyAttacks;
        public EnemyAttackAction currentAttack;
        public AudioClip enemySwingSound;

        private void Awake()
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }

        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
        {
            Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
            float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

            if (enemyManager.isPerformingAction)
                return combatStanceState;
            
            if (currentAttack != null)
            {
                if (distanceFromTarget < currentAttack.minDistanceNeededToAttack )
                {
                    return this;
                }
                else if (distanceFromTarget < currentAttack.maxDistanceNeededToAttack)
                {
                    if (viewableAngle <= currentAttack.maxAttackAngle && viewableAngle >= currentAttack.minAttackAngle)
                    {
                        if (enemyManager.currentRecoveryTime <= 0 && enemyManager.isPerformingAction == false && playerStats.isAlive == false)
                        {
                            enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                            enemyAnimatorManager.anim.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);
                            enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);                           
                            enemyManager.isPerformingAction = true;
                            enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
                            currentAttack = null;
                            AudioSource.PlayClipAtPoint(enemySwingSound, transform.position);
                            return combatStanceState;


                        }
                    }
                }
            }
            else
            {
                GetNewAttack(enemyManager);
            }

            return combatStanceState;
            
        }
        private void GetNewAttack(EnemyManager enemyManager)
        {
            Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
            float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, transform.position);

            int maxScore = 0;

            for (int i = 0; i < enemyAttacks.Length; i ++)
            {
                EnemyAttackAction enemyAttackAction = enemyAttacks[i];

                if (distanceFromTarget <= enemyAttackAction.maxDistanceNeededToAttack && distanceFromTarget >= enemyAttackAction.minDistanceNeededToAttack)
                {

                    if (viewableAngle <= enemyAttackAction.maxAttackAngle && viewableAngle >= enemyAttackAction.minAttackAngle)
                    {
                        maxScore += enemyAttackAction.attackScore;
                    }

                }
            }

            int randomValue = Random.Range(0, maxScore + 1);
            int tempScore = 0;

            for (int i = 0; i < enemyAttacks.Length; i++)
            {
                EnemyAttackAction enemyAttackAction = enemyAttacks[i];

                if (distanceFromTarget <= enemyAttackAction.maxDistanceNeededToAttack && distanceFromTarget >= enemyAttackAction.minDistanceNeededToAttack)
                {

                    if (viewableAngle <= enemyAttackAction.maxAttackAngle && viewableAngle >= enemyAttackAction.minAttackAngle)
                    {
                        if (currentAttack != null)

                            return;

                            tempScore += enemyAttackAction.attackScore;

                            if (tempScore > randomValue)
                            {
                                currentAttack = enemyAttackAction;
                            }

                    }

                }
            }
        }
    }
}
