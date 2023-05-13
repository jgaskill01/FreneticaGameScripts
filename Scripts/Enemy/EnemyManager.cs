using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JG
{
    public class EnemyManager : CharacterManager
    {

        EnemyLocomotionManager enemyLocomotionManager;
        EnemyAnimatorManager enemyAnimatorManager;
        EnemyStats enemyStats;
        Animator enemyAnimator;
        
        
        
        

        public State currentState;
        public CharacterStats currentTarget;
        public NavMeshAgent navMeshAgent;
        public Rigidbody enemyRigidBody;

        public bool isPerformingAction;
  
        
        public float rotationSpeed = 50;
        public float maximumAttackRange = 1.5f;



        [Header("A.I. Settings")]
        public float detectionRadius = 20;

        //Higher range is the size of detection cone :)
        public float minimumDetectionAngle = -50;
        public float maximumDetectionAngle = 50;
        

        public float currentRecoveryTime = 0;


        private void Awake()
        {
            enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
            enemyStats = GetComponent<EnemyStats>();
            enemyAnimator = GetComponentInChildren<Animator>();
            enemyRigidBody = GetComponent<Rigidbody>();
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
            navMeshAgent.enabled = false;
        }

        private void Start()
        {

            enemyRigidBody.isKinematic = false;

        }

        private void Update()
        {
            HandleRecoveryTimer();

            isDeadCheck();


        }

        private void FixedUpdate()
        {
            HandleStateMachine();

            

        }

        private void HandleStateMachine()
        {
            if (currentState != null)
            {
                State nextState = currentState.Tick(this, enemyStats, enemyAnimatorManager);

                if (nextState != null)
                {
                    SwitchToNextState(nextState);
                }
            }
        }

        private void SwitchToNextState(State state)
        {
            currentState = state;
        }

        

        private void HandleRecoveryTimer()
        {
            if (currentRecoveryTime > 0)
            {
                currentRecoveryTime -= Time.deltaTime;
            }
            
            if (isPerformingAction)
            {
                if (currentRecoveryTime <= 0)
                {
                    isPerformingAction = false;

                }
            }
        }

        private void isDeadCheck()
        {

            

            if (enemyStats.isDead || enemyStats.currentHealth <= 0)
            {
                enemyAnimator.Play("Dead_01");
                enemyStats.isDead = true;
            }
        }
    }
}
