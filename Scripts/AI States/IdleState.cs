using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{
    public class IdleState : State
    {
        PlayerStats playerStats;
        public PursueTargetState pursueTargetState;

        public LayerMask detectionLayer;

        private void Awake()
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }


        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
        {
            #region Handle Enemy Target Detection
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);

                for (int i = 0; i < colliders.Length; i++)
                {
                    CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

                    if (characterStats != null)
                    {
                        //check for team ID

                        Vector3 targetDirection = characterStats.transform.position - transform.position;
                        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                        if (viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
                        {
                            enemyManager.currentTarget = characterStats;
                        
                        }
                    }              
                }
            #endregion

            #region Handle State Switch

            if (enemyManager.currentTarget != null && playerStats.isAlive == false)
                {
                    return pursueTargetState;
                }
                else
                {
                    return this;
                }
            #endregion
        }
    }
}
